using DBManager.Source.Cells;
using DBManager.Source.Tables;
using DBManager.Source.TableStructures.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBManager.Source.TableStructures.Attributes
{
    internal class Attribute<T> : IAttribute
    {
        private List<Cell<T>> _cells = new List<Cell<T>>();
        private Table _containerTable;
        private SchemaOwner _owner;

        public SchemaOwner Owner => _owner;

        public Table ContainerTable => _containerTable;

        public int Count => _cells.Count;

        public bool IsKeyAttribute => false;

        public bool IsPrimaryKey => false;

        public Attribute(Table containerTable, SchemaOwner owner)
        {
            _containerTable = containerTable;
            _owner = owner;
        }

        public void Add(Cell<T> cell) => _cells.Add(cell);

        public void Insert(int index, Cell<T> cell) => _cells.Insert(index, cell);

        public Cell<T> GetAt(int index) => _cells[index];

        public void RemoveAt(int index) => _cells.RemoveAt(index);

        public void Remove(Cell<T> cell) => _cells.Remove(cell);

        public void Sort() => _cells.Sort();
    }
}
