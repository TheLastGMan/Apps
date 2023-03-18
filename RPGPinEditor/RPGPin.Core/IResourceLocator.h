#pragma once
#include "ResourceType.h"
#include "BinaryReader.h"
#include "BinaryWriter.h"

using namespace System::IO;

namespace Resource
{
	class IResourceLocator
	{
	public:
		virtual int Id() { return 0; }
		virtual BinaryReader* Load(ResourceType type, int id) { return null; }
		virtual BinaryWriter* SaveStream(ResourceType type, int id) { return null; }

		//operator
		bool operator==(IResourceLocator other)
		{
			return Id() == other.Id();
		}
		bool operator==(IResourceLocator *other)
		{
			return Id() == other->Id();
		}
	};

	inline bool operator==(IResourceLocator& lh, IResourceLocator& rh)
	{
		return lh.Id() == rh.Id();
	}
}