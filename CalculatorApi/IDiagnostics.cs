﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApi
{
    public interface IDiagnostics
    {
        void Log(string stringBeingLogged);
    }
}
