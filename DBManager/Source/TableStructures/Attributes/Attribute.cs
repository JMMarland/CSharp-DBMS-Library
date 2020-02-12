using DBManager.Source.Cells;
using DBManager.Source.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBManager.Source.TableStructures.Attributes
{
    internal class Attribute : IAttribute
    {
        private List<ICell> _cells = new List<ICell>();
        private Table _containerTable;

        public Table ContainerTable => _containerTable;

        public int Count => _cells.Count;

        public Attribute(Table containerTable) => _containerTable = containerTable;

        public void Add(ICell cell) => _cells.Add(cell);

        public void Insert(int index, ICell cell) => _cells.Insert(index, cell);

        public ICell GetAt(int index) => _cells[index];

        public void RemoveAt(int index) => _cells.RemoveAt(index);

        public void Remove(ICell cell) => _cells.Remove(cell);

        public void Sort() => _cells.Sort();
    }
}
