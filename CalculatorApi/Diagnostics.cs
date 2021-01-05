using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApi
{
    public class Diagnostics : IDiagnostics
    {
        public void Log(string stringBeingLogged)
        {
            Console.WriteLine($"Log: {stringBeingLogged}");
        }

    }
}
