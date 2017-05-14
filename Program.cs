using GalaxyBizz.Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyBizz
{
    class Program
    {
        static void Main(string[] args)

        {
            List<string> UserInput = new List<string>();

            try
            {
                var files = System.IO.File.ReadAllLines(@"InputData.txt");
                UserInput = files.ToList();

                GalaxyNumberSytemController controller = new GalaxyNumberSytemController();
                foreach (string line in UserInput)
                {
                    dynamic output = controller.StartTranslation(line.Trim());
                    if (!string.IsNullOrEmpty(output))
                    {
                        Console.WriteLine(output);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("There is an error : " + ex.Message);
            }



        }
    }
}
