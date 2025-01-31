﻿using System.Runtime.CompilerServices;
using Esprima.Utils;

namespace Esprima.Ast
{
    public sealed class CatchClause : Statement
    {
        public CatchClause(Expression? param, BlockStatement body) :
            base(Nodes.CatchClause)
        {
            Param = param;
            Body = body;
        }

        /// <remarks>
        /// BindingIdentifier | <see cref="BindingPattern"/> | <see langword="null"/>
        /// </remarks>
        public Expression? Param { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }
        public BlockStatement Body { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }

        public override NodeCollection ChildNodes => new(Param, Body);

        protected internal override object? Accept(AstVisitor visitor)
        {
            return visitor.VisitCatchClause(this);
        }

        public CatchClause UpdateWith(Expression? param, BlockStatement body)
        {
            if (param == Param && body == Body)
            {
                return this;
            }

            return new CatchClause(param, body);
        }
    }
}
