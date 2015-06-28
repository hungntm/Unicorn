﻿using System;

namespace Unicorn.Configuration
{
	/// <summary>
	/// Represents a Unicorn configuration. A configuration is basically an instance of a DI container.
	/// </summary>
	public interface IConfiguration
	{
		/// <summary>
		/// The name of this configuration, used for display purposes
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Resolves an instance of a type from a generic parameter. This should be an explicitly registered type.
		/// </summary>
		T Resolve<T>() where T : class;

		/// <summary>
		/// Resolves an instance of a type from a Type instance
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		object Resolve(Type type);

		/// <summary>
		/// Registers an instance of a dependency type.
		/// </summary>
		/// <param name="type">Type to register the instance for</param>
		/// <param name="factory">Factory method to create the instance when it is needed</param>
		/// <param name="singleInstance">If true, it's a singleton. If false, new instance is created each time. Singleton is preferable for performance.</param>
		void Register(Type type, Func<object> factory, bool singleInstance);
	}
}
