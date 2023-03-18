#include "EqualityScriptProcessor.h"
#include "ScriptProcessor.h"

namespace Scripting
{
	namespace Processor
	{
		enum class EqualityCommandCode : int
		{
			//Comparator (Group 8) - [lvalue, rvalue]
			GreaterThan = 320,
			GreaterThanEqual = 324,
			LessThan = 322,
			LessThanEqual = 326,

			//Equality (Group 9)
			LogicalGrouping = 340, //(...)
			Equals = 342, //[l,r]
			Not = 344, //[one value]
			NotEqual = 346, //[l,r]
		};

		int EqualityScriptProcessor::Id()
		{
			return (int)DataType::ScriptProcessor::Equality;
		}

		bool EqualityScriptProcessor::Process(IScriptService<>* service, BinaryReader* stream, int code, int& result)
		{
			//common
			int lvalue = 0;
			int rvalue = 0;

			//parse command
			switch ((EqualityCommandCode)code)
			{
			case EqualityCommandCode::GreaterThan:
			case EqualityCommandCode::GreaterThanEqual:
			case EqualityCommandCode::LessThan:
			case EqualityCommandCode::LessThanEqual:
			case EqualityCommandCode::Equals:
			case EqualityCommandCode::NotEqual:
				//these have two inputs
				lvalue = service->Process(stream); //l-value
				rvalue = service->Process(stream); //r-value

				//run again to pick which action to apply
				switch ((EqualityCommandCode)code)
				{
				case EqualityCommandCode::GreaterThan:
					result = (int)(lvalue > rvalue);
					break;
				case EqualityCommandCode::GreaterThanEqual:
					result = (int)(lvalue >= rvalue);
					break;
				case EqualityCommandCode::LessThan:
					result = (int)(lvalue < rvalue);
					break;
				case EqualityCommandCode::LessThanEqual:
					result = (int)(lvalue <= rvalue);
					break;
				case EqualityCommandCode::Equals:
					result = (int)(lvalue == rvalue);
					break;
				case EqualityCommandCode::NotEqual:
					result = (int)(lvalue != rvalue);
					break;
				default:
					return false;
				}
				break;
			case EqualityCommandCode::Not:
				lvalue = service->Process(stream); //base value
				result = (int)(lvalue == 0); //assumes T/F input of (F = 0, T != 0)
				break;
			case EqualityCommandCode::LogicalGrouping:
				result = service->Process(stream);
				break;

			default:
				return false;
			}

			//unknown cmds return false, return true here
			return true;
		}
	}
}