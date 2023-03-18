using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPinEditor.Core
{
	public enum CommandCode : int
	{
		//---------- SYSTEM COMMANDS ----------
		//Low Level
		Nop = 1,
		Jump = 2,
		Constant = 4,
		Call = 8,
		Return = 31,   //since default return is constant, this would yield a code of 314 (PI)

		//Block Statements
		IfElse = 16,
		Switch = 32,
		For = 64,

		//Block Keywords (Specific to each Block statement)
		EndBlock = (IfElse | Switch | For), //ends the current block we are in
		GotoCase = Switch + 2, //Switch
		Break = (For | Switch) + 2, //Loops/Switch //exit whatever code segment we are one
		Continue = For + 2, //Loops

		//ComparatorExpressions (Group 13/14)
		AndAlso = IfElse + 4,
		OrElse = IfElse + 8,

		//---------------------------------------------------------------------------------
		//---------- BASIC MATH ----------

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

		//---------------------------------------------------------------------------------
		//---------- EQUALITY ----------

		//Comparator (Group 8)
		GreaterThan = 320,
		GreaterThanEqual = 324,
		LessThan = 322,
		LessThanEqual = 326,

		//Equality (Group 9)
		LogicalGrouping = 340, //(...)
		Equals = 342, //[l,r]
		Not = 344, //[one value]
		NotEqual = 346, //[l,r]

		//---------------------------------------------------------------------------------
		//---------- VARIABLE ----------

		//Variables
		NextParameterClear = 400,
		NextParameterCreate = 402,
		VariableCreate = 404,
		VariableGet = 406,
		VariableSet = 408,
		VariableDelete = 410,
		VariableLowerBound = 412,
		VariableUpperBound = 414,

		//---------------------------------------------------------------------------------
		//---------- ASSIGNMENTS ----------

		//Assignments Group 16
		AddAssignment = 424,
		SubAssignment = 426,
		MulAssignment = 428,
		DivAssignment = 430,
		ModAssignment = 432,
		OrAssignment = 434,
		AndAssignment = 436,
		XORAssignment = 438,

		//---------------------------------------------------------------------------------
		//---------- TIME ----------

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

		//---------------------------------------------------------------------------------
		//---------- AUDIO ----------
		AudioPlay = 500, //(AudioStream(id, volume))
		AudioPlayImmediate = 502, //(AudioStream(id, volume))
		AudioStop = 504, //(channel)
		AudioStopAll = 506,
		AudioSetMute = 508, //(channel, mute T/F)
		AudioSetMuteAll = 510, //(mute T/F)
		AudioSetVolume = 512, //(channel, volume)
		AudioSetVolumeAll = 514, //(volume)
		AudioPause = 516, //(channel)
		AudioPauseAll = 518,
		AudioResume = 520, //(channel)
		AudioResumeAll = 522,
		AudioChannels = 524,

		//---------------------------------------------------------------------------------
		//----- Game Usage -----
		//Audit
		GameAuditGet = 3000, //index
		GameAuditSet = 3002, //index, value
		GameAuditAdd = 3004, //index, value
		GameAuditCount = 3006,
		GameAuditClear = 3008, //index
		GameAuditClearAll = 3010,

		//Settings
		GameSettingGet = 3020, //index
		GameSettingSet = 3022, //index, value
		GameSettingAdd = 3024, //index, value
		GameSettingCount = 3026,
		GameSettingClear = 3028, //index
		GameSettingClearAll = 3030,

		//TimeStamps
		GameTimeStampGet = 3040, //index
		GameTimeStampSet = 3042, //index (value is from Time.Now())
		GameTimeStampAdd = 3044, //index, value
		GameTimeStampCount = 3046,
		GameTimeStampClear = 3048, //index
		GameTimeStampClearAll = 3050,

		//Counts
		GameCountsGet = 3060,
		GameCountsSet = 3062,
		GameCountsAdd = 3064,
		GameCountsCount = 3066,
		GameCountsClear = 3068,
		GameCountsClearAll = 3070,

		//Globals
		GameGlobalGet = 3080,
		GameGlobalSet = 3082,
		GameGlobalAdd = 3084,
		GameGlobalCount = 3086,
		GameGlobalFill = 3088,
		GameGlobalClear = 3090,
		GameGlobalClearAll = 3092,

		//Player
		PlayerAdd = 3100,
		PlayerRemoveLast = 3102,
		PlayerCount = 3104,
		PlayerClearAll = 3106,

		//Player Settings
		PlayerSettingGet = 3120,
		PlayerSettingSet = 3122,
		PlayerSettingAdd = 3124,
		PlayerSettingCount = 3126,
		PlayerSettingClear = 3128,
		PlayerSettingClearAll = 3130,

		//---------------------------------------------------------------------------------
		//
		TBD = -1
	}
}
