using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEPL.Model
{
    public class DataHub
    {
        IDataHub _obj;
        public DataHub(IDataHub obj)
        {
            _obj = obj;
        }
        public List<string> GetData()
        {
            return _obj.GetData();
        }

    }
}
