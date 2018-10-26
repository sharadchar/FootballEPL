using FootballEPL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEPL.Mapper
{
    public interface IBaseMapper
    {
        List<FootballTeam> Map(List<string> dataRead);
    }
}
