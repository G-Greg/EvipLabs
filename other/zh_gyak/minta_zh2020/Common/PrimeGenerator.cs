using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class PrimeGenerator : INumberSequenceSource
    {
        private int n;

        public PrimeGenerator(int N) 
        {
            n = N;
        }

        public IEnumerable<int> GenerateNumbers()
        {
            int db = 0;
            for (int i = 0; db < n; i++)
            {
                if (IsPrime(i))
                {
                    db++;
                    yield return i;
                }
            }
        }

        private bool IsPrime(int x)
        {
            if (x <= 1) return false;
            if (x == 2) return true;
            if (x % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(x));

            for (int i = 3; i <= boundary; i += 2)
                if (x % i == 0)
                    return false;

            return true;
        }
    }
}
