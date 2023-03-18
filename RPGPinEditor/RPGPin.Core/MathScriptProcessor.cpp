#include "MathScriptProcessor.h"
#include "ScriptProcessor.h"
#include "RandomService.h"
#include <cstdlib>
#include <algorithm>

using namespace std;

namespace HAL
{
	enum class MathCommandCode : int
	{
		MathRandom = 900,
		MathRandomMax = 902,
		MathRandomRange = 904,

		MathAbs = 910,
		MathMin = 912,
		MathMax = 914,
		MathPower = 916
	};

	int MathScriptProcessor::Id()
	{
		return (int)ScriptProcessor::Math;
	}

	bool MathScriptProcessor::Process(IScriptService<>* service, BinaryReader* stream, int code, int& result)
	{
		int lvalue = 0;
		int rvalue = 0;

		switch ((MathCommandCode)code)
		{
		case MathCommandCode::MathRandom:
			result = RandomService::Retrieve()->Next();
			break;
		case MathCommandCode::MathRandomMax:
			lvalue = service->Process(stream);
			result = RandomService::Retrieve()->Next(lvalue);
			break;
		case MathCommandCode::MathRandomRange:
			lvalue = service->Process(stream);
			rvalue = service->Process(stream);
			result = RandomService::Retrieve()->Next(lvalue, rvalue);
			break;

		case MathCommandCode::MathAbs:
			lvalue = service->Process(stream);
			result = abs(lvalue);
			break;
		case MathCommandCode::MathMin:
			lvalue = service->Process(stream);
			rvalue = service->Process(stream);
			result = min(lvalue, rvalue);
			break;
		case MathCommandCode::MathMax:
			lvalue = service->Process(stream);
			rvalue = service->Process(stream);
			result = max(lvalue, rvalue);
			break;
		case MathCommandCode::MathPower:
			lvalue = service->Process(stream);
			rvalue = service->Process(stream);
			result = (int)pow(lvalue, rvalue);
			break;

		default:
			return false;
		}

		//default
		return true;
	}
}