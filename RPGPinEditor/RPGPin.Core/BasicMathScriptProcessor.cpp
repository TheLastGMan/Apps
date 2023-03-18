#include "BasicMathScriptProcessor.h"
#include "ScriptProcessor.h"

namespace Scripting
{
	namespace Processor
	{
		enum class BasicMathCommandCode : int
		{
			//Basic Math (Group 5/Group 6)
			Addition = 200,
			Subtraction = 202,
			Multiply = 204,
			Divide = 206,
			Modulus = 208,

			//Other Basic Math (Group 10/Group 11/Group 12)
			And = 240,
			Or = 242,
			XOR = 244,
		};

		int BasicMathScriptProcessor::Id()
		{
			return (int)DataType::ScriptProcessor::BasicMath;
		}

		bool BasicMathScriptProcessor::Process(IScriptService<>* service, BinaryReader* stream, int code, int& result)
		{
			//set default
			int lvalue = 0;
			int rvalue = 0;

			//pick action
			switch ((BasicMathCommandCode)code)
			{
			case BasicMathCommandCode::Addition:
			case BasicMathCommandCode::Subtraction:
			case BasicMathCommandCode::Multiply:
			case BasicMathCommandCode::Divide:
			case BasicMathCommandCode::Modulus:
			case BasicMathCommandCode::And:
			case BasicMathCommandCode::Or:
			case BasicMathCommandCode::XOR:
				//these have to inputs (lvalue, rvalue)
				lvalue = service->Process(stream);
				rvalue = service->Process(stream);

				//switch again to pick action type
				switch ((BasicMathCommandCode)code)
				{
				case BasicMathCommandCode::Addition:
					result = lvalue + rvalue;
					break;
				case BasicMathCommandCode::Subtraction:
					result = lvalue - rvalue;
					break;
				case BasicMathCommandCode::Multiply:
					result = lvalue * rvalue;
					break;
				case BasicMathCommandCode::Divide:
					result = (int)(lvalue / rvalue);
					break;
				case BasicMathCommandCode::Modulus:
					result = lvalue % rvalue;
					break;
				case BasicMathCommandCode::And:
					result = lvalue & rvalue;
					break;
				case BasicMathCommandCode::Or:
					result = lvalue | rvalue;
					break;
				case BasicMathCommandCode::XOR:
					result = lvalue ^ rvalue;
					break;

				default:
					return false;
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