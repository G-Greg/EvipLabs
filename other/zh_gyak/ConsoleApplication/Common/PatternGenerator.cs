using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class PatternGenerator : IBoolSource
    {
        public IEnumerable<bool> GetBools(int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (i % 3 == 0)
                    yield return true;
                else
                    yield return false;
            }
        }
    }
}
