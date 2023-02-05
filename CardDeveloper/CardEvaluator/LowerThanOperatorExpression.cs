﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCardsLibrary.Utils;
using CardDeveloper.Utils;

namespace CardDeveloper.CardEvaluator
{
    public class LowerThanOperatorExpression : NonConditionalBinaryExpression
    {
        public LowerThanOperatorExpression(string left, string right, CardType type) : base(left, right, type)
        {

        }

        public override double Evaluate(double leftValue, double rightValue)
        {
            return leftValue < rightValue ? 1 : 0;
        }
    }
}
