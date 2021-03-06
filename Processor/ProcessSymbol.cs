﻿using GalaxyBizz.Model;
using GalaxyBizz.ReferanceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyBizz.Processor
{
    class ProcessSymbol : IProcessor
    {
        public ProcessSymbol()
        {
        }
        /// <summary>
        /// Processes Symbols and adds to Model object
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userEnteredLine"></param>
        /// <param name="inputExtract"></param>
        /// <returns></returns>
        public dynamic Process(GalaxyModel model, string userEnteredLine, List<string> inputExtract)
        {
            var roman = model.RomanSystem.GetRomanCurrencyValue(inputExtract[1][0]);

            var result = model.GalaxySymbols.Exists(item => item.SymbolName.Equals(inputExtract[0]));
            if (!result)
            {
                model.GalaxySymbols.Add(new GalaxySymbol { SymbolName = inputExtract[0], RomanEquivalent = inputExtract[1][0], SymbolValue = roman.SymbolValue });
            }

            return null;
        }

    }
}
