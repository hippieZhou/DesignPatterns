using System;

namespace DesignPatterns.Interpreter
{
    class Program
    {
        static IExpression GetMaleExpression()
        {
            IExpression robert = new TerminalExpression("Robert");
            IExpression john = new TerminalExpression("John");
            return new OrExpression(robert, john);
        }
        static IExpression GetMarriedWomanExpression()
        {
            IExpression julie = new TerminalExpression("Julie");
            IExpression married = new TerminalExpression("Married");
            return new AndExpression(julie, married);
        }

        static void Main(string[] args)
        {
            IExpression isMale = GetMaleExpression();
            IExpression isMarriedWoman = GetMarriedWomanExpression();

            Console.WriteLine($"John is male? {isMale.Interpret("John")}");
            Console.WriteLine($"Julie is a married women? {isMarriedWoman.Interpret("Married Julie")}");
            Console.ReadKey();
        }
    }
}
