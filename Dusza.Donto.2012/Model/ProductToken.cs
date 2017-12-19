using System.Collections.Generic;
using System.Linq;

namespace Dusza.Donto._2012.Model
{
    /// <summary>
    /// A szorzást reprezenáló osztály.
    /// </summary>
    public class ProductToken : IPostFixToken
    {
        // A két operandus, amik maguk is PostFixTokenek.
        private readonly IPostFixToken firstOperand;
        private readonly IPostFixToken secondOperand;

        public ProductToken(IPostFixToken firstOperand, IPostFixToken secondOperand)
        {
            this.firstOperand = firstOperand;
            this.secondOperand = secondOperand;
        }

        public int Evaluate(int a, int b, int c)
        {
            // A kiértékelés eredménye az, hogy az operandus kiértékelésének eredményét összeszorozzuk.
            return firstOperand.Evaluate(a, b, c) * secondOperand.Evaluate(a, b, c);
        }

        public override string ToString()
        {
            // A szöveges reprezentáció a két operandus, utána pedig egy * jel. (String interpoláció: C# 6-os nyelvi elem, olyan, mintha + operátorral
            // összefűztük volna.)
            return $"{firstOperand} {secondOperand} *";
        }

        public List<string> GetVariables()
        {
            // A változók listája pedig a két operandus változóinak uniója.
            return firstOperand.GetVariables().Union(secondOperand.GetVariables()).ToList();
        }
    }
}
