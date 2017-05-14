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

        public static string ValidateSubstaction(GalaxyModel model, List<string> partOne, string symbol, int nextIndex)
        {
            if (nextIndex < partOne.Count - 1)
            {
                var symbolBaseData = model.GalaxySymbols.Find(item => item.SymbolName.Equals(symbol));
                var nextSymbol = partOne[nextIndex + 1];
                var nextSymbolBaseData = model.GalaxySymbols.Find(item => item.SymbolName.Equals(nextSymbol));

                if (nextSymbolBaseData != null)
                {
                    switch (symbolBaseData.RomanEquivalent)
                    {
                        case 'I':
                            if (nextSymbolBaseData.RomanEquivalent != 'I')
                            {
                                if (nextSymbolBaseData.RomanEquivalent != 'V' && nextSymbolBaseData.RomanEquivalent != 'X')
                                    return string.Format("Can not substract {0} symbol from {1}", symbol, nextSymbol);
                            }
                            break;
                        case 'X':
                            if (nextSymbolBaseData.RomanEquivalent != 'X')
                            {
                                if (nextSymbolBaseData.RomanEquivalent != 'L' && nextSymbolBaseData.RomanEquivalent != 'C')
                                    return string.Format("Can not substract {0} symbol from {1}", symbol, nextSymbol);
                            }
                            break;
                        case 'C':
                            if (nextSymbolBaseData.RomanEquivalent != 'C')
                            {
                                if (nextSymbolBaseData.RomanEquivalent != 'M' || nextSymbolBaseData.RomanEquivalent != 'D')
                                    return string.Format("Can not substract {0} symbol from {1}", symbol, nextSymbol);
                            }
                            break;

                    }
                }

                //if (symbolBaseData != null)
                //{
                //    var romanBaseData = model.RomanSystem.GetRomanCurrencyValue(symbolBaseData.RomanEquivalent);
                //   

                //    var nextSymbolBaseData = model.GalaxySymbols.Find(item => item.SymbolName.Equals(symbol));

                //    var SymbolValue = model.RomanSystem.GetRomanCurrencyValue(symbolBaseData.RomanEquivalent);
                //    var nextSymbolValue = model.RomanSystem.GetRomanCurrencyValue(nextSymbolBaseData.RomanEquivalent);

                //    if (SymbolValue.SymbolValue < nextSymbolValue.SymbolValue)
                //    {
                //        if(SymbolValue.Substract)


                //    }

                //}
            }

            return string.Empty;
        }

        public static string Occurances(GalaxyModel model, List<string> questionStatement, string currentSymbol)
        {

            var symbolBaseData = model.GalaxySymbols.Find(item => item.SymbolName.Equals(currentSymbol));


            int nextSymbolIndex = questionStatement.FindIndex(item => item.Equals(currentSymbol));
            if (nextSymbolIndex < questionStatement.Count - 2)
            {
                var levelTwoSymbol = questionStatement[nextSymbolIndex + 1];
                if (currentSymbol == levelTwoSymbol)
                {
                    if (symbolBaseData != null)
                    {
                        var romanBaseData = model.RomanSystem.GetRomanCurrencyValue(symbolBaseData.RomanEquivalent);
                        if (romanBaseData.Reapat == false)
                            return currentSymbol + " " + Validator.CanNotRepeatMessage;
                    }

                    var levelThreeSymbol = questionStatement[nextSymbolIndex + 2];

                    if (currentSymbol == levelThreeSymbol)
                    {
                        var levelFourSymbol = questionStatement[nextSymbolIndex + 3];

                        if (currentSymbol == levelFourSymbol)
                        {
                            return currentSymbol + " is exceeding repetitions in (" + string.Join(" ", questionStatement) + ")";
                        }

                    }
                }
            }
            return string.Empty;

        }

    }
}
