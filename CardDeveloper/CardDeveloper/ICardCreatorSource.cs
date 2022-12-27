﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCardsLibrary.Cards.CardDeveloper
{
    public interface ICardCreatorSource
    {
        public string[] GetCardDefinition();

    }
}