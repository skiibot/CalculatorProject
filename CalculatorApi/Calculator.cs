using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApi
{
    public class Calculator : ISimpleCalculator
    {
        private readonly IDiagnostics diag;

        public Calculator(IDiagnostics diagnostics)
        {
            this.diag = diagnostics;
        }

        public int Add(int start, int amount)
        {

            int result = start + amount;
            this.diag.Log($"{DateTime.Today.ToShortDateString()}: {start} + {amount} = {result}");
            return result;
        }

        public int Divide(int start, int by)
        {
            int result;
            try
            {
                 result =  start / by;
                
            }
            catch(DivideByZeroException e)
            {
                 result = 0;
            }

            this.diag.Log($"{DateTime.Today.ToShortDateString()}: {start} / {by} = {result}");
            return result;

        }

        public int Multiply(int start, int by)
        {
            int result = start * by;
            this.diag.Log($"{DateTime.Today.ToShortDateString()}: {start} * {by} = {result}");
            return result;
        }

        public int Subtract(int start, int amount)
        {
            int result =  start - amount;
            this.diag.Log($"{DateTime.Today.ToShortDateString()}: {start} - {amount} = {result}");
            return result;
        }
    }
}
