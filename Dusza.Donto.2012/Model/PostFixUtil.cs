using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Dusza.Donto._2012.Model
{
    /// <summary>
    /// Ebben az osztályban tároljuk egy permutáció egy elemének adatait. Két listának az indexeit tároljuk, erre a két adatra (lista azonosító, index)
    /// van két property definiálva.
    /// </summary>
    public class PermutationItem
    {
        /// <summary>
        /// A lista típusa. Ha a számokat tartalmazó listára mutat ez az index, akkor "n" az értéke, ha az operátorokat tartalmazó
        /// listára, akkor "o".
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// A megadott lista egy elemének az indexét tároljuk benne.
        /// </summary>
        public int Index { get; set; }

        public PermutationItem(string type, int index)
        {
            Type = type;
            Index = index;
        }

    }

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
                // Ilyenkor nem találtunk operátort, tehát konstanssal van dolgunk.
                var result = TryParseAsConstant(input);
                if (result != null)
                {
                    return result;
                }

                // Nem sikerült konstanst létrehozni, így a kifejezés hibásnak minősült.
                throw new InvalidOperationException("Hibás kifejezés!");
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

        /// <summary>
        /// Ez a metódus adja vissza a jó műveleti sorrenddel rendelkező műveletet (3. részfeladat).
        /// </summary>
        /// <param name="numbers">A számokat tartalmazó tömb.</param>
        /// <param name="operators">A műveleteket tartalmazó tömb.</param>
        /// <param name="expectedResult">A elvárt eredmény.</param>
        /// <returns>A művelet postfix kifejezésként.</returns>
        public static IPostFixToken SearchOrder(string numbers, string operators, int expectedResult)
        {
            // Feldaraboljuk a számokat és az operátorokat a whitespacek (szóközök, tabok) mentén.
            var numbersArray = Regex.Split(numbers, @"[\s]+");
            var operatorsArray = Regex.Split(operators, @"[\s]+");

            // Pontosan eggyel kevesebb műveleti jel van, mint szám, ha ez nem teljesül, akkor biztosan nem állítható elő ebből 
            // egy helyes kifejezés sem.
            if (operatorsArray.Length + 1 != numbersArray.Length)
            {
                return null;
            }

            // Legeneráljuk az indexeket, amikből a permutációkat elkészítjük.
            List<PermutationItem> allIndices = new List<PermutationItem>();
            for (int i = 2; i < numbersArray.Length; i++)
            {
                // A számokhoz tartozó indexek
                allIndices.Add(new PermutationItem("n", i));
            }
            for (int i = 0; i < operatorsArray.Length - 1; i++)
            {
                // Az operátorokhoz tartozó indexek.
                allIndices.Add(new PermutationItem("o", i));
            }

            // Elkérjük az összes permutációt, és kiszűrjük belőle azokat, amelyikek nem felelnek meg a feltételeknek, vagyis
            // a két részsorozat nem sorrendben van benne (ugyanis tudjuk, hogy ezek előre rendezettek).
            var possibleSolutions = CreateAllPermutations(allIndices);
            possibleSolutions = RemoveInvalidPermutations(possibleSolutions);

            // Létrehozzuk a lehetséges megoldást tartalmazó tömböt. Ennek első két eleme biztosan az első két szám, hiszen ha nem az lenne,
            // és egy műveleti jel jön, akkor nem tudjuk a műveletet elvégezni (hiszen mindegyik művelet két operandusból áll).
            // Az utolsó eleme a kifejezésnek pedig mindenképpen az utolsó műveleti jel, hiszen rendezettek, és ha az utolsó elem szám, az azt
            // jelenti, hogy a kiértékelő algoritmus (lásd ott) úgy végződik, hogy még egy számot teszünk a verembe.
            var possibleSolution = new string[numbersArray.Length + operatorsArray.Length];
            possibleSolution[0] = numbersArray[0];
            possibleSolution[1] = numbersArray[1];
            possibleSolution[possibleSolution.Length - 1] = operatorsArray[operatorsArray.Length - 1];

            // Végigmegyünk a megmaradt lehetséges megoldásokon.
            foreach (var possibleSolutionIndices in possibleSolutions)
            {
                for (int i = 0; i < possibleSolutionIndices.Count; i++)
                {
                    // Összeállítjuk a lehetséges megoldást tartalmazó tömböt. Ha az index típusa "n", akkor a számot tartalmazó tömbből vesszük ki
                    // az indexnek megfelelő értéket, ha nem, akkor pedig a műveleti jelekből.
                    var index = possibleSolutionIndices[i].Index;
                    possibleSolution[i + 2] = (possibleSolutionIndices[i].Type == "n")
                        ? numbersArray[index]
                        : operatorsArray[index];
                }

                // A stringeket összefűzzük szóközökkel.
                var str = string.Join(" ", possibleSolution);
                try
                {
                    // Elkészítjük a formulát, és kiértékeljük, ha az elvárt eredményt adja, akkor jó.
                    var formula = new UserDefinedPostFixFormula(str);
                    if (formula.Evaluate(0, 0, 0) == expectedResult)
                    {
                        return formula;
                    }
                }
                catch
                {
                    // Ha hiba történt, akkor sem csinálunk semmit, csak nézzük a következő lehetséges megoldást.
                }
            }

            // Nem találtunk formulát, így nem lehet előállítani.
            return null;
        }

        /// <summary>
        /// Ez a metódus elkészíti az összes lehetséges permutációt.
        /// </summary>
        /// <param name="input">A lista, aminek a permutációit el kell készíteni.</param>
        /// <returns>Lista a permutációkból.</returns>
        private static List<List<PermutationItem>> CreateAllPermutations(List<PermutationItem> input)
        {
            // Az egy elemű listák permutációja önmaga.
            if (input.Count == 1)
            {
                return new List<List<PermutationItem>> { input };
            }

            // A két elemű listákat is egyszerűen le tudjuk gyártani az elemek eredeti, és felcserélt sorrendjéből álló
            // listákkal.
            if (input.Count == 2)
            {
                return new List<List<PermutationItem>>
                {
                    new List<PermutationItem> {input[0], input[1]},
                    new List<PermutationItem> {input[1], input[0]}
                };
            }

            // Egyébként pedig fogjuk az összes elemet, és végigmegyünk rajtuk.
            var result = new List<List<PermutationItem>>();
            foreach (var x in input)
            {
                // Készítünk az eredeti listából egy másolatot, és kivesszük az aktuális elemet.
                var copy = input.ToList();
                copy.Remove(x);
                // Az eggyel kisebb listára elkészítjük a permutációt, és mindegyikhez hozzáadjuk első elemként a kivett aktuális elemet.
                var subResult = CreateAllPermutations(copy);
                foreach (var item in subResult)
                {
                    item.Insert(0, x);
                    result.Add(item);
                }
            }
            return result;
        }

        /// <summary>
        /// Ez a metódus kiveszi a nem sorrendhelyes listákat a permutációk közül.
        /// </summary>
        /// <param name="input">Az összes permutáció</param>
        /// <returns>A sorrendhelyes permutációkat tartalmazó lista.</returns>
        private static List<List<PermutationItem>> RemoveInvalidPermutations(List<List<PermutationItem>> input)
        {
            // Hátrafelé végigmegyünk a listán, mert, ha valamelyiket töröljük, akkor az indexek így nem csúsznak el.
            for (int i = input.Count - 1; i >= 0; i--)
            {
                // Eltároljuk a legutolsónak talált indexet mindkét típusú listához. Ezeknek szigorúan monoton növekvő sorozatot
                // kell alkotniuk, tehát ez így megfelelő.
                int lastNumber = -1;
                int lastOperand = -1;
                var currentPermutation = input[i];
                foreach (PermutationItem item in currentPermutation)
                {
                    // Számos lista
                    if (item.Type == "n")
                    {
                        // Ha a mostani index kisebb az előzőnél, az nem sorrendhelyes, tehát törölni kell.
                        if (item.Index < lastNumber)
                        {
                            input.RemoveAt(i);
                            break;
                        }
                        lastNumber = item.Index;
                    }
                    // Ugyanez a műveleti jeleket tartalmazó listára
                    else if (item.Type == "o")
                    {
                        if (item.Index < lastOperand)
                        {
                            input.RemoveAt(i);
                            break;
                        }
                        lastOperand = item.Index;
                    }
                }
            }
            return input;
        }
    }
}
