using Autofac;
using CalculatorApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CalculatorWeb.Controllers
{
    public class ValuesController : ApiController
    {
        private static Autofac.IContainer Container { get; set; }

        public ValuesController()
        {
            //begin using autofac for logging. Change to NullDiagnostics instead of Dagnostics to stop it outputting to console.
            var builder = new ContainerBuilder();
            builder.RegisterType<DatabaseDiagnostics>().As<IDiagnostics>();
            builder.RegisterType<Calculator>().As<ISimpleCalculator>();
            Container = builder.Build();
        }
        
        [Route("api/values/Add/{intA:int}/{intB:int}")]
        [HttpGet]

        public int Add(int intA, int intB)
        {
            int result;
            using (var scope = Container.BeginLifetimeScope())
            {
                var calc = scope.Resolve<ISimpleCalculator>();
                result = calc.Add(intA, intB);
            }
            return result;
        }
        

        [Route("api/values/Subtract/{intA:int}/{intB:int}")]
        [HttpGet]

        public int Subtract(int intA, int intB)
        {
            int result;
            using (var scope = Container.BeginLifetimeScope())
            {
                var calc = scope.Resolve<ISimpleCalculator>();
                result = calc.Subtract(intA, intB);
            }
            return result;
        }

        [Route("api/values/Multiply/{intA:int}/{intB:int}")]
        [HttpGet]

        public int Multiply(int intA, int intB)
        {
            int result;
            using (var scope = Container.BeginLifetimeScope())
            {
                var calc = scope.Resolve<ISimpleCalculator>();
                result = calc.Multiply(intA, intB);
            }
            return result;
        }

        [Route("api/values/Divide/{intA:int}/{intB:int}")]
        [HttpGet]

        public int Divide(int intA, int intB)
        {
            int result;
            using (var scope = Container.BeginLifetimeScope())
            {
                var calc = scope.Resolve<ISimpleCalculator>();
                result = calc.Divide(intA, intB);
            }
            return result;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
