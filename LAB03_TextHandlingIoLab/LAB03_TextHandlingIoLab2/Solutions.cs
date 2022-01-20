using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LAB03_TextHandlingIoLab2
{
    class Solutions
    {
        #region Examples and helper
        internal bool MatchingExample()
        {
            var regex = new Regex(@"<.+>");
            Match m = regex.Match(@"<valami>");
            return m.Success;   // returns true
        }

        internal string[] CollectingMatchesExample()
        {
            // Returns "valami", "még valami" (anything except ">" between "<" and ">".
            return Collect(@"<valami> és <még valami>", @"<[^>]+>").ToArray();
        }

        private IEnumerable<string> Collect(string text, string regex)
        {
            var re = new Regex(regex);
            var matches = re.Matches(text);
            foreach (Match match in matches)
                yield return match.Captures[0].Value;
        }
        #endregion

        #region Email
        internal bool IsEmailAddress(string v)
        {
            var regex = new Regex(@"([a-zA-Z.]+)@([a-zA-z.]+)(\w)");
            Match m = regex.Match(v);
            return m.Success;   // returns true
        }

        internal string[] CollectEmailAddresses(string s)
        {
            return Collect(s, @"([a-zA-Z.]+)@([a-zA-z.]+)(\w)").ToArray();
        }
        #endregion

        #region Phone numbers
        internal bool IsPhoneNumber(string v)
        {
            var regex = new Regex(@"(^\+[0-9]{1,2}-?[0-9]{2,3}-?[0-9]{2,3}-?[0-9]{4}$)");
            Match m = regex.Match(v);
            return m.Success;   // returns true
        }

        internal string[] CollectPhoneNumbers(string text)
        {
            return Collect(text, @"([+][0-9-]+)|([0-9]){11}").ToArray();
        }

        internal bool IsHungarianMobilePhoneNumber(string v)
        {
            var regex = new Regex(@"([+][0-9-]{2}[^-][0-9-]{8,12})");
            Match m = regex.Match(v);
            return m.Success;   // returns true
        }
        #endregion

        #region MusicBox
        internal bool IsInsideMusicBox(string text)
        {
            var regex = new Regex(@"(.*)(dó|ré|mi|fá|szó|lá|ti)(.*)");
            Match m = regex.Match(text);
            return m.Success;   // returns true
        }

        internal string[] CollectWhatsInsideMusicBox(string text)
        {
            return Collect(text, @"(dó|ré|mi|fá|szó|lá|ti)\w*").ToArray();
        }

        internal IEnumerable<char> HightlightNotesInMusicBox(string text)
        {
            var regex = new Regex(@"(dó|ré|mi|fá|szó|lá|ti)");
            string mit = regex.Match(text).Groups[0].Value;
            return regex.Replace(text, "*" + mit + "*");
        }
        #endregion

        #region PlusCode
        internal bool IsPlusCode(string text)
        {
            var regex = new Regex(@"([A-Z2-9]{4,8})\+([A-Z2-9]{2})");
            Match m = regex.Match(text);
            return m.Success;   // returns true
        }

        internal bool IsPlusCodeInBudapest(string text)
        {
            var regex = new Regex(@"([A-Z2-9]{4,8})\+([A-Z2-9]{2})([\s]\w*)");
            Match m = regex.Match(text);
            return m.Success;   // returns true
        }

        internal string[] CollectFullPlusCodes(string text)
        {
            return Collect(text, @"([RVWXJMPQCFGH23456789]{8}\+[RVWXJMPQCFGH23456789]{2,3})").ToArray();
        }

        #endregion

        #region Date
        /// <summary>
        /// Helper method to extract dates (as strings) from a string.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        internal string[] CollectDates(string text)
        {
            return Collect(text, @"((\d{1,4})\W(([0][0-9])|[1][0-2])\W(([0,2][0-9])|[3][0-1]))").ToArray();
        }

        /// <summary>
        /// Helper method to extract the substrings of a string which look like a date.
        /// </summary>
        /// <param name="text">The original string</param>
        /// <returns>IEnumerable of the "looks like a date" substrings.</returns>
        private IEnumerable<string> EnumerateDates(string text)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
