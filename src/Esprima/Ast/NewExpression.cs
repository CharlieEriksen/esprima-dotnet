﻿using System.Runtime.CompilerServices;
using Esprima.Utils;

namespace Esprima.Ast
{
    public sealed class NewExpression : Expression
    {
        private readonly NodeList<Expression> _arguments;

        public NewExpression(
            Expression callee,
            in NodeList<Expression> args)
            : base(Nodes.NewExpression)
        {
            Callee = callee;
            _arguments = args;
        }

        public Expression Callee { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }
        public ref readonly NodeList<Expression> Arguments { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => ref _arguments; }

        public override NodeCollection ChildNodes => GenericChildNodeYield.Yield(Callee, Arguments);

        protected internal override object? Accept(AstVisitor visitor)
        {
            return visitor.VisitNewExpression(this);
        }

        public NewExpression UpdateWith(Expression callee, in NodeList<Expression> arguments)
        {
            if (callee == Callee && NodeList.AreSame(arguments, Arguments))
            {
                return this;
            }

            return new NewExpression(callee, arguments);
        }
    }
}
