using GalaxyBizz.Model;
using GalaxyBizz.ReferanceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GalaxyBizz.Processor
{
    class ProcessMetal : IProcessor
    {
        public dynamic Process(GalaxyModel model, string userEnteredLine, List<string> inputExtract)
        {
            List<double> metalValue = new List<double>();
            var symbolStatement = Regex.Split(inputExtract[0], " ").ToList();
            string metalName = string.Empty;
            string message = string.Empty;
            for (int i = 0; i < symbolStatement.Count; i++)
            {
                var symbol = symbolStatement[i];

                message = Validator.Occurances(model, symbolStatement, symbol);
                if (!string.IsNullOrEmpty(message))
                    return message;

                message = Validator.ValidateSubstaction(model, symbolStatement, symbol, i);
                if (!string.IsNullOrEmpty(message))
                    return message;

                var result = model.GalaxySymbols.Exists(item => item.SymbolName.Equals(symbol));
                if (result)
                {
                    metalValue.Add(model.GalaxySymbols.Where(item => item.SymbolName.Equals(symbol)).Select(item => item.SymbolValue).FirstOrDefault());
                }
                else
                {
                    metalName = symbol;
                }
            }

            for (int i = 0; i < metalValue.Count; i++)
            {
                if (i == metalValue.Count - 1)
                    break;

                double currentValue = metalValue[i];
                double nextValue = metalValue[i + 1];

                if (currentValue < nextValue)
                {
                    metalValue[i] = metalValue[i] * (-1);
                }

            }
            var metalSum = metalValue.Sum();

            var partTwo = Regex.Split(inputExtract[1], " ").ToList();

            var credits = Convert.ToInt32(partTwo[0]);

            var FinalValue = credits / metalSum;

            model.Metals.Add(new Metal { MetalName = metalName, MetalValue = FinalValue });

            return "";
        }
    }
}
