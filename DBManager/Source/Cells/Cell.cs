using System;
using System.Collections.Generic;
using System.Text;

namespace DBManager.Source.Cells
{
    internal class Cell<T>
    {
        public T Value
        {
            get => _value;
            set => _value = value;
        }

        private T _value;

        internal Cell(T value) => _value = value;
    }
}
