using OpenCvSharp;
using LAB02_TurkmiteLab;

namespace TurkMite
{
    class Program
    {
        static void Main()
        {
            var o_turkmite = new OriginalTurkmite();
            var three_turkmite = new ThreeColorTurkmite();

            o_turkmite.Run();
            three_turkmite.Run();

            Cv2.ImShow("TurkMiteOriginal", o_turkmite.Image);
            Cv2.ImShow("TurkMiteThreeColor", three_turkmite.Image);
            Cv2.WaitKey();
        }
    }
}
