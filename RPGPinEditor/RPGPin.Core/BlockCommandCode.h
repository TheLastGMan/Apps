#pragma once

namespace Scripting
{
	namespace Processor
	{
		enum class BlockCommandCode : int
		{
			//Block Statements
			IfElse = 16,
			Switch = 32,
			For = 64,

			//Block Keywords (Specific to each Block statement)
			GotoCase = Switch + 2, //Switch
			Break = (For | Switch) + 2, //Loops/Switch //exit whatever code segment we are one
			Continue = For + 2 //Loops
		};
	}
}