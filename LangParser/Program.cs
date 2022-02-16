using LangParser;
using System.Text;
using Antlr4.Runtime;

try{
    string input = "";
    StringBuilder text = new StringBuilder();
    Console.WriteLine("Input.");

    // while ((input = Console.ReadLine()) != null)
    // {
    //     text.AppendLine(input);
    // }

    input = Console.ReadLine();
    text.AppendLine(input);

    System.Console.WriteLine("Done Reading.");
            
    AntlrInputStream inputStream = new AntlrInputStream(text.ToString());
    JavaLexer javaLexer = new JavaLexer(inputStream);
    CommonTokenStream commonTokenStream = new CommonTokenStream(javaLexer);
    JavaParser javaParser = new JavaParser(commonTokenStream);

    JavaParser.If_Context if_Context = javaParser.if_();
    JavaVisitor visitor = new JavaVisitor();        
    visitor.Visit(if_Context);
    
    foreach(var line in visitor.decision.Condition)
    {
        Console.WriteLine($"{line}\n");
    }

    // System.Console.WriteLine(visitor.Lines);
}
catch(Exception ex){
    Console.WriteLine($"Error: {ex.Message}");
}