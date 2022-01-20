using System;
using TurkMite;
using OpenCvSharp;

namespace LAB02_TurkmiteLab
{
    public class OriginalTurkmite : TurkmiteBase
    {

        readonly public Vec3b black = new Vec3b(0, 0, 0);
        readonly public Vec3b white = new Vec3b(255, 255, 255);
        public override int PreferredIterationCount => 13000;


        public override (int deltaDirection, Vec3b NewColor) Step(Vec3b currentColor)
        {
            if (currentColor == black)
            {
                return (1, white);
            }
            else
            {
                return (-1, black);
            }
        }
    }
}
