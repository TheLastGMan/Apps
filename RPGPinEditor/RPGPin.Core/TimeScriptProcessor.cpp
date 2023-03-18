#include "TimeScriptProcessor.h"
#include "TimeService.h"
#include "ScriptProcessor.h"

namespace HAL
{
	enum class TimeCommandCode : int
	{
		//Time-Now
		TimeNow = 800,
		TimeNowSet = 802, //value
		TimeNowSetSpecific = 804, //year, month, day, hours, minutes, seconds
		TimeNowSeconds = 806,
		TimeNowMinutes = 808,
		TimeNowHours = 810,
		TimeNowHoursMilitary = 812,
		TimeNowAmPm = 814,
		TimeNowDay = 816,
		TimeNowMonth = 818,
		TimeNowYear = 820,
		TimeNowIsLeapYear = 822,
		TimeNowDayOfYear = 824,

		//Time-FromEpoch
		TimeGetSeconds = 830, //epoch
		TimeGetMinutes = 832, //epoch
		TimeGetHours = 834, //epoch
		TimeGetHoursMilitary = 836, //epoch
		TimeGetAmPm = 838, //epoch
		TimeGetDay = 840, //epoch
		TimeGetMonth = 842, //epoch
		TimeGetYear = 844, //epoch
		TimeGetIsLeapYear = 846, //epoch
		TimeGetDayOfYear = 848, //epoch
	};

	int TimeScriptProcessor::Id()
	{
		return (int)DataType::ScriptProcessor::Time;
	}

	bool TimeScriptProcessor::Process(IScriptService<>* service, BinaryReader* stream, int code, int& result)
	{
		//common lh/rh values
		int lvalue = 0;
		int rvalue = 0;
		int time[6] = { 0 };

		switch ((TimeCommandCode)code)
		{
			//Time-Now
		case TimeCommandCode::TimeNow:
			result = TimeService::Retrieve()->Now();
			break;
		case TimeCommandCode::TimeNowSet:
			lvalue = service->Process(stream); //index
			TimeService::Retrieve()->SetSystemTime(lvalue);
			break;
		case TimeCommandCode::TimeNowSetSpecific:
			for (byte i = 0; i < 6; i++)
				time[i] = service->Process(stream);
			TimeService::Retrieve()->SetSystemTime(time[0], time[1], time[2], time[3], time[4], time[5]);
			break;
			//Time.FromEpoch(epoch)
		case TimeCommandCode::TimeNowSeconds:
			result = TimeService::Retrieve()->Seconds();
			break;
		case TimeCommandCode::TimeNowMinutes:
			result = TimeService::Retrieve()->Minutes();
			break;
		case TimeCommandCode::TimeNowHours:
			result = TimeService::Retrieve()->Hours();
			break;
		case TimeCommandCode::TimeNowHoursMilitary:
			result = TimeService::Retrieve()->HoursMilitary();
			break;
		case TimeCommandCode::TimeNowAmPm:
			result = TimeService::Retrieve()->AmPm();
			break;
		case TimeCommandCode::TimeNowDay:
			result = TimeService::Retrieve()->Day();
			break;
		case TimeCommandCode::TimeNowMonth:
			result = TimeService::Retrieve()->Month();
			break;
		case TimeCommandCode::TimeNowYear:
			result = TimeService::Retrieve()->Year();
			break;
		case TimeCommandCode::TimeNowIsLeapYear:
			result = TimeService::Retrieve()->IsLeapYear();
			break;
		case TimeCommandCode::TimeNowDayOfYear:
			result = TimeService::Retrieve()->DayOfYear();
			break;


			//Time.FromEpoch(epoch)
		case TimeCommandCode::TimeGetSeconds:
			lvalue = service->Process(stream);
			result = TimeService::Retrieve()->GetSeconds(lvalue);
			break;
		case TimeCommandCode::TimeGetMinutes:
			lvalue = service->Process(stream);
			result = TimeService::Retrieve()->GetMinutes(lvalue);
			break;
		case TimeCommandCode::TimeGetHours:
			lvalue = service->Process(stream);
			result = TimeService::Retrieve()->GetHours(lvalue);
			break;
		case TimeCommandCode::TimeGetHoursMilitary:
			lvalue = service->Process(stream);
			result = TimeService::Retrieve()->GetHoursMilitary(lvalue);
			break;
		case TimeCommandCode::TimeGetAmPm:
			lvalue = service->Process(stream);
			result = TimeService::Retrieve()->GetAmPm(lvalue);
			break;
		case TimeCommandCode::TimeGetDay:
			lvalue = service->Process(stream);
			result = TimeService::Retrieve()->GetDay(lvalue);
			break;
		case TimeCommandCode::TimeGetMonth:
			lvalue = service->Process(stream);
			result = TimeService::Retrieve()->GetMonth(lvalue);
			break;
		case TimeCommandCode::TimeGetYear:
			lvalue = service->Process(stream);
			result = TimeService::Retrieve()->GetYear(lvalue);
			break;
		case TimeCommandCode::TimeGetIsLeapYear:
			lvalue = service->Process(stream);
			result = TimeService::Retrieve()->GetIsLeapYear(lvalue);
			break;
		case TimeCommandCode::TimeGetDayOfYear:
			lvalue = service->Process(stream);
			result = TimeService::Retrieve()->GetDayOfYear(lvalue);
			break;

		default:
			return false;
		}

		//default
		return true;
	}
}