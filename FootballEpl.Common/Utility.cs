using System.Collections.Generic;
using System.Linq;

namespace FootballEPL.Common
{
    public static class Utility
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
            {
                return true;
            }
            
            return !enumerable.Any();
        }
    }
}
