using System.Collections.Generic;

namespace Dusza.Donto._2012.Model
{
    /// <summary>
    /// Postfix kifejezésben létrejövő egységeket reprezentáló interfész. A változók, konstans számok, összeadás és szorzás fogja megvalósítani.
    /// </summary>
    public interface IPostFixToken
    {
        /// <summary>
        /// Kiértékeli a kifejezést a megadott változóparaméterekkel.
        /// </summary>
        /// <param name="a">Az a változó értéke</param>
        /// <param name="b">Az b változó értéke</param>
        /// <param name="c">Az c változó értéke</param>
        /// <returns>A kifejezés értéke</returns>
        int Evaluate(int a, int b, int c);

        /// <summary>
        /// Lekéri a kifejezésből a változókat. Egy legfeljebb háromelemű listát ad vissza, aminek elemei az {a, b, c} halmazból kerülnek ki.
        /// </summary>
        /// <returns>A változók egy listában tárolva.</returns>
        List<string> GetVariables();
    }
}
