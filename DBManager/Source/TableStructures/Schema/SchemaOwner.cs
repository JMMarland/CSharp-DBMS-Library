using System;
using System.Collections.Generic;
using System.Text;

namespace DBManager.Source.TableStructures.Schema
{
    internal class SchemaOwner
    {
        public string Name => _name;
        public Type Type => _type;
        
        private string _name = null;
        private Type _type = null;

        private bool _isSet = false;

        internal void Initialise<T>(string name)
        {
            if (_isSet)
            {
                // Throw exception here.
            }

            _name = name;
            _type = typeof(T);
            _isSet = true;
        }

        internal void ResetName(string name)
        {
            if (!_isSet)
            {
                // Throw exception here.
            }

            _name = name;
        }

        internal void ResetType<T>()
        {
            if (!_isSet)
            {
                // Throw exception here.
            }

            _type = typeof(T);
        }
    }
}
