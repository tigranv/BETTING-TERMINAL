using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TERMINAL
{
    public class AgeExeption : Exception
    {
        public AgeExeption() : base()
        {

        }

        public AgeExeption(string message) : base(message)
        {

        }
    }
}
