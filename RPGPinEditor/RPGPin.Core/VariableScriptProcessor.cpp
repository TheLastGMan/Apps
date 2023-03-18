#include "VariableScriptProcessor.h"
#include "ArgumentOutOfRangeException.h"
#include "ScriptProcessor.h"

using namespace System;

namespace Scripting
{
	namespace Processor
	{
		enum class VariableCommandCode : int
		{
			//Next Script Parameters
			NextParameterClear = 400,
			NextParameterCreate = 402,

			//Local Script Parameters
			VariableCreate = 404,
			VariableGet = 406,
			VariableSet = 408,
			VariableDelete = 410,
			VariableLowerBound = 412,
			VariableUpperBound = 414,
		};

		enum class AssignmentCommandCode : int
		{
			//Assignments Group 16
			AddAssignment = 424,
			SubAssignment = 426,
			MulAssignment = 428,
			DivAssignment = 430,
			ModAssignment = 432,
			OrAssignment = 434,
			AndAssignment = 436,
			XORAssignment = 438
		};

		VariableScriptProcessor::~VariableScriptProcessor()
		{
			_LocalVariables.Clear();
			_NextScriptParameters.Clear();
		}

		void VariableScriptProcessor::InputParameterAddRange(ParameterBlock values)
		{
			_LocalParameterCount = values.Count();
			_LocalVariables.AddRange(values);
		}

		int VariableScriptProcessor::Id()
		{
			return (int)DataType::ScriptProcessor::Variable;
		}

		bool VariableScriptProcessor::Process(IScriptService<>* service, BinaryReader* stream, int code, int& result)
		{
			//common
			int index = 0;
			int alterValue = 0;
			int varValue = 0;

			//process command
			switch ((VariableCommandCode)code)
			{
				//Next Script Parameters
			case VariableCommandCode::NextParameterClear:
				_NextScriptParameters.Clear();
				break;
			case VariableCommandCode::NextParameterCreate:
				//next cmd as value, return created at index
				varValue = service->Process(stream);
				_NextScriptParameters.Add(varValue);
				result = _NextScriptParameters.Count() - 1;
				break;

				//Local Variables
			case VariableCommandCode::VariableCreate:
				//next cmd as value, return created index
				varValue = service->Process(stream);
				_LocalVariables.Add(varValue);
				result = _LocalVariables.Count() - 1;
				break;
			case VariableCommandCode::VariableGet:
				//next cmd as index, return value
				index = service->Process(stream);

				//[parameters{0,1,_LocalParameterCount - 1}][variables{_LocalParameterCount, _LocalVariables.Count() - 1}]
				result = GetVariable(index);
				break;
			case VariableCommandCode::VariableSet:
				//(index, value)
				index = service->Process(stream);
				varValue = service->Process(stream);

				SetVariable(index, varValue);
				break;
			case VariableCommandCode::VariableDelete:
				//next cmd as index, delete it
				index = service->Process(stream);

				//[parameters{0,1,_LocalParameterCount - 1}][variables{_LocalParameterCount, _LocalVariables.Count() - 1}]
				//validate
				if (index < 0 || index >= _LocalVariables.Count())
					throw ArgumentOutOfRangeException("index");

				_LocalVariables.DeleteAt(index);
				break;
			case VariableCommandCode::VariableLowerBound:
				result = _LocalParameterCount;
				break;
			case VariableCommandCode::VariableUpperBound:
				result = _LocalVariables.Count() - 1;
				break;

			default:
				return ProcessAssignment(service, stream, code, result);
			}

			//unknown cmds return false, return true here
			return true;
		}

		bool VariableScriptProcessor::ProcessAssignment(IScriptService<>* service, BinaryReader* stream, int code, int& result)
		{
			//common
			int index = 0;
			int alterValue = 0;
			int varValue = 0;

			//determine code
			switch ((AssignmentCommandCode)code)
			{
			case AssignmentCommandCode::AddAssignment:
			case AssignmentCommandCode::SubAssignment:
			case AssignmentCommandCode::MulAssignment:
			case AssignmentCommandCode::DivAssignment:
			case AssignmentCommandCode::ModAssignment:
			case AssignmentCommandCode::OrAssignment:
			case AssignmentCommandCode::AndAssignment:
			case AssignmentCommandCode::XORAssignment:
				//load (index, value)
				index = service->Process(stream);
				alterValue = service->Process(stream);
				varValue = VariableScriptProcessor::GetVariable(index);

				//determine action
				switch ((AssignmentCommandCode)code)
				{
				case AssignmentCommandCode::AddAssignment:
					varValue += alterValue;
					break;
				case AssignmentCommandCode::SubAssignment:
					varValue -= alterValue;
					break;
				case AssignmentCommandCode::MulAssignment:
					varValue *= alterValue;
					break;
				case AssignmentCommandCode::DivAssignment:
					varValue = (int)(varValue / alterValue);
					break;
				case AssignmentCommandCode::ModAssignment:
					varValue %= alterValue;
					break;
				case AssignmentCommandCode::OrAssignment:
					varValue |= alterValue;
					break;
				case AssignmentCommandCode::AndAssignment:
					varValue &= alterValue;
					break;
				case AssignmentCommandCode::XORAssignment:
					varValue ^= alterValue;
					break;

				default:
					return false;
				}

				//update value
				VariableScriptProcessor::SetVariable(index, varValue);
				break;

			default:
				return false;
			}

			//unknown cmds return false, return true here
			return true;
		}

		void VariableScriptProcessor::SetVariable(int index, int value)
		{
			//validate
			if (index < 0 || index >= _LocalVariables.Count())
				throw new ArgumentOutOfRangeException("index");

			//update index with value
			_LocalVariables.Update(index, value);
		}

		int VariableScriptProcessor::GetVariable(int index)
		{
			//validate
			if (index < 0 || index >= _LocalVariables.Count())
				throw new ArgumentOutOfRangeException("index");

			return _LocalVariables.ValueAt(index);
		}
	}
}
