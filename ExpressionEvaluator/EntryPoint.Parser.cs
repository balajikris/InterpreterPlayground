﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr.Runtime;
using Antlr.Runtime.Tree;

namespace ExpressionEvaluator
{
    public partial class ExprTreeParser
    {
        public AstParserRuleReturnScope<CommonTree, IToken> Parse()
        {
            return prog();
        }
    }
}
