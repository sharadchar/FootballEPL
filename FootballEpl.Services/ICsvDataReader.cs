using System.Collections.Generic;

namespace FootballEPL.Services
{
    public interface ICsvDataReader
    {
        List<string> GetData();
    }
}
