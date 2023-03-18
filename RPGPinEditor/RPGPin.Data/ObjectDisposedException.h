#pragma once
#include "InvalidOperationException.h"

namespace System
{
	class ObjectDisposedException : public InvalidOperationException
	{
	private:
		string _ObjectName;
		const string _ObjDisp = "Object Disposed";
	public:
		ObjectDisposedException() : ObjectDisposedException("", _ObjDisp) {};
		ObjectDisposedException(string objectName) : ObjectDisposedException(objectName, _ObjDisp) {};
		ObjectDisposedException(string objectName, string message) : InvalidOperationException(message)
		{
			_ObjectName = objectName;
		}
		ObjectDisposedException(string message, Exception* innerException) : InvalidOperationException(message, innerException) {};

		virtual string Message()
		{
			if (_ObjectName.empty())
				return InvalidOperationException::Message();

			return InvalidOperationException::Message() + "\r\n" + _ObjDisp + ": " + _ObjectName;
		};
		string ObjectName() { return _ObjectName; };
	};
}