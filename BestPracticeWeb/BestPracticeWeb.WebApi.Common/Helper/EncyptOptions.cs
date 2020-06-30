using System;
using System.Collections.Generic;
using System.Text;

namespace BestPracticeWeb.WebApi.Common
{
    public class EncyptOptions
    {
        public DES desOprions { get; set; }
    }

    public class DES
    {
        public string Key { get; set; }

        public string IV { get; set; }
    }
}
