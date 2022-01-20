using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class SimpleGenerator : IBoolSource
    {
        //property
        public bool ValueToGenerator { get; set; }

        public IEnumerable<bool> GetBools(int n)
        {
            for (int i = 0; i < n; i++)
            {
                ValueToGenerator = true;
                yield return ValueToGenerator;
            }
        }
    }
}
