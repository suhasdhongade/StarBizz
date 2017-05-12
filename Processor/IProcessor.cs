using GalaxyBizz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyBizz.Processor
{
    interface IProcessor
    {
        dynamic Process(GalaxyModel model, string userEnteredLine, List<string> inputExtract);
    }
}
