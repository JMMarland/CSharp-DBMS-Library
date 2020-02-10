using System;
using System.Collections.Generic;
using System.Text;

namespace DBManager.Source.Cells
{
    internal interface ICell
    {
        ICell Duplicate();
    }
}
