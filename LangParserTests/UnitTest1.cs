using Microsoft.VisualStudio.TestTools.UnitTesting;
using LangParser;
using Antlr4.Runtime;

namespace LangParserTests;

[TestClass]
public class ParserTest
{
    private JavaParser Setup(string text)
    {
        AntlrInputStream inputStream = new AntlrInputStream(text);
        JavaLexer javaLexer = new JavaLexer(inputStream);
        CommonTokenStream commonTokenStream = new CommonTokenStream(javaLexer);
        JavaParser javaParser = new JavaParser(commonTokenStream);

        return javaParser;   
    }

    [TestMethod]
    public void TestIf_()
    {
        JavaParser parser = Setup("if(1==2){hello}");

        JavaParser.If_Context context = parser.if_();
        JavaVisitor visitor = new JavaVisitor();
        Decision line = new Decision();
        line.Condition.Add(visitor.VisitIf_(context));

        // Assert.AreEqual(2, visitor.Lines.Count);
    }
    
    [TestMethod]
    public void TestCondition()
    {
        JavaParser parser = Setup("if(1==2)");

        JavaParser.ConditionContext context = parser.condition();
        JavaVisitor visitor = new JavaVisitor();
        Decision dec = new Decision();
        dec.Condition.Add(visitor.VisitCondition(context));
        
        Assert.AreEqual("1==2", dec.Condition[0]);
    }

    // [TestMethod]
    // public void TestWrongLine()
    // {
    //     SpeakParser parser = Setup("john sayan "hello" n");

    //     var context = parser.line();
        
    //     Assert.IsInstanceOfType(context, typeof(SpeakParser.LineContext));
    //     Assert.AreEqual("john", context.name().GetText());
    //     Assert.IsNull(context.SAYS());
    //     Assert.AreEqual("johnsayan"hello"n", context.GetText());
    // }      
}