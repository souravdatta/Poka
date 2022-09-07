using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poka
{
    public class PokaEvaluator
    {
        public void Eval(string expr)
        {
            Lexer lexer = new Lexer(expr);
            string? token;
            while (true) 
            {
                token = lexer.NextToken();
                if (token == null) break;
                Console.WriteLine(token);
            }
            Console.WriteLine("--");
        }
    }
}
