using DBManager.Source.TableStructures.Attributes;
using DBManager.Source.TableStructures.Records;
using DBManager.Source.UtilityStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBManager.Source.TableStructures.Schema
{
    internal class SchemaAttributeContainer
    {
        private List<IAttribute> _attributes = new List<IAttribute>();
        private Dictionary<SchemaOwner, IAttribute> _attributeMap = new Dictionary<SchemaOwner, IAttribute>();
        private SchemaOwners _owners;

        public SchemaAttributeContainer(SchemaOwners owners) => _owners = owners;

        public int Count => _attributes.Count;

        public void Add(IAttribute attribute) => _attributes.Add(attribute);

        public void Insert(int index, IAttribute attribute) => _attributes.Insert(index, attribute);

        public IAttribute GetAt(int index) => _attributes[index];

        public IAttribute Get(string name) => _attributeMap[_owners.GetOwner(name)];

        public bool Remove(IAttribute attribute) => _attributes.Remove(attribute);

        public void RemoveAt(int index) => _attributes.RemoveAt(index);
    }
}
