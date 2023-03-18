#include "ResourceService.h"
#include "Logger.h"
#include "ResourceNotFoundException.h"

using namespace Logging;

namespace Resource
{
	UniqueCollection<IResourceLocator*> ResourceService::_Locaters = UniqueCollection<IResourceLocator*>();

	bool ResourceService::resourceComparer(IResourceLocator* o1, IResourceLocator* o2)
	{
		return o1->Id() == o2->Id();
	}

	bool ResourceService::AddLocater(IResourceLocator* locater)
	{
		if (_Locaters.Add(locater, resourceComparer))
		{
			Logger::LogDebug("ResourceService: Locater: " + to_string(locater->Id()) + " | Added");
			return true;
		}
		return false;
	}

	bool ResourceService::RemoveLocater(IResourceLocator* locater)
	{
		if (_Locaters.Delete(locater, resourceComparer))
		{
			Logger::LogDebug("ResourceService: Locater: " + to_string(locater->Id()) + " | Removed");
			return true;
		}
		return false;
	}

	BinaryReader* ResourceService::Load(ResourceType type, int id)
	{
		Logger::LogDebug("ResourceService: Load: " + to_string((int)type) + " | Id: " + to_string(id));

		BinaryReader* stream = null;
		for (auto it = _Locaters.begin(); it != _Locaters.end(); it++)
		{
			stream = (*it)->Load(type, id);
			if (stream != null)
				return stream;
		}

		//stream not found
		throw new ResourceNotFoundException(type, id);
	}

	BinaryWriter* ResourceService::SaveStream(ResourceType type, int id)
	{
		Logger::LogDebug("ResourceService: Save: " + to_string((int)type) + " | Id: " + to_string(id));

		BinaryWriter* result = null;
		for (auto it = _Locaters.begin(); it != _Locaters.end(); it++)
		{
			result = (*it)->SaveStream(type, id);
			if (result != null)
				return result;
		}

		//unable to save
		Logger::LogWarn("ResourceService: Save: " + to_string((int)type) + " | Id: " + to_string(id) + " | Unable");
		return result;
	}
}
