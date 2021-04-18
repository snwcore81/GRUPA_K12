using System;
using System.Collections.Generic;
using System.Text;

namespace GRUPA_K12.Classes.Exceptions
{
    public class StateObjectDataIsNull : Exception
    {
        public StateObjectDataIsNull() : base("Referencja do danych ma wartość null!")
        {

        }
    }
}
