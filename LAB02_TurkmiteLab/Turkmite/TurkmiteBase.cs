using OpenCvSharp;
using LAB02_TurkmiteLab;
using System;

namespace TurkMite
{
    public abstract class TurkmiteBase
    {
        public int x = 100;
        public int y = 100;
        public int direction = 0;  // 0 up, 1 right, 2 down, 3 left
        public abstract int PreferredIterationCount { get; }

        public Mat Image { get; }
        public Mat.Indexer<Vec3b> indexer;

        public TurkmiteBase()
        {
            Image = new Mat(200, 200, MatType.CV_8UC3, new Scalar(0, 0, 0));
            indexer = Image.GetGenericIndexer<Vec3b>();
        }

        readonly private (int x, int y)[] delta = new (int x, int y)[] { (0, -1), (1, 0), (0, 1), (-1, 0) };

        public void Run()
        {
            for (int i = 0; i < PreferredIterationCount; i++)
            {
                Vec3b currentColor = indexer[y, x];

                (int dd, Vec3b nc) = Step(currentColor);
                direction += dd;
                indexer[y, x] = nc;

                direction = (direction + 4) % 4;

                x += delta[direction].x;
                y += delta[direction].y;

                x = Math.Max(0, Math.Min(x, Image.Cols - 1));
                y = Math.Max(0, Math.Min(y, Image.Rows - 1));
            }
        }

        public abstract (int deltaDirection, Vec3b NewColor) Step(Vec3b currentColor);
    }
}
