using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Python.Runtime;

namespace MaxNetworkPathFindingAlgorithm.Classes
{
    public class MainClass
    {
        public static void ShowPlot()
        {
            Runtime.PythonDLL = @"C:\Users\gosha\AppData\Local\Programs\Python\Python311\python311.dll";
            PythonEngine.Initialize();

            using (Py.GIL())
            {
                dynamic plt = Py.Import("matplotlib.pyplot");
                dynamic np = Py.Import("numpy");

                var h = 0.01;
                var t = np.arange(0,1+h,h);
                Console.WriteLine(t);
                plt.plot(np.sin(np.pi*2*t), np.cos(np.pi*2*t));
                plt.show();


            }
        }

    }
}
