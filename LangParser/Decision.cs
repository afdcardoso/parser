
public class Decision{
    public Decision(){
        Condition = new List<string>();
        Statements = new List<string>();
    }

    public List<string> Condition{get; set;}
    public List<string> Statements{get; set;}
}