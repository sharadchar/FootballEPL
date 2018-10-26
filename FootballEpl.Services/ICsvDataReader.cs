using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEPL.Services
{
    public interface ICsvDataReader
    {
        List<string> GetData();
    }
}
