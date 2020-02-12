using DBManager.Source.Cells;
using DBManager.Source.Tables;
using DBManager.Source.UtilityStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBManager.Source.TableStructures.Records
{
    internal class Record
    {
        private List<ICell> _cells = new List<ICell>();
        private TwoWayMap<string, ICell> _cellMap = new TwoWayMap<string, ICell>();

        private Table _containerTable;

        public Table ContainerTable => _containerTable;

        public int Length => _cells.Count;

        public Record(Table containerTable) => _containerTable = containerTable;

        private void CheckIfHeadingAlreadyExists(string heading)
        {
            if (!_cellMap.ContainsKey(heading))
                return;
            throw new NotImplementedException();
        }

        public void Add(string heading, ICell cell)
        {
            CheckIfHeadingAlreadyExists(heading);

            _cells.Add(cell);
            _cellMap.Add(heading, cell);
        }

        public void Insert(int index, string heading, ICell cell)
        {
            CheckIfHeadingAlreadyExists(heading);

            _cells.Insert(index, cell);
            _cellMap.Add(heading, cell);
        }

        public ICell Get(string heading) => _cellMap.Get(heading);

        public ICell GetAt(int index) => _cells[index];

        public void Remove(string heading) => ReleaseCell(_cellMap.Get(heading));

        public void RemoveAt(int index) => ReleaseCell(_cells[index]);

        private void ReleaseCell(ICell cell)
        {
            _cells.Remove(cell);
            _cellMap.RemoveByValue(cell);
        }
    }
}
