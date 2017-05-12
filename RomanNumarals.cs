using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GalaxyBizz
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

    public class GalaxySymbol
    {
        public string SymbolName { get; set; }
        public char RomanEquivalent { get; set; }
        public int SymbolValue { get; set; }
    }
    public class Metal
    {
        public string MetalName { get; set; }
        public int MetalValue { get; set; }

    }

    class Question
    {
        public string QuestionStatement { get; set; }
    }

    class GalaxyModel
    {

        public List<GalaxySymbol> GalaxySymbols { get; set; }
        public List<Metal> Metals { get; set; }
        public List<Question> Questions { get; set; }
        public GalaxyModel()
        {
            GalaxySymbols = new List<GalaxySymbol>();
            Metals = new List<Metal>();
            Questions = new List<Question>();
        }
    }


    interface IProcessor
    {
        dynamic Process(GalaxyModel model, string userEnteredLine, List<string> inputExtract);
    }

    class ProcessSymbol : IProcessor
    {
        private RomanNumberSystem romans;
        public ProcessSymbol()
        {
            romans = new RomanNumberSystem();
        }
        public dynamic Process(GalaxyModel model, string userEnteredLine, List<string> inputExtract)
        {
            int value = romans.GetRomanCurrencyValue(inputExtract[1][0]);

            var result = model.GalaxySymbols.Exists(item => item.SymbolName.Equals(inputExtract[0]));
            if (!result)
            {
                model.GalaxySymbols.Add(new GalaxySymbol { SymbolName = inputExtract[0], RomanEquivalent = inputExtract[1][0], SymbolValue = value });
            }

            return "";
        }

    }
    class ProcessMetal : IProcessor
    {
        public dynamic Process(GalaxyModel model, string userEnteredLine, List<string> inputExtract)
        {
            int metalValue = 0;
            var partOne = Regex.Split(inputExtract[0], " ").ToList();
            string metalName = string.Empty;

            foreach (string symbol in partOne)
            {
                var result = model.GalaxySymbols.Exists(item => item.SymbolName.Equals(symbol));
                if (result)
                    metalValue += model.GalaxySymbols.Where(item => item.SymbolName.Equals(symbol)).Select(item => item.SymbolValue).FirstOrDefault();
                else
                    metalName = symbol;
            }

            var partTwo = Regex.Split(inputExtract[1], " ").ToList();

            var credits = Convert.ToInt32(partTwo[0]);

            metalValue = credits / metalValue;

            model.Metals.Add(new Metal { MetalName = metalName, MetalValue = metalValue });

            return "";
        }
    }
    class ProcessQuestion : IProcessor
    {
        public dynamic Process(GalaxyModel model, string userEnteredLine, List<string> inputExtract)
        {
            var partOne = Regex.Split(inputExtract[1], " ").ToList();
            double questionValue = 0;
            List<double> valueHolder = new List<double>();

            foreach (string symbol in partOne)
            {
                var result = model.GalaxySymbols.Exists(item => item.SymbolName.Equals(symbol));
                if (result)
                {
                    valueHolder.Add(model.GalaxySymbols.Where(item => item.SymbolName.Equals(symbol)).Select(item => item.SymbolValue).FirstOrDefault());
                }
                else
                {
                    valueHolder.Add(model.Metals.Where(item => item.MetalName.Equals(symbol)).Select(item => item.MetalValue).FirstOrDefault());

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

            return 0;
        }
    }


}
