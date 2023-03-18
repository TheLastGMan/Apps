using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Enums
{
	public enum AEMode : int
	{
		Invalid					= -1,

		Program					= 0,
        Tv						= 1,
        Av						= 2,
        Manual					= 3,
        Bulb					= 4,
        Auto_DoF_AE				= 5,
        DoF_AE					= 6,
        Custom					= 7,
        Lock					= 8,
        Auto					= 9,
        Nignt_Portrait			= 10,
        Sports					= 11,
        Portrait				= 12,
        Landscape				= 13,
        Closeup					= 14,
        FlashOff				= 15,

		Custom2					= 16,
		Custom3					= 17,

        Creative_Auto			= 19,
        Movie					= 20,
        Photo_In_Movie			= 21,
		Scene_Intelligent_Auto	= 22,
		Night_Scene				= 23,
		Backlit_Scene			= 24,
		Special_Scene			= 25,
		Children				= 26,
		Food					= 27,
		Candlelight_Portrait	= 28
	}
}
