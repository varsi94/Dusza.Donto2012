using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Dusza.Donto._2012.Model
{
    /// <summary>
    /// Ez az osztály reprezentálja a már postfix formában megadott kifejezésket.
    /// </summary>
    public class UserDefinedPostFixFormula : IPostFixToken
    {
        // A formula a szóközök mentén feldarabolva.
        private readonly string[] tokens;

        // A formula.
        private readonly string formula;

        public UserDefinedPostFixFormula(string formula)
        {
            // A formulában többször egymás után megjelenő whitespaceket kitöröljük, és egyet hagyunk meg közülük.
            this.formula = Regex.Replace(formula, @"[\s]{1,}", " ");
            // Feldaraboljuk a szóközök mentén.
            tokens = formula.Split(' ');
            // Gyors formai ellenőrzést végzünk
            CheckSyntax();
        }

        private void CheckSyntax()
        {
            // Számokon kívül csak az összeadás és szorzás, valamint a három változó szerepelhet.
            List<string> validTokens = new List<string>() {"+", "*", "a", "b", "c"};
            foreach (var token in tokens)
            {
                int temp;
                if (!validTokens.Contains(token) && !int.TryParse(token, out temp))
                {
                    // Ha rossz szöveg van a listában, akkor kivételt dobunk.
                    throw new InvalidOperationException("Ismeretlen karakter a kifejezésben!");
                }
            }
        }

        public int Evaluate(int a, int b, int c)
        {
            // Létrehozunk egy vermet, amiben a számokat tároljuk. Az algoritmus a következő: végigmegyünk a listán, ha szám jön,
            // azt beletesszük a verembe, ha pedig műveletet, akkor kiveszünk két elemet a veremből, elvégezzük rajtuk a műveleteket,
            // majd az eredményt visszaírjuk. Ha a végén nem egy szám maradt a veremben, akkor hibás a kifejezés, egyébként pedig a művelet 
            // eredménye a veremben maradt szám.
            Stack<int> stack = new Stack<int>();
            foreach (var token in tokens)
            {
                if (token == "+" || token == "*")
                {
                    if (stack.Count < 2)
                    {
                        throw new InvalidOperationException("Hibás kifejezés!");
                    }

                    int x = stack.Pop();
                    int y = stack.Pop();
                    stack.Push((token == "+") ? x + y : x * y);
                }
                else
                {
                    int value;
                    // Változók értékének behelyettesítése, egyébként pedig a számot beírjuk (ezt már a konstrucktorban meghívott
                    // metódus ellenőrzi. 
                    if (token == "a") value = a;
                    else if (token == "b") value = b;
                    else if (token == "c") value = c;
                    else value = int.Parse(token);
                    stack.Push(value);
                }
            }

            if (stack.Count != 1)
            {
                throw new InvalidOperationException("Hibás kifejezés!");
            }
            return stack.Pop();
        }

        public List<string> GetVariables()
        {
            // A formulában, mint szövegben előforduló "a", "b", "c" karaktereket beletesszük a listába, ha megtaláltuk őket.
            var result = new List<string>();
            if (formula.Contains("a"))
            {
                result.Add("a");
            }

            if (formula.Contains("b"))
            {
                result.Add("b");
            }

            if (formula.Contains("c"))
            {
                result.Add("c");
            }

            return result;
        }

        public override string ToString()
        {
            // A ToString metódus magát az eredetileg megkapott formulát adja vissza.
            return formula;
        }
    }
}
