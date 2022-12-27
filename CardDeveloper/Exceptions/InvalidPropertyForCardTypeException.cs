using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCardsLibrary.Exceptions
{
    public class InvalidPropertyForCardTypeException : Exception
    {
        public InvalidPropertyForCardTypeException() : base() { }

        public InvalidPropertyForCardTypeException(string? message) : base(message) { }

        public override string Message => "You must insert a valid card type.";
    }
}
