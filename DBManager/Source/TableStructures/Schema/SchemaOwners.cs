using System;
using System.Collections.Generic;
using System.Text;

namespace DBManager.Source.TableStructures.Schema
{
    internal class SchemaOwners
    {
        public int Length => _owners.Count;
        
        private List<SchemaOwner> _owners = new List<SchemaOwner>();
        private Dictionary<string, SchemaOwner> _ownerMap = new Dictionary<string, SchemaOwner>();
        
        public void AddOwner<T>(string name)
        {
            SchemaOwner newOwner = new SchemaOwner(this);
            newOwner.Initialise<T>(name);
            StoreOwner(newOwner);
        }

        public SchemaOwner GetOwner(string name) => _ownerMap[name];

        public string GetOwnerName(int index) => _owners[index].Name;

        public Type GetOwnerTypeByIndex(int index) => _owners[index].Type;

        public Type GetOwnerType(string name) => _ownerMap[name].Type;

        public void RemoveOwnerByIndex(int index) => ReleaseOwner(_owners[index]);

        public void RemoveOwner(string name) => ReleaseOwner(_ownerMap[name]);

        private void StoreOwner(SchemaOwner owner)
        {
            _owners.Add(owner);
            _ownerMap.Add(owner.Name, owner);
        }

        private void ReleaseOwner(SchemaOwner owner)
        {
            _ownerMap.Remove(owner.Name);
            _owners.Remove(owner);
        }
    }
}
