using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Dusza.Donto._2012.Model;

namespace Dusza.Donto._2012
{
    public partial class Form1 : Form
    {
        // A felhasználó által megadott utolsó postfix formula.
        private IPostFixToken userDefinedFormula = null;

        public Form1()
        {
            InitializeComponent();
        }

        // Infix -> Postfix átalakító gomb klikk eseménykezelője.
        private void converToPostfixBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Az infix kifejezést megpróbáljuk PostFix-szé alakítani.
                var formula = PostFixUtil.TransformToPostfix(infixTextBox.Text);
                // Kitesszük az eredményt a felületre. Ne feledjük, hogy a ToString ilyenkor a PostFix kifejezést tartalmazza.
                postFixTextBox.Text = formula.ToString();
            }
            catch (InvalidOperationException ex)
            {
                // Ismert hiba történt, amit mi dobtunk el a kódból.
                MessageBox.Show($"A következő hiba történt a feldolgozás során: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                // Ismeretlen hiba történt.
                MessageBox.Show("Ismeretlen hiba történt a feldolgozás során!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Kiértékelő gomb eseménykezelője.
        private void evaluateBtn_Click(object sender, EventArgs e)
        {
            // Az a, b, c változók kapnak egy alap (de valid) értéket, amiket majd később feltöltünk a felhasználótól jövő
            // adatokkal, hogyha azokat éppen használjuk. Ha az adott változót nem használjuk, akkor az értékét sem, így tetszőleges
            // érték megadható.
            int a = 0, b = 0, c = 0;

            // Változónként megnézzük, hogy a hozzá tartozó mező írható-e, ha igen, akkor elmentjük a megfelelő változóba az értékét,
            // amennyiben az egész számot tartalmaz.
            if (!aValue.ReadOnly)
            {
                if (!int.TryParse(aValue.Text, out a))
                {
                    MessageBox.Show("Nem egész szám az a változó értéke!", "Hiba", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
            if (!bValue.ReadOnly)
            {
                if (!int.TryParse(bValue.Text, out b))
                {
                    MessageBox.Show("Nem egész szám a b változó értéke!", "Hiba", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
            if (!cValue.ReadOnly)
            {
                if (!int.TryParse(cValue.Text, out c))
                {
                    MessageBox.Show("Nem egész szám a c változó értéke!", "Hiba", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                // A felületre kitesszük a kiértékelés eredményét.
                resultTextBox.Text = userDefinedFormula.Evaluate(a, b, c).ToString();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Hiba történt a kiértékelés során!", "Hiba", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // A feldolgozást megvalósító eseménykezelő.
        private void processBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Létrehozzuk a postfix kifejezést.
                userDefinedFormula = new UserDefinedPostFixFormula(postFixInputTextBox.Text);
                // Begyűjtjük a változókat a kifejezésből.
                var variables = userDefinedFormula.GetVariables();
                // Készítünk a TextBoxokból egy kulcs-érték tárat, ahol a kulcs a változó neve, az értéke pedig a TextBox.
                var textBoxes = new Dictionary<string, TextBox>
                {
                    {"a", aValue},
                    {"b", bValue},
                    {"c", cValue}
                };

                foreach (var variable in textBoxes.Keys)
                {
                    // Az adott textboxot csak olvashatóvá tesszük, hogyha nem található benne a változó.
                    textBoxes[variable].ReadOnly = !variables.Contains(variable);
                }

                // Ha minden végigfutott, akkor a kiértékelő gombot engedélyzzük.
                evaluateBtn.Enabled = true;
            }
            catch
            {
                // Ha nem sikerült feldolgozni, akkor kinullozzuk a privát tagváltozót, és a kiértékelő gombot letiltjuk.
                userDefinedFormula = null;
                evaluateBtn.Enabled = false;
            }
        }

        // A műveleti sorrendet megkereső eseménykezelő metódus.
        private void searchBtn_Click(object sender, EventArgs e)
        {
            int expectedResult;
            // Először ellenőrizzük, hogy a megadott elvárt eredmény egész szám-e, ha nem akkor hibát adunk.
            if (!int.TryParse(expectedResultTextBox.Text, out expectedResult))
            {
                MessageBox.Show("Az elvárt eredmény nem egész szám!");
                return;
            }

            // Meghívjuk a kereső metódust, ha null-t ad vissza, akkor ezekből a számokból és a műveletekből 
            // nem lehet előállítani a megadott számot. Ha nem, akkor a kifejezést kiírjuk a felhasználói felületre.
            var result = PostFixUtil.SearchOrder(numberTextBox.Text, operatorTextBox.Text, expectedResult);
            if (result == null)
            {
                searchResultTextBox.Text = "Nincs helyes megoldás!";
            }
            else
            {
                searchResultTextBox.Text = result.ToString();
            }
        }
    }
}
