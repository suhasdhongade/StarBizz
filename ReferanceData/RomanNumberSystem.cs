using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyBizz.ReferanceData
{
    public class RomanNumberSystem
    {
        readonly Dictionary<char, Roman> _Romans;

        public RomanNumberSystem()
        {
            _Romans = new Dictionary<char, Roman>();
            _Romans.Add('I', new Roman { SymbolValue = 1, Reapat = true, Substract = true });
            _Romans.Add('V', new Roman { SymbolValue = 5 });
            _Romans.Add('X', new Roman { SymbolValue = 10, Reapat = true, Substract = true });
            _Romans.Add('L', new Roman { SymbolValue = 50 });
            _Romans.Add('C', new Roman { SymbolValue = 100, Reapat = true, Substract = true });
            _Romans.Add('D', new Roman { SymbolValue = 500 });
            _Romans.Add('M', new Roman { SymbolValue = 1000, Reapat = true, Substract = true });
        }

        public Roman GetRomanCurrencyValue(char key)
        {
            return _Romans[key];
        }

    }

    public class Roman
    {
        public int SymbolValue { get; set; }
        public bool Reapat { get; set; }
        public bool Substract { get; set; }

    }



}
