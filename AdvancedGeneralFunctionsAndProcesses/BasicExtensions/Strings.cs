using System.Globalization;
namespace CommonRoslynNetStandardHelpers.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
public static class Strings
{
    extension(string payLoad)
    {
        public string BackSpaceRemoveEnding0s()
        {
            string output = payLoad.TrimEnd(['0']);
            return output;
        }

        //private static string _monthReplace = "";
        public List<string> CommaDelimitedList()
        {
            return payLoad.Split(',').ToList(); //comma alone.
        }
        public bool INumeric => int.TryParse(payLoad, out _);
        
        public string TextWithSpaces()
        {
            string newText = payLoad;
            int x = 0;
            string finals = "";
            foreach (var thisChar in newText)
            {
                bool rets = int.TryParse(thisChar.ToString(), out _);
                if (char.IsLower(thisChar) == false && x > 0 && rets == false)
                {
                    finals += " " + thisChar;
                }
                else
                {
                    finals += thisChar;
                }
                x++;
            }
            return finals;
        }
        
        public bool ContainNumber => payLoad.Where(xx => char.IsNumber(xx) == true).Any();
        
        public string ToTitleCase(bool replaceUnderstores = true)
        {
            if (replaceUnderstores)
            {
                payLoad = payLoad.Replace("_", " ");
            }
            TextInfo currentTextInfo = CultureInfo.InvariantCulture.TextInfo;
            string output = currentTextInfo.ToTitleCase(payLoad);
            return output;
        }
        public string ConvertCase(bool doAll = true)
        {
            string tempStr = "";
            bool isSpaceOrDot = false;
            if (doAll)
            {
                var loopTo = payLoad.Length - 1;
                for (int i = 0; i <= loopTo; i++)
                {
                    if (payLoad[i].ToString() != " " & payLoad[i].ToString() != ".")
                    {
                        if (i == 0 | isSpaceOrDot)
                        {
                            tempStr += char.ToUpper(payLoad[i]);
                            isSpaceOrDot = false;
                        }
                        else
                        {
                            tempStr += char.ToLower(payLoad[i]);
                        }
                    }
                    else
                    {
                        isSpaceOrDot = true;
                        tempStr += payLoad[i];
                    }
                }
            }
            else
            {
                var loopTo1 = payLoad.Length - 1;
                for (int i = 0; i <= loopTo1; i++)
                {
                    if (payLoad[i].ToString() != " " & payLoad[i].ToString() != ".")
                    {
                        if (isSpaceOrDot)
                        {
                            tempStr += char.ToUpper(payLoad[i]);
                            isSpaceOrDot = false;
                        }
                        else if (i == 0)
                        {
                            tempStr += char.ToUpper(payLoad[0]);
                        }
                        else
                        {
                            tempStr += char.ToLower(payLoad[i]);
                        }
                    }
                    else
                    {
                        if (payLoad[i].ToString() != " ")
                        {
                            isSpaceOrDot = !isSpaceOrDot;
                        }
                        tempStr += payLoad[i];
                    }
                }
            }
            return tempStr;
        }
    }
}