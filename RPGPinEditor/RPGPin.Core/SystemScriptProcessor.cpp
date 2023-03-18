#include "SystemScriptProcessor.h"
#include "LoopScriptProcessor.h"
#include "SwitchScriptProcessor.h"
#include "ScriptProcessor.h"

namespace Scripting
{
	namespace Processor
	{
		enum class SystemCommandCode : int
		{
			//System, Low level
			Nop = 1,
			Jump = 2,
			Constant = 4,
			Call = 8,

			//Block Statements
			IfElse = 16,
			Switch = 32,
			For = 64,

			//Partial Block Keywords (Specific to each Block statement)
			EndBlock = (IfElse | Switch | For), //ends the current block we are in

			//ComparatorExpressions (Group 13/14)
			AndAlso = IfElse + 4,
			OrElse = IfElse + 8
		};

		int SystemScriptProcessor::Id()
		{
			return (int)DataType::ScriptProcessor::SYSTEM;
		}

		bool SystemScriptProcessor::Process(IScriptService<>* service, BinaryReader* stream, int code, int& result)
		{
			//shared args
			int arg0 = 0;
			int arg1 = 0;
			unique_ptr<ParameterBlock> pb = null;

			//parse command code
			switch ((SystemCommandCode)code)
			{
				//System, Low Level
			case SystemCommandCode::Nop:
				//do nothing
				break;
			case SystemCommandCode::Jump:
				//next raw value as length
				arg0 = stream->ReadInt32();
				stream->BaseStream()->Seek(arg0 *= 4, SeekOrigin::Current);
				break;
			case SystemCommandCode::Constant:
				//give next raw int as value
				result = stream->ReadInt32();
				break;
			case SystemCommandCode::Call:
				//call a method
				arg0 = service->Process(stream); //script id
				arg1 = stream->ReadInt32(); //number of parameters

				//load parameters
				pb = unique_ptr<ParameterBlock>(new ParameterBlock());
				while (arg1-- > 0)
					pb->Add(service->Process(stream));

				result = ScriptService::ProcessScript(arg0, *pb);
				break;

				//Block Statements
			case SystemCommandCode::IfElse:
				//add new script processor
				//Conditional
				arg0 = service->Process(stream);
				//>IfBlockLength
				arg1 = stream->ReadInt32();
				//>IfBlock
				if (arg0 == 0)
				{
					//inverse logic, if the conditional is false, skip over block
					stream->BaseStream()->Seek(arg1 *= 4, SeekOrigin::Current);
				}
				break;
			case SystemCommandCode::Switch:
				//add new script processor
				//set current position and read in break offset from position
				arg1 = stream->ReadInt32(); //break line offset
				arg0 = stream->BaseStream()->Position(); //initial position
				arg1 = arg0 + (arg1 * 4); //update so initial position + break offset

				//add switch processor to handle advanced handling
				service->PushScriptProcessor(new SwitchScriptProcessor(arg0, arg1));
				break;
			case SystemCommandCode::For:
				//Loops (For/While/DoWhile) types
				//Break Offset -> Length
				//>Continue Offset -> Loop Block

				//read in positions offsets and update from current position at the time
				arg0 = (stream->ReadInt32() * 4) + stream->BaseStream()->Position(); //break position
				arg1 = (stream->ReadInt32() * 4) + stream->BaseStream()->Position(); //continue position

				//add loop processor to handle advanced handling
				service->PushScriptProcessor(new LoopScriptProcessor(arg0, arg1));
				break;
			case SystemCommandCode::EndBlock:
				//clean up last script processor
				delete (IScriptProcessor*)service->PopScriptProcessor();
				break;

				//ComparatorExpressions (Group 13/14)
			case SystemCommandCode::AndAlso:
				//process l-value result and r-value offset
				arg0 = service->Process(stream);
				arg1 = stream->ReadInt32(); //offset if false

				//check for compound condition
				if (arg0 == 0)
				{
					//if false, any further AND can't make it true
					result = 0;
					stream->BaseStream()->Seek(arg1 *= 4, SeekOrigin::Current);
				}
				else
				{
					//check rvalue is not zero | ex: 1 && (2 + 3 < 1)
					//rvalue of && would be false, so rvalue must not be zero to hold this true
					result = (int)(service->Process(stream) != 0);
				}
				break;
			case SystemCommandCode::OrElse:
				//process l-value result and r-value offset
				arg0 = service->Process(stream);
				arg1 = stream->ReadInt32(); //offset if true (# of lines)

				//determine action
				if (arg0 != 0)
				{
					//if true, any further OR can't make it false
					result = 1;
					stream->BaseStream()->Seek(arg1 *= 4, SeekOrigin::Current);
				}
				else
				{
					//check rvalue is zero | ex: 0 || (2 + 3 > 1)
					//rvalue of || would be true, so rvalue must not be zero to hold this true
					result = (int)(service->Process(stream) != 0);
				}
				break;

			default:
				return false;
			}

			//unknown cmds return false, return true here
			return true;
		}
	}
}