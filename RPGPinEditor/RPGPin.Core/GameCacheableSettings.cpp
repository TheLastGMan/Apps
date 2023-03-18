#include "GameCacheAbleSetting.h"
#include "ResourceService.h"
#include "Logger.h"
#include <memory>

using namespace Logging;
using namespace Resource;

namespace GameAdmin
{
	void GameCacheAbleSetting::Fill()
	{
		Logger::LogDebug(Name() + ": Fill");

		//find resource stream
		unique_ptr<BinaryReader> reader(ResourceService::Load(_Type, _ResourceId));

		//clear audits and load from stream
		ClearAll();
		int count = reader->ReadInt32();
		while (count-- > 0)
			AddLast(reader->ReadInt32());
	}

	void GameCacheAbleSetting::Flush()
	{
		Logger::LogDebug(Name() + ": Flush");

		//store the count of items
		int count = Count();

		//find writer and write counts
		unique_ptr<BinaryWriter> writer(Resource::ResourceService::SaveStream(_Type, _ResourceId));
		writer->Write(count);
		for (int i = 0; i < count; i++)
			writer->Write(Get(i));
	}
}