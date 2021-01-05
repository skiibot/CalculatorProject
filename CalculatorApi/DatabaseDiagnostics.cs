using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApi
{
    public class DatabaseDiagnostics : IDiagnostics
    {
        public void Log(string stringBeingLogged)
        {
            using (var db = new CalculatorContext())
            {
                var log = new Log()
                {
                    logs_date = DateTime.Now,
                    logs_time = DateTime.Now.TimeOfDay,
                    logs_content = stringBeingLogged
                };
                db.Logs.Add(log);
                db.SaveChanges();
            }

            
        }
    }
   
}
