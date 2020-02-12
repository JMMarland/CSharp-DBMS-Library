using DBManager.Source.TableStructures.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBManager.Source.Cells
{
    internal class KeyCell<T> : Cell<T>
    {
        private Record _containerRecord;

        public Record ContainerRecord => _containerRecord;

        internal KeyCell(T value, Record containerRecord) : base(value) => _containerRecord = containerRecord;
    }
}
