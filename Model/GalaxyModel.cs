using GalaxyBizz.ReferanceData;
using System.Collections.Generic;

namespace GalaxyBizz.Model
{
    /// <summary>
    /// Model class who holds all the references
    /// </summary>
    class GalaxyModel
    {
        public List<GalaxySymbol> GalaxySymbols { get; set; }
        public List<Metal> Metals { get; set; }
        public List<Question> Questions { get; set; }

        public RomanNumberSystem RomanSystem { get; set; }
        public Roman RomanBaseInfo { get; set; }


        public GalaxyModel()
        {
            GalaxySymbols = new List<GalaxySymbol>();
            Metals = new List<Metal>();
            Questions = new List<Question>();
            RomanSystem = new RomanNumberSystem();
            RomanBaseInfo = new Roman();

        }

     

    }
}
