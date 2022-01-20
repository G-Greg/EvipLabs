using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ZeroGenerator : INumberSequenceSource
    {
        public int n;

        public IEnumerable<int> GenerateNumbers()
        {
            for (int i = 0; i < n; i++)
            {
                yield return 0;
            }
        }
    }
}
