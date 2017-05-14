using GalaxyBizz.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System;
using GalaxyBizz.ReferanceData;

namespace GalaxyBizz.Processor
{
    class ProcessQuestion : IProcessor
    {
        /// <summary>
        /// Method to process all the questions
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userEnteredLine"></param>
        /// <param name="inputExtract"></param>
        /// <returns></returns>
        public dynamic Process(GalaxyModel model, string userEnteredLine, List<string> inputExtract)
        {
            var questionStatement = Regex.Split(inputExtract[1], " ").ToList();
            double questionValue = 0;
            List<double> valueHolder = new List<double>();
            double metalValue = 0;
            string message;
            for (int i = 0; i < questionStatement.Count; i++)
            {
                var symbol = questionStatement[i];

                message = Validator.Occurances(model, questionStatement, symbol);
                if (!string.IsNullOrEmpty(message))
                    return message;

                message = Validator.ValidateSubstaction(model, questionStatement, symbol, i);
                if (!string.IsNullOrEmpty(message))
                    return message; 

                var result = model.GalaxySymbols.Exists(item => item.SymbolName.Equals(symbol));
                if (result)
                {

                    valueHolder.Add(model.GalaxySymbols.Where(item => item.SymbolName.Equals(symbol)).Select(item => item.SymbolValue).FirstOrDefault());
                }
                else
                {
                    metalValue = model.Metals.Where(item => item.MetalName.Equals(symbol)).Select(item => item.MetalValue).FirstOrDefault();
                }

            }

            for (int i = 0; i < valueHolder.Count; i++)
            {
                if (i == valueHolder.Count - 1)
                    break;

                double currentValue = valueHolder[i];
                double nextValue = valueHolder[i + 1];

                if (currentValue < nextValue)
                {
                    valueHolder[i] = valueHolder[i] * (-1);
                }

            }
            questionValue = valueHolder.Sum();
            message = inputExtract[1] + " is " + questionValue;
            if (metalValue > 0)
            {
                questionValue = valueHolder.Sum() * metalValue;
                message = inputExtract[1] + " is " + questionValue + " credits";
            }
            if (questionValue == 0)
            {
                return Validator.NotLegalValue;
            }

            return message;
        }




    }
}
