using SimpleFormulaInterpreter;

class Program
{
    private static Data data = new Data();

    public static void Main(string[] args)
    {
        String formula = "(({CON}+{FOR})*4)+([({INT}<{FOR})?{:D20};10])";

        data.setAttribute("FOR", "4");
        data.setAttribute("DES", "2");
        data.setAttribute("CON", "4");
        data.setAttribute("INT", "2");
        data.setAttribute("PER", "2");
        data.setAttribute("FV", "2");
        data.setAttribute("DIFM", "({INT}+{DES})");

        Interpreter interpreter = new Interpreter(formula, data);

        Console.WriteLine(formula);
        Console.WriteLine("resultado = " + interpreter.recursivePreparer());
    }
}