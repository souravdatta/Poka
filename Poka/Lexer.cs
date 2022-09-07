using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poka
{
    internal class Reader
    {
        internal string Line { get; set; } = "";
        private int index = 0;
        internal string? Next()
        {
            if (index >= Line.Length || index < 0) return null;
            var c = Line[index];
            index++;
            return c.ToString();
        }

        internal void Rewind()
        {
            if (index > 0) index--;
        }

        internal void SkipWhiteSpaces()
        {
            var s = Next();
            while (s == null || char.IsWhiteSpace(s, 0))
            {
                if (s == null) break;
                s = Next();
            }
            if (s != null) Rewind();
        }
    }
    internal class Lexer
    {
        public string Expr { get; set; }
        private Reader reader;

        public Lexer() : this("")
        {
            
        }

        public Lexer(string expr)
        {
            Expr = expr;
            reader = new Reader()
            {
                Line = expr
            };
        }

        internal string? NextToken()
        {
            reader.SkipWhiteSpaces();
            string? nextChar = reader.Next();

            if (nextChar == null) return null;

            if (char.IsLetter(nextChar, 0) || nextChar[0] == '_')
            {
                string token = "";
                while (nextChar != null && 
                    (char.IsLetterOrDigit(nextChar, 0) || nextChar.Equals("_")))
                {
                    token += nextChar;
                    nextChar = reader.Next();
                }

                if (nextChar != null) reader.Rewind();
                return token;
            }

            if (char.IsDigit(nextChar, 0) || nextChar[0] == '.')
            {
                string token = "";
                int decimalCount = 0;

                while (nextChar != null && 
                    decimalCount <= 1 && 
                    (char.IsDigit(nextChar, 0) || nextChar[0] == '.'))
                {
                    if (nextChar[0] == '.')
                    {
                        if (decimalCount == 1) break;
                        else decimalCount++;
                    }
                    token += nextChar;
                    nextChar = reader.Next();
                }

                if (nextChar != null) reader.Rewind();
                return token;
            }

            var allowedStrings = new string[] { "[", "]", "{", "}", "|", "+", "-", "*", "%", "/", "^", "~", "@" };
            foreach (string s in allowedStrings)
            {
                if (s.Equals(nextChar)) return nextChar;
            }

            return null;
        }
    }
}
