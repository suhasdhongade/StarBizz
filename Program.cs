using GalaxyBizz.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyBizz
{
    class Program
    {
        static void Main(string[] args)

        {
            List<string> UserInput = new List<string>();

            UserInput.Add("glob is I");
            UserInput.Add("prok is V");
            UserInput.Add("pish is X");
            UserInput.Add("tegj is L");

            UserInput.Add("glob glob Silver is 34 Credits");
            UserInput.Add("glob prok Gold is 57800 Credits");
            UserInput.Add("pish pish Iron is 3910 Credits");
            UserInput.Add("how much is pish tegj glob glob?");
            UserInput.Add("how many Credits is glob prok Silver ?");
            UserInput.Add("how many Credits is glob prok Gold ?");
            UserInput.Add("how many Credits is glob prok Iron ?");
            UserInput.Add("how much wood could a woodchuck chuck is if a woodchuck could chuck wood ?");

            GalaxyNumberSytemController controller = new GalaxyNumberSytemController();
            foreach (string line in UserInput)
            {
                dynamic output = controller.StartProcess(line);
                if (!string.IsNullOrEmpty(output))
                {
                    Console.WriteLine(output);
                }
            }

        }
    }
}
