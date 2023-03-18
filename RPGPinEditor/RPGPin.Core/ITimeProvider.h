#pragma once
#include "Types.h"

namespace HAL
{
	class ITimeProvider
	{
	public:
		virtual int Id() { return 0; }

		//DateTime.Now
		virtual int Now() { return 0; }
		virtual void SetSystemTime(int epoch) {}
		virtual void SetSystemTime(int year, int month, int day, int hours, int minutes, int seconds) {}
		virtual byte Seconds() { return 0; }
		virtual byte Minutes() { return 0; }
		virtual byte Hours() { return 0; }
		virtual byte HoursMilitary() { return 0; }
		virtual bool AmPm() { return 0; }
		virtual byte Day() { return 0; }
		virtual byte Month() { return 0; }
		virtual short Year() { return 0; }
		virtual short DayOfYear() { return 0; }
		virtual bool IsLeapYear() { return 0; }

		//DateTime.FromEpoch(epoch)
		virtual byte GetSeconds(int epoch) { return 0; }
		virtual byte GetMinutes(int epoch) { return 0; }
		virtual byte GetHours(int epoch) { return 0; }
		virtual byte GetHoursMilitary(int epoch) { return 0; }
		virtual bool GetAmPm(int epoch) { return 0; }
		virtual byte GetDay(int epoch) { return 0; }
		virtual byte GetMonth(int epoch) { return 0; }
		virtual short GetYear(int epoch) { return 0; }
		virtual short GetDayOfYear(int epoch) { return 0; }
		virtual bool GetIsLeapYear(int epoch) { return 0; }
	};
}