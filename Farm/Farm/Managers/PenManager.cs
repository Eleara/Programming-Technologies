using System;
using Farm.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Managers
{
    class PenManager
    {
        public void CreatePen(Pen pen, DatabaseManager manager)
        {
            string Name = pen.Name;
            manager.ExecuteInstruction($"insert into Pens(Name) values ('{Name}')");
        }

        public void UpdatePen(Pen pen, DatabaseManager manager)
        {
            manager.ExecuteInstruction($"update Pens set Name = '{pen.Name}'");
        }
    }
}
