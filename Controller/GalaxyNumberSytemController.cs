using GalaxyBizz.Model;
using GalaxyBizz.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GalaxyBizz.Controller
{
    class GalaxyNumberSytemController
    {
        GalaxyModel model;
        ProcessSymbol symbolObj;
        ProcessMetal metalObj;
        ProcessQuestion questionObj;

        public GalaxyNumberSytemController()
        {
            model = new GalaxyModel();
            metalObj = new ProcessMetal();
            symbolObj = new ProcessSymbol();
            questionObj = new ProcessQuestion();
        }
        public dynamic StartProcess(string UserEnteredLine)
        {
            List<string> inputExtract = Regex.Split(UserEnteredLine, " is ").ToList();
            try
            {
                if (inputExtract[1].ToUpper().EndsWith("CREDITS"))    ///Metal
                {
                    return metalObj.Process(model, UserEnteredLine, inputExtract);
                }
                else if (inputExtract[1].ToUpper().EndsWith("?"))  ///Questions
                {
                    inputExtract[1] = inputExtract[1].Replace("?", "").Trim();
                    return questionObj.Process(model, UserEnteredLine, inputExtract);
                }
                else if (inputExtract[1].Length == 1) //Reference Data
                {
                    return symbolObj.Process(model, UserEnteredLine, inputExtract);
                }
                else
                {
                    return GalaxyModel.NotLegalValue;
                }
            }
            catch (Exception)
            {

                return GalaxyModel.NotLegalValue;
            }

        }

    }
}
