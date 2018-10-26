using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEPL.Model
{
    public interface IDataHub
    {
        List<string> GetData();
    }
}
