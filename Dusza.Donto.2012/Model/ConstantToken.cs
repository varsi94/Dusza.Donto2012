using System;
using System.Collections.Generic;

namespace Dusza.Donto._2012.Model
{
    /// <summary>
    /// A konstansokat reprezentáló osztály.
    /// </summary>
    public class ConstantToken : IPostFixToken
    {
        /// <summary>
        /// Eltároljuk a konstans értékét.
        /// </summary>
        private readonly int value;

        public ConstantToken(int value)
        {
            // A bejövő értéket ellenőrizzük, ha nem jó, akkor az hibás kifejezést jelent.
            if (value > 1000 || value < 0)
            {
                throw new InvalidOperationException("Hibás konstans érték!");
            }
            this.value = value;
        }

        public int Evaluate(int a, int b, int c)
        {
            // Ilyenkor a kiértékelés azt jelenti, hogy visszaadjuk a tárolt konstans értéket.
            return value;
        }

        public override string ToString()
        {
            // A szöveges reprezentáció maga a szám.
            return value.ToString();
        }

        public List<string> GetVariables()
        {
            // A változók listája ilyenkor üres, hiszen a kifejezés egy konstans szám.
            return new List<string>();
        }
    }
}
