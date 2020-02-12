using DBManager.Source.TableStructures.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBManager.Source.Cells
{
    internal class CellController
    {
        public KeyCell<T> MakeNewKeyCell<T>(T value, Record containerRecord) => new KeyCell<T>(value, containerRecord);
        
        public Cell<T> MakeNewCell<T>(T value) => new Cell<T>(value);
    }
}
