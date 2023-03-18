#pragma once

namespace System
{
	namespace IO
	{
		enum class SeekOrigin : int
		{
			// These constants match Win32's FILE_BEGIN, FILE_CURRENT, and FILE_END
			Begin = 0,
			Current = 1,
			End = 2
		};
	}
}