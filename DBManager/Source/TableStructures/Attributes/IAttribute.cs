using System;
using System.Collections.Generic;
using System.Text;

namespace DBManager.Source.TableStructures.Attributes
{
    internal interface IAttribute
    {
        bool IsKeyAttribute { get; }

        bool IsPrimaryKey { get; }
    }
}
