using GalaxyBizz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyBizz.Processor
{
    internal class Validator
    {
        public static string NotLegalValue = "I have no idea what you are talking about";
        public static string CanNotRepeatMessage = "Symbol Can not be repeated";
        public static string ExceedingRepetitions = " is exceeding repetitions";

        public static string ValidateSymbol(GalaxyModel model, List<string> partOne, string symbol, int nextIndex)
        {
            if (nextIndex < partOne.Count - 1)
            {
                if (symbol == partOne[nextIndex + 1])
                {
                    var symbolBaseData = model.GalaxySymbols.Find(item => item.SymbolName.Equals(symbol));
                    var romanBaseData = model.RomanSystem.GetRomanCurrencyValue(symbolBaseData.RomanEquivalent);

                    if (romanBaseData.Reapat == false)
                        return Validator.CanNotRepeatMessage;

                }
            }

            return string.Empty;
        }

        public static string Occurances(GalaxyModel model, List<string> symbolStatement, string currentSymbol)
        {

            int nextSymbolIndex = symbolStatement.FindIndex(item => item.Equals(currentSymbol));
            if (nextSymbolIndex < symbolStatement.Count - 2)
            {
                var levelTwoSymbol = symbolStatement[nextSymbolIndex + 1];
                if (currentSymbol == levelTwoSymbol)
                {
                    var levelThreeSymbol = symbolStatement[nextSymbolIndex + 2];

                    if (currentSymbol == levelThreeSymbol)
                    {
                        var levelFourSymbol = symbolStatement[nextSymbolIndex + 3];

                        if (currentSymbol == levelFourSymbol)
                        {
                            return currentSymbol + " is exceeding repetitions in (" + string.Join(" ", symbolStatement) + ")";
                        }

                    }
                }
            }
            return string.Empty;

        }

    }
}
