using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyBizz.ReferanceData
{
    public class RomanNumberSystem
    {
        Dictionary<char, int> RomanNumarals;
       
        public RomanNumberSystem()
        {
            RomanNumarals = new Dictionary<char, int>();

            RomanNumarals.Add('I', 1);
            RomanNumarals.Add('V', 5);
            RomanNumarals.Add('X', 10);
            RomanNumarals.Add('L', 50);
            RomanNumarals.Add('C', 100);
            RomanNumarals.Add('D', 500);
            RomanNumarals.Add('M', 1000);
        }

        public int GetRomanCurrencyValue(char key)
        {
            return RomanNumarals[key];
        }

    }
}
