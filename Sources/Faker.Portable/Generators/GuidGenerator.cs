﻿namespace Faking.Generators
{
	using System;

	/// <summary>
	/// A GUID generator.
	/// </summary>
	public class GuidGenerator : IGenerator
	{
		public bool CanCreate(string name, Type type) => type == typeof(Guid);

		public object Create(string name, Type type) => Guid.NewGuid();
	}
}
