using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Linq2XmlSvgLab
{
    public class Solutions
    {
        private readonly XElement root;
        private readonly XNamespace ns = "http://www.w3.org/2000/svg";

        public Solutions(string svgFileName)
        {
            root = XElement.Load(svgFileName);
        }

        private IEnumerable<XElement> Rects => root.Descendants(ns + "rect");
        private IEnumerable<XElement> Texts => root.Descendants(ns + "text");

        #region A laborfeladatok megoldásai
        // Minden téglalap (rect elem) felsorolása
        internal IEnumerable<XElement> GetAllRectangles()
        {
            return Rects;
        }

        // Hány olyan szöveg van, aminek ez a tartalma?
        internal int CountTextsWithValue(string v)
        {
            return Texts.Where(t => t.Value.Equals(v)).Count();
        }

        #region Téglalap szűrések
        // Minden olyan rect elem felsorolása, aminek a kerete adott vastagságú.
        //  A keretvastagság (más beállításokkal együtt) a "style" szöveges attribútumban
        //  szerepel, pl. "stroke-width:2".
        internal IEnumerable<XElement> GetRectanglesWithStrokeWidth(int width)
        {
            return Rects.Where(r => r.Attribute("style").Value.Contains($"stroke-width:{width}"));
        }

        // Adott x koordinátájú téglalapok színének visszaadása szövegesen (pl. piros esetén "#ff0000").
        internal IEnumerable<string> GetColorOfRectanglesWithGivenX(double x)
        {
            return Rects.Where(r => double.Parse(r.Attribute("x").Value, CultureInfo.InvariantCulture).Equals(x)).Select(r =>r.GetFillColor());
        }

        // Az adott ID-jú téglalap pozíciójának (x,y) visszaadása.
        internal (double X, double Y) GetRectangleLocationById(string id)
        {
            var search = Rects.Where(r => r.Attribute("id").Value.Equals(id));
            return ExtensionMethods.GetLocation(search.First());
        }

        // A legnagyobb y értékkel rendezkező téglalap ID-jának visszaadása.
        internal string GetIdOfRectangeWithLargestY()
        {
            double max = Rects.Max(r => double.Parse(r.Attribute("y").Value, CultureInfo.InvariantCulture));
            var result = Rects.Where(r => double.Parse(r.Attribute("y").Value, CultureInfo.InvariantCulture).Equals(max));          
            return ExtensionMethods.GetId(result.First());
        }

        // Minden olyan téglalap ID-jának felsorolása, ami legalább kétszer olyan magas mint széles.
        internal IEnumerable<string> GetRectanglesAtLeastTwiceAsHighAsWide()
        {
            return Rects.Where(r => IsAtLeastTwiceAsHighAsWide(r)).Select(r => r.GetId().ToString());
        }
        #endregion

        #region Group kezelés
        // Adott ID-jú group-ban lévő téglalapok színét sorolja fel.
        internal IEnumerable<string> GetColorsOfRectsInGroup(string id)
        {
            return Rects.Where(r => r.Parent.GetId().Equals(id)).Select(r => r.GetFillColor());
        }
        #endregion

        #region Téglalapok és szövegek viszonya
        // Minden olyan rect elem felsorolása, amiben van bármilyen szöveg.
        //  (Olyan rect, aminek a területén van egy szövegnek a kezdőpontja (x,y).)
        internal IEnumerable<XElement> GetRectanglesWithTextInside()
        {
            return Rects.Where(r => Texts.Any(t => IsInside(r, ExtensionMethods.GetLocation(t))));
        }

        // Adott színű téglalapon belüli szöveg visszaadása.
        //  Feltételezhetjük, hogy csak egyetlen ilyen színű téglalap van és abban egyetlen
        //  szöveg szerepel.
        internal string GetSingleTextInSingleRectangleWithColor(string color)
        {
            var result = Texts.Where(t => Rects.Any(r => r.GetFillColor().Equals(color) && IsInside(r,ExtensionMethods.GetLocation(t))));
            if (result.Count() > 0)
                return result.First().Value;
            else
                return null;
        }

        // Minden téglalapon kívüli szöveg felsorolása.
        internal IEnumerable<string> GetTextsOutsideRectangles()
        {
            return Texts.Where(t => NotInside(t)).Select(t => t.Value);
        }
        #endregion

        #region Téglalapok egymáshoz képesti viszonya
        // Az egyetlen olyan téglalap pár visszaadása (id attribútumuk értékével), amik legfeljebb
        //  adott távolságra vannak egymástól.
        // (Itt nem gond, ha foreach-et használsz, de jobb, ha nem.)
        internal (string id1, string id2) GetSingleRectanglePairCloseToEachOther(double maxDistance)
        {

            foreach (var item1 in Rects)
            {
                foreach (var item2 in Rects)
                {
                    if (!item1.GetId().Equals(item2.GetId()))
                    {
                        if (AreClose(item1, item2, maxDistance))
                        {
                            return (item1.GetId(),item2.GetId());
                        }
                    }
                }
            }
            return (string.Empty, string.Empty);
            
        }
        #endregion

        #region ILookup és Aggregate használata
        // Egy ILookup visszaadása, mely minden szöveghez megadja az ilyen szöveget tartalmazó
        //  téglalapok színét. (Az ILookup-ban csak azok a szövegek szerepelnek kulcsként, amikhez van
        //  is téglalap.)
        internal ILookup<string, string> GetBoundingRectangleColorListForEveryText()
        {

            var hope = Texts.SelectMany(t => Rects.Where(r => IsInside(r, ExtensionMethods.GetLocation(t))), (a,b) => new { text = a.Value, szin2 = b.GetFillColor()}).ToLookup(x => x.text, z => z.szin2);

            return hope;
        }

        // Minden téglalapon belüli szöveg ABC sorrendben egymás mögé fűzése, ", "-zel elválasztva.
        //  (Az "OrderBy(s=>s)" rendezése most elegendő lesz.)
        // Használd az Aggregate Linq metódust egy StringBuilderrel az összegyűjtéshez!
        internal string ConcatenateOrderedTextsInsideRectangles()
        {
            var res = Texts.Where(t => !NotInside(t)).Select(t => t.Value).ToList().OrderBy(s => s);
            
            return res.Aggregate((a,b) => a+", "+b);
        }

        // Az adott kontúrszélességű (stroke width) téglalapok által együttesen lefedett terület
        //  szélességét és magasságát adja meg
        internal (double Width, double Height) GetEffectiveWidthAndHeight(int strokeThickness)
        {
            var rects = GetRectanglesWithStrokeWidth(strokeThickness);

            var x_max = rects.Max(r => r.GetX() + r.GetWidth());
            var x_min = rects.Min(r => r.GetX());
            var y_max = rects.Max(r => r.GetY() + r.GetHeight());
            var y_min = rects.Min(r => r.GetY());

            return (x_max-x_min, y_max-y_min);

        }
        #endregion
        #endregion

        #region Segédmetódusok
        // Ezeknek a metódusoknak az implementálása nem kötelező, csak ajánlás.
        //  Ezekre a funkciókra lehet, hogy többször is szükséged lesz a feladatok
        //  megoldása során, így érdemes őket kiszervezni külön metódusokba.
        class Boundary
        {
            public double Left = double.MaxValue;
            public double Top = double.MaxValue;
            public double Right = double.MinValue;
            public double Bottom = double.MinValue;

            public double Width => Right - Left + 1;
            public double Height => Bottom - Top + 1;

            public void UpdateToCoverRect(XElement rect)
            {
                Left = Math.Min(Left, rect.GetX());
                Right = Math.Max(Right, rect.GetX() + rect.GetWidth() - 1);
                Top = Math.Min(Top, rect.GetY());
                Bottom = Math.Max(Bottom, rect.GetY() + rect.GetHeight() - 1);
            }
        }

        // A kapott rect magassága legalább kétszer akkora, mint a szélessége?
        private bool IsAtLeastTwiceAsHighAsWide(XElement rect)
        {
            if (rect.GetHeight() >= rect.GetWidth()*2)
                return true;
            return false;
        }

        // A this.Rects attribútumból felsorolja azokat az elemeket, melyek kitöltési színe a megadott szín.
        private IEnumerable<XElement> GetRectanglesWithColor(string color)
        {
            return null;
        }

        // Igaz, ha a megadott pont a rect-en belül van.
        //  Használhatod a lentebb megírandó GetRectBoundaries-t.
        private bool IsInside(XElement rect, (double x, double y) p)
        {

            var r = GetRectBoundaries(rect);
            if (p.x > r.left && p.x < r.right && p.y > r.bottom && p.y < r.top)
                return true;
            return false;

        }

        //Egy text-ről megállapítja, téglalapon kivül van-e.
        private bool NotInside(XElement text)
        {
            var texts = Texts.Where(t => Rects.Any(r => IsInside(r, ExtensionMethods.GetLocation(t))));
            return !texts.Contains(text);

        }

        // Igaz, ha a két téglalap (r1 és r2) között a távolság egyik tengely
        //  mentén sem nagyobb, mint maxDistance.
        private bool AreClose(XElement r1, XElement r2, double maxDistance)
        {
            var rect1_loc = r1.GetLocation();
            var rect1_maxloc = r1.GetMaxLocation();

            var rect2_loc = r2.GetLocation();
            var rect2_maxloc = r2.GetMaxLocation();

            bool x = false;
            bool y = false;

            //item1 == x, item2 == y 
            if (Math.Abs(rect1_loc.Item1 - rect2_loc.Item1) <= maxDistance 
                || Math.Abs(rect1_loc.Item1 - rect2_maxloc.Item1) <= maxDistance 
                || Math.Abs(rect2_loc.Item1 - rect1_maxloc.Item1) <= maxDistance
                || Math.Abs(rect1_maxloc.Item1 - rect2_maxloc.Item1) <= maxDistance)
            {
                x = true;
            }

            if (Math.Abs(rect1_loc.Item2 - rect2_loc.Item2) <= maxDistance
                || Math.Abs(rect1_loc.Item2 - rect2_maxloc.Item2) <= maxDistance
                || Math.Abs(rect2_loc.Item2 - rect1_maxloc.Item2) <= maxDistance
                || Math.Abs(rect1_maxloc.Item2 - rect2_maxloc.Item2) <= maxDistance)
            {
                y = true;
            }

            return (x && y) ?  true : false;

        }

        // Visszaadja egy téglalap határait. Figyelem! Ha left==2 és width==3,
        //  akkor right==4 és nem 5! Hasonlóan a magasságra is.
        private (double left,double top,double right,double bottom) GetRectBoundaries(XElement r)
        {
            double left = r.GetX();
            double top = r.GetY() + r.GetHeight()-1;

            double jobb = r.GetX() + r.GetWidth()-1;
            double also = r.GetY();

            return (left, top, jobb, also);
        }
        #endregion
    }
}
