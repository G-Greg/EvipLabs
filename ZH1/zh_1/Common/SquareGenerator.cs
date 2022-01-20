using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class SquareGenerator : ITextSequenceSource
    {
        public int n { get; set; }
        public SquareGenerator(int N)
        {
            n = N;
        }
        public IEnumerable<string> GenerateTexts()
        {
            for (int i = 1; i <= n; i++)
            {
                yield return $"A(z) {i*i} négyzetszám";
            }
        }
    }
}
