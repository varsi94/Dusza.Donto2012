using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Dusza.Donto._2012.Model;

namespace Dusza.Donto._2012
{
    public partial class Form1 : Form
    {
        // Eltároljuk a legutoljára feldolgozott postfix kifejezést.
        private IPostFixToken latestToken;

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
                latestToken = PostFixUtil.TransformToPostfix(infixTextBox.Text);
                // Kitesszük az eredményt a felületre. Ne feledjük, hogy a ToString ilyenkor a PostFix kifejezést tartalmazza.
                postFixTextBox.Text = latestToken.ToString();
                // Begyűjtjük a változókat a kifejezésből.
                var variables = latestToken.GetVariables();
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
            if (latestToken != null)
            {
                // Az a, b, c változók kapnak egy alap (de valid) értéket, amiket majd később feltöltünk a felhasználótól jövő
                // adatokkal, hogyha azokat éppen használjuk. Ha az adott változót nem használjuk, akkor az értékét sem, így tetszőleges
                // érték megadható.
                int a = 0, b = 0, c = 0;
                if (!aValue.ReadOnly)
                {
                    if (!int.TryParse(aValue.Text, out a))
                    {
                        MessageBox.Show("Nem egész szám az a változó értéke!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (!bValue.ReadOnly)
                {
                    if (!int.TryParse(bValue.Text, out b))
                    {
                        MessageBox.Show("Nem egész szám a b változó értéke!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (!cValue.ReadOnly)
                {
                    if (!int.TryParse(cValue.Text, out c))
                    {
                        MessageBox.Show("Nem egész szám a c változó értéke!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                try
                {
                    // A felületre kitesszük a kiértékelés eredményét.
                    resultTextBox.Text = latestToken.Evaluate(a, b, c).ToString();
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Hiba történt a kiértékelés során!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //TODO: parse
            }
        }
    }
}
