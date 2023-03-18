using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finder
{
	public interface ITypeFinder
	{

		/// <summary>
		/// Found items converted to the declaring type
		/// </summary>
		/// <typeparam name="T">Type to search for</typeparam>
		/// <returns>Enumerable list of classes of the type</returns>
		IEnumerable<T> FoundClassesOfType<T>() where T : class;

		/// <summary>
		/// Find the declaring type within the loaded libraries
		/// </summary>
		/// <typeparam name="T">Generic type</typeparam>
		/// <returns>List of objects of the Type</returns>
		List<Type> FindClassesOfType<T>() where T : class;

		/// <summary>
		/// Find the declaring type within the loaded libraries
		/// </summary>
		/// <param name="T">Type to find</param>
		/// <returns>List of objects of the Type</returns>
		List<Type> FindClassesOfType(Type T);

	}
}
