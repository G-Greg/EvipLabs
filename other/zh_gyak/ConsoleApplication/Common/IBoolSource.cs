using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IBoolSource
    {
        public IEnumerable<bool> GetBools(int n);
    }
}
