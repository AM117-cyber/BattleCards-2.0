using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDeveloper1
{
    public interface ICardCreatorSource
    {
        public string[] GetCardDefinition();

    }
}
