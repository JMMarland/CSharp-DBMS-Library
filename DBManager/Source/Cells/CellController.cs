using System;
using System.Collections.Generic;
using System.Text;

namespace DBManager.Source.Cells
{
    internal class CellController
    {
        public Cell<T> MakeNewCell<T>(T value) => new Cell<T>(value);
    }
}
