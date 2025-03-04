﻿using System.Runtime.CompilerServices;
using Esprima.Utils.Jsx;

namespace Esprima.Ast.Jsx;

public sealed class JsxAttribute : JsxExpression
{
    public JsxAttribute(JsxExpression name, Expression? value) : base(JsxNodeType.Attribute)
    {
        Name = name;
        Value = value;
    }

    public JsxExpression Name { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }
    public Expression? Value { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }

    public override NodeCollection ChildNodes => new(Name, Value);

    protected override object? Accept(IJsxAstVisitor visitor)
    {
        return visitor.VisitJsxAttribute(this);
    }

    public JsxAttribute UpdateWith(JsxExpression name, Expression? value)
    {
        if (name == Name && value == Value)
        {
            return this;
        }

        return new JsxAttribute(name, value);
    }
}
