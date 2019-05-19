/* 
 * 
 * Auteur : AYED Merwann 
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP01___Palindrome_GUI
{
    public partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();
        }
        // Fonction pour enlever les accents
        static string RemoveDiacritics(string text) {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString) {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark) {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        // Fonction pour renverser la chaine de caractères
        public static string Renverser(string texte) {
            // On met le texte à renverser dans un tableau de caractères
            char[] charArray = texte.ToCharArray();
            // La fonction Array.Reverse va nous permettre d'inverser tout nos caractères dans le tableau et les replacer dedans
            Array.Reverse(charArray);
            // Il n'y a plus qu'à retourner une nouvelle chaîne de caractères issue du tableau (comme une sorte de reconstruction)
            return new string(charArray);
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            try {

                string chaine = saisieTxt.Text;

                // 1 ère étape : j'enlève la ponctuation de la 
                String noPonctuation = Regex.Replace(chaine, @"\p{P}", "");

                // 2 ème étape : tout mettre en minuscule
                String noMajuscule = noPonctuation.ToLower();

                // 3 ème étape : remplacer les accents, pour cela j'utilise une fonction prise sur le Web et très connue
                String noAccents = RemoveDiacritics(noMajuscule);

                // 3ème étape bis : j'enlève les espaces de la chaine
                String noSpaces = noAccents.Replace(" ", String.Empty);

                // 4 ème étape : renverser la chaîne
                String chaineRenversee = Renverser(noSpaces);

                // 5 ème étape : Tester s'il s'agit bien d'un palindrome
                if (chaineRenversee == noSpaces) {
                    MessageBox.Show("Il s'agit bel et bien d'un palindrome !", "Gagné !");
                } else {
                    MessageBox.Show("Ce n'est pas un palindrome !", "Désolé !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            } catch {
                MessageBox.Show("Erreur !", "Une erreur a été rencontrée, veuillez réessayer.",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
