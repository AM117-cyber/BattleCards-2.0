﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCardsLibrary.Utils;
using CardDeveloper.Utils;

namespace CardDeveloper.CardEvaluator
{
    public class Pow : NonConditionalBinaryExpression
    {
        public Pow(string left, string right, CardType type) : base(left, right, type)//demasiados cambios en constructor
        {

        }
        public override double Evaluate(double leftValue, double rightValue)
        {
            return Math.Pow(leftValue, rightValue);
        }
    }
}
