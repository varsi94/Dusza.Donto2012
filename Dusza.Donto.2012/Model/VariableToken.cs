using System;
using System.Collections.Generic;

namespace Dusza.Donto._2012.Model
{
    /// <summary>
    /// Változót reprenztáló osztály a postfix kifejezésben.
    /// </summary>
    public class VariableToken : IPostFixToken
    {
        /// <summary>
        /// A változó neve.
        /// </summary>
        private readonly string variableName;

        public VariableToken(string variableName)
        {
            if (variableName != "a" && variableName != "b" && variableName != "c")
            {
                // Ha nem a-t, b-t vagy c-t kaptunk, akkor az hibás kifejezést jelent.
                throw new InvalidOperationException("Hibás változónév!");
            }
            this.variableName = variableName;
        }

        public int Evaluate(int a, int b, int c)
        {
            // Ellenőrizzük a változók értékét annak megfelelően, hogy éppen melyik típusú változót valósítjuk meg.
            if (variableName == "a")
            {
                if (a > 1000 || a < 0)
                {
                    throw new InvalidOperationException("A változó értéke 0 és 1000 közötti szám lehet!");
                }
                return a;
            }
            if (variableName == "b")
            {
                if (b > 1000 || b < 0)
                {
                    throw new InvalidOperationException("A változó értéke 0 és 1000 közötti szám lehet!");
                }
                return b;
            }

            if (c > 1000 || c < 0)
            {
                throw new InvalidOperationException("A változó értéke 0 és 1000 közötti szám lehet!");
            }
            return c;
        }

        public override string ToString()
        {
            // A szöveges változata ennek maga a variableName változó.
            return variableName;
        }

        public List<string> GetVariables()
        {
            // Ez a kifejezés magában egy változót tartalmaz.
            return new List<string> { variableName };
        }
    }
}
