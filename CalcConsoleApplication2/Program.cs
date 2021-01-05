using Autofac;
using CalculatorApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcConsoleApplication2
{
    class Program
    {
        private static IContainer Container { get; set; }
        static void Main(string[] args)
        {
            //begin using autofac for logging. Change to NullDiagnostics instead of Dagnostics to stop it outputting to console.
            var builder = new ContainerBuilder();
            builder.RegisterType<Diagnostics>().As<IDiagnostics>();
            builder.RegisterType<Calculator>().As<ISimpleCalculator>();
            Container = builder.Build();
            string answer = "";
            while(answer != "L" && answer != "W")
            {            
                Console.WriteLine("Would you like to use the local version or the webAPI version?");
                Console.WriteLine("L for Local, W for webapi:");
                answer = Console.ReadLine();
            }
            if(answer == "L")
            {
                LocalVersion();
            }
            else
            {
                WebApiVersion();
            }


        }

        private static async Task WebApiVersion()
        {
            Console.WriteLine("Using WebApi version");
            ApiHelper.InitializeClient();
            CalculatorWebVersion calc = new CalculatorWebVersion();
            string usedOperator = "";
            string int1String;
            int int1;
            do
            {
                Console.WriteLine("Choose the first number");
                int1String = Console.ReadLine();
            } while (!int.TryParse(int1String, out int1));
            Console.WriteLine($"First number Chosen: {int1}");

            while (usedOperator != "*" && usedOperator != "/" && usedOperator != "-" && usedOperator != "+")
            {
                Console.WriteLine("Please the operator from the list provided: *,/,+,-");
                usedOperator = Console.ReadLine();
            }
            Console.WriteLine($"Operator Chosen: {usedOperator}");

            int int2;
            Console.WriteLine("Choose the second number:");
            while (!int.TryParse(Console.ReadLine(), out int2))
            {
                Console.WriteLine("Choose the second number");
            }
            Console.WriteLine($"Second number Chosen: {int2}");

            Task<int> ans;
            if (usedOperator == "+") ans = calc.Add(int1, int2); 
            else if (usedOperator == "-") ans = calc.Subtract(int1, int2);
            else if (usedOperator == "*") ans = calc.Multiply(int1, int2);
            else ans = calc.Divide(int1, int2);

            Console.WriteLine($"Ans is: {ans.Result}");
            Console.ReadLine();

        }

        public static void LocalVersion()
        {
            Console.WriteLine("Using local version");
            string usedOperator = "";
            string int1String;
            int int1;
            do
            {
                Console.WriteLine("Choose the first number");
                int1String = Console.ReadLine();
            } while (!int.TryParse(int1String, out int1));
            Console.WriteLine($"First number Chosen: {int1}");

            while (usedOperator != "*" && usedOperator != "/" && usedOperator != "-" && usedOperator != "+")
            {
                Console.WriteLine("Please the operator from the list provided: *,/,+,-");
                usedOperator = Console.ReadLine();
            }
            Console.WriteLine($"Operator Chosen: {usedOperator}");

            int int2;
            Console.WriteLine("Choose the second number:");
            while (!int.TryParse(Console.ReadLine(), out int2))
            {
                Console.WriteLine("Choose the second number");
            }
            Console.WriteLine($"Second number Chosen: {int2}");


            if (usedOperator == "+") Add(int1, int2);
            else if (usedOperator == "-") Subtract(int1, int2);
            else if (usedOperator == "*") Multiply(int1, int2);
            else Divide(int1, int2);
            Console.ReadLine();

        }

        public static void Add(int intA, int intB)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var calc = scope.Resolve<ISimpleCalculator>();
                calc.Add(intA, intB);
            }
        }
        public static void Subtract(int intA, int intB)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var calc = scope.Resolve<ISimpleCalculator>();
                calc.Subtract(intA, intB);
            }
        }
        public static void Multiply(int intA, int intB)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var calc = scope.Resolve<ISimpleCalculator>();
                calc.Multiply(intA, intB);
            }
        }
        public static void Divide(int intA, int intB)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var calc = scope.Resolve<ISimpleCalculator>();
                calc.Divide(intA, intB);
            }
        }


    }
}