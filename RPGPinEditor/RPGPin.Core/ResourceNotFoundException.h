#pragma once
#include <string>
#include "Exception.h"
#include "ResourceType.h"

using namespace std;
using namespace System;

namespace Resource
{
	class ResourceNotFoundException : public Exception
	{
	private:
		static string _SNFEx;
		string errorLine(ResourceType type, int id) { return string(_SNFEx) + ": Type: " + to_string((int)type) + " | Id: " + to_string(id); }
	public:
		ResourceNotFoundException() : Exception(_SNFEx) {};
		ResourceNotFoundException(ResourceType type, int id) : Exception(errorLine(type, id)) {};
		ResourceNotFoundException(ResourceType type, int id, Exception* innerException) : Exception(errorLine(type, id), innerException) {}
	};

#ifndef ResourceNotFound_H
#define ResourceNotFound_H
	string ResourceNotFoundException::_SNFEx = string("Resource Not Found");
#endif

}