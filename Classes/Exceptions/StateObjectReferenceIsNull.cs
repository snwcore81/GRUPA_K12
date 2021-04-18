using System;
using System.Collections.Generic;
using System.Text;

namespace GRUPA_K12.Classes.Exceptions
{
    public class StateObjectReferenceIsNull : Exception
    {
        public StateObjectReferenceIsNull() : base("Referencja do obiektu ma wartość null!")
        {

        }
    }
}
