#pragma once
#include "ScriptService.h"

namespace Scripting
{
	namespace Processor
	{
		class VariableScriptProcessor : public IScriptProcessor
		{
		private:
			int _LocalParameterCount = 0;
			ParameterBlock _LocalVariables = ParameterBlock();
			ParameterBlock _NextScriptParameters = ParameterBlock();
		protected:
			void SetVariable(int index, int value);
			int GetVariable(int index);
		public:
			~VariableScriptProcessor();
			void InputParameterAddRange(ParameterBlock values);
			int Id();
			bool Process(IScriptService<>* service, BinaryReader* stream, int code, int& result);
			bool ProcessAssignment(IScriptService<>* service, BinaryReader* stream, int code, int& result);
		};
	}
}
