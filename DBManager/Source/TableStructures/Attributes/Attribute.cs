using DBManager.Source.Cells;
using DBManager.Source.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBManager.Source.TableStructures.Attributes
{
    internal class Attribute<T> : IAttribute
    {
        private List<Cell<T>> _cells = new List<Cell<T>>();
        private Table _containerTable;

        public Table ContainerTable => _containerTable;

        public int Count => _cells.Count;

        public bool IsKeyAttribute => false;

        public bool IsPrimaryKey => false;

        public Attribute(Table containerTable) => _containerTable = containerTable;

        public void Add(Cell<T> cell) => _cells.Add(cell);

        public void Insert(int index, Cell<T> cell) => _cells.Insert(index, cell);

        public Cell<T> GetAt(int index) => _cells[index];

        public void RemoveAt(int index) => _cells.RemoveAt(index);

        public void Remove(Cell<T> cell) => _cells.Remove(cell);

        public void Sort() => _cells.Sort();
    }
}
