using System;
using TurkMite;
using OpenCvSharp;

namespace LAB02_TurkmiteLab
{
    public class ThreeColorTurkmite : TurkmiteBase
    {   
        readonly public Vec3b black = new Vec3b(0, 0, 0);
        readonly public Vec3b red = new Vec3b(0, 0, 255);
        readonly public Vec3b yellow = new Vec3b(0, 255, 255);
        public override int PreferredIterationCount => 500000;
        private int counter = 0;

            
        public override (int deltaDirection, Vec3b NewColor) Step(Vec3b currentColor)
        {

            if (currentColor == black)
            {
                counter++;
                if (counter % 2 == 0)
                    return (-1, red);
                else
                    return(-1, yellow);

            }
            else if (currentColor == red)
                return (-1, yellow);
            
            else
                return (1, black);
        }
    }
}
