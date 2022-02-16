using Antlr4.Runtime.Misc;
using LangParser;

public class JavaVisitor: JavaBaseVisitor<string>{
    public Decision decision = new Decision();

    public override string VisitIf_([NotNull] JavaParser.If_Context context)
    {
        return base.VisitIf_(context);
    }

    // public override string VisitCondition([NotNull] JavaParser.ConditionContext context)
    // {
    //     return base.VisitCondition(context);
    // }

    public override string VisitComparison([NotNull] JavaParser.ComparisonContext context)
    {
        decision.Condition.Add(base.VisitComparison(context));
        return base.VisitComparison(context);
    }

    public override string VisitStatement([NotNull] JavaParser.StatementContext context)
    {
        return base.VisitStatement(context);
    }
}
