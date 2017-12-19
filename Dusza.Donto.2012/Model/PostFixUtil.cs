using System;

namespace Dusza.Donto._2012.Model
{
    public static class PostFixUtil
    {
        /// <summary>
        /// Ez a metódus egy infix kifejezést átalakít postfix kifejezésre, és visszaadja eredményként. Ha valamilyen
        /// módon nem sikerült a feldolgozás, akkor InvalidOperationExceptiont dob vissza.
        /// </summary>
        /// <param name="input">Az infix kifejezés szövegként.</param>
        /// <returns>A postfix kifejezést reprezentáló osztály.</returns>
        public static IPostFixToken TransformToPostfix(string input)
        {
            // Első lépésben a szóközöket kivesszük, hiszen nincs jelentőségük.
            input = input.Replace(" ", "");
            // És a kifejezést körülvevő zárójeleket is.
            if (input[0] == '(' && input[input.Length - 1] == ')')
            {
                input = input.Substring(1, input.Length - 2);
            }

            // Megkeressük azt a műveleti jelet, ami nincs zárójelben. Ehhez tudnunk kell, hogy hány zárójelet nyitottunk ki,
            // és egy változóban tároljuk a művelet jelet, és a helyét.
            int parenthesisCount = 0;
            int index = -1;
            char @operator = ' ';
            for (int i = 0; i < input.Length; i++)
            {
                //Növeljük, illetve csökkentjük a megkezdett zárójelek számát.
                if (input[i] == '(') parenthesisCount++;
                if (input[i] == ')') parenthesisCount--;

                //Itt van az, hogy a műveleti jel a zárójeleken kívül van.
                if ((input[i] == '+' || input[i] == '*') && parenthesisCount == 0)
                {
                    if (@operator != ' ')
                    {
                        // több műveleti jel a zárójelen kívül, ez hibás kifejezést jelent
                        throw new InvalidOperationException("Hibás kifejezés!");
                    }

                    // Tárolás
                    @operator = input[i];
                    index = i;
                }
            }

            if (parenthesisCount != 0)
            {
                // Ilyenkor nem jó a zárójelezés, hiszen eggyel többet nyitottunk ki / zártunk be, mint amennyit zártunk be / nyitottunk ki.
                throw new InvalidOperationException("Hibás zárójelezés!");
            }

            if (@operator == '+')
            {
                // Ha az operátor összeadás, akkor a ..... + ----- mintájú kifejezésből csinálunk egy SumTokent, aminek az első
                // operandusa ....., a második pedig -----, rekurzívan meghívva ezt a metódust.
                return
                    new SumToken(TransformToPostfix(input.Substring(0, index)),
                        TransformToPostfix(input.Substring(index + 1)));
            }
            else if (@operator == '*')
            {
                // Ha az operátor szorzás, akkor a ..... * ----- mintájú kifejezésből csinálunk egy ProductTokent, aminek az első
                // operandusa ....., a második pedig -----, rekurzívan meghívva ezt a metódust.
                return new ProductToken(TransformToPostfix(input.Substring(0, index)),
                    TransformToPostfix(input.Substring(index + 1)));
            }
            else
            {
                // Ilyenkor nem találtunk operátort, tehát vagy konstanssal, vagy változóval van dolgunk.
                IPostFixToken result = TryParseAsVariable(input);
                if (result != null)
                {
                    return result;
                }

                result = TryParseAsConstant(input);
                if (result != null)
                {
                    return result;
                }

                // Se nem változót nem sikerült létrehozni, se nem konstanst, így a kifejezés hibásnak minősült.
                throw new InvalidOperationException("Hibás kifejezés!");
            }
        }

        /// <summary>
        /// Egy kifejezést megpróbál változóként értelmezni. Ha nem sikerült, null-t ad vissza.
        /// </summary>
        /// <param name="input">A kifejezés szövegként.</param>
        /// <returns>A változót leíró osztály.</returns>
        private static VariableToken TryParseAsVariable(string input)
        {
            // Ha a VariableToken inicializálása hibát adott, akkor az nem helyes változó.
            try
            {
                return new VariableToken(input);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Egy kifejezést megpróbál konstansként értelmezni. Ha nem sikerült, null-t ad vissza.
        /// </summary>
        /// <param name="input">A kifejezés szövegként.</param>
        /// <returns>A konstanst leíró osztály.</returns>
        private static ConstantToken TryParseAsConstant(string input)
        {
            int intValue;
            // Először megpróbáljuk a szöveget számmá alakítani.
            if (int.TryParse(input, out intValue))
            {
                // Ha a Constant inicializálása hibát adott, akkor az nem helyes változó.
                try
                {
                    return new ConstantToken(intValue);
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                // Ha nem sikerült, hibás a kifejezés.
                return null;
            }
        }
    }
}
