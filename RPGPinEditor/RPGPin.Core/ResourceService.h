#pragma once
#include "ResourceType.h"
#include "IResourceLocator.h"
#include "UniqueCollection.h"
#include "BinaryReader.h"

using namespace DataType;
using namespace System::IO;

namespace Resource
{
	class ResourceService
	{
	private:
		ResourceService() {}
		static UniqueCollection<IResourceLocator*> _Locaters;
		static bool resourceComparer(IResourceLocator* o1, IResourceLocator* o2);
	public:
		static bool AddLocater(IResourceLocator* locater);
		static bool RemoveLocater(IResourceLocator* locater);
		static BinaryReader* Load(ResourceType type, int id);
		static BinaryWriter* SaveStream(ResourceType type, int id);
	};
}