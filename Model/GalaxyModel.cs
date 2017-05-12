using GalaxyBizz.ReferanceData;
using System.Collections.Generic;

namespace GalaxyBizz.Model
{
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
}
