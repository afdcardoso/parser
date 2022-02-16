using Antlr4.Runtime.Misc;
using LangParser;

public class JavaVisitor: JavaBaseVisitor<string>{
    bool compare = true; 

    public Decision decision = new Decision();

    public override string VisitIf_([NotNull] JavaParser.If_Context context)
    {
        System.Console.WriteLine($"IF_:\t\t<{context.GetText()}>");
        return base.VisitIf_(context);
    }

    public override string VisitSeparator([NotNull] JavaParser.SeparatorContext context)
    {
        System.Console.WriteLine($"Separator:\t<{context.GetText()}>");
        return base.VisitSeparator(context);
    }

    public override string VisitCondition([NotNull] JavaParser.ConditionContext context)
    {
        System.Console.WriteLine($"Condition:\t<{context.GetText()}>");
        return base.VisitCondition(context);
    }
    
    public override string VisitComparison([NotNull] JavaParser.ComparisonContext context)
    {
        // if(compare){
            System.Console.WriteLine($"Comparison:\t<{context.GetText()}>");
            decision.Condition.Add(context.GetText());
        // }
        // System.Console.WriteLine($"Comparison:\t<{context.GetText()}>");
        // compare = !compare;
        return base.VisitComparison(context);
    }

    public override string VisitBlock([NotNull] JavaParser.BlockContext context)
    {
        System.Console.WriteLine($"Block:\t\t<{context.GetText()}>");
        decision.Condition.Add(context.GetText());
        return base.VisitBlock(context);
    }

    public override string VisitStatement([NotNull] JavaParser.StatementContext context)
    {
        System.Console.WriteLine($"Statement:\t<{context.GetText()}>");
        decision.Condition.Add(context.GetText());
        return base.VisitStatement(context);
    }
    
    public override string VisitWrd([NotNull] JavaParser.WrdContext context)
    {
        System.Console.WriteLine($"Word:\t<{context.GetText()}>");
        decision.Condition.Add(context.GetText());
        return base.VisitWrd(context);
    }
}
