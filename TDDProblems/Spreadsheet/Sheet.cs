using System.Collections.Generic;

namespace TDDProblems.Spreadsheet
{
    public class Sheet
    {
        private readonly Dictionary<string,string> lookup = new Dictionary<string, string>();

        public string this[string cell] 
        {
            get
            {
                if (!lookup.ContainsKey(cell))
                    return "";

                int parsedValue;
                return int.TryParse(lookup[cell], out parsedValue) ? lookup[cell].Trim() : lookup[cell];
            }
            set
            {
                lookup[cell] = value;
            }
        }

        public string GetLiteral(string cell)
        {
            return lookup[cell];
        }
    }
}