﻿using System;

namespace Faking.Generators
{
    public class RelayGenerator : IGenerator
    {
        public RelayGenerator(Func<string,Type,bool> predicat, Func<string,Type,object> createInstance)
        {
            this.predicat = predicat;
            this.createInstance = createInstance;
        }

        private Func<string, Type, bool> predicat;

        private Func<string, Type, object> createInstance;

		public bool CanCreate(string name, Type type) => predicat(name, type);

		public object Create(string name, Type type) => this.createInstance(name, type);
    }
}
