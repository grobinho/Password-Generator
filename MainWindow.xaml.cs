using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Password_Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentLang = "EN";
        private string currentColorTheme = "Default";

        public MainWindow()
        {
            InitializeComponent();
            ComboBoxPassLength.SelectedIndex = 4;
            ComboBoxLettersType.SelectedIndex = 2;

            ApplyColorTheme(currentColorTheme);

        }

        private void GeneratePassword_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)ComboBoxPassLength.SelectedItem;

            int passLength = 4;

            if (int.TryParse(selectedItem.Content.ToString(), out int selectedValue))
            {
                passLength = selectedValue;
            }
            else
            {
                MessageBox.Show("Error related with password length value. Setting as default (4)");
            }

            string password = "";
            string characters = "";

            switch (ComboBoxLettersType.SelectedIndex)
            {
                case 0:
                {
                    characters += "abcdefghijklmnopqrstuwvxyz";
                }
                break;

                case 1:
                {
                    characters += "ABCDEFGHIJKLMNOPQRSTUWVXYZ";
                }
                break;

                case 2:
                {
                    characters += "abcdefghijklmnopqrstuwvxyzABCDEFGHIJKLMNOPQRSTUWVXYZ";
                }
                break;
            }

            if(CheckBoxAllowNumbers.IsChecked == true)
            {
                characters += "0123456789";
            }

            if (CheckBoxAllowSpecials.IsChecked == true)
            {
                characters += "!@#$%^&*";
            }

            for (int i = 0; i < passLength; i++)
            {
                var rnd = new Random();
                password += characters[rnd.Next(characters.Length)];
            }

            TextBoxPasswordResult.Text = password;

            if (ButtonCopyToClipboard.Content == "✅")
            {
                ButtonCopyToClipboard.Content = "📋";
            }
        }

        private void CopyToClipboard_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(TextBoxPasswordResult.Text);
            ButtonCopyToClipboard.Content = "✅";
        }

        private void ShowAppInfo_Click(object sender, RoutedEventArgs e)
        {
            switch(currentLang)
            {
                case "EN":
                {
                    MessageBox.Show("The purpose of this app is to randomly generate series of characters which will serve as a password. By clicking GENERATE button you will create new password. With pressing clipbaord button you will copy password to your clipboard.\n\nConfigurable parameters:\n- password length of 4-12 characters;\n- type of letters (uppercase or lowercase or both);\n- toggleable numbers;\n- toggleable special characters;\n\n\n\nCreated by https://github.com/grobinho/", "Password Generator - about");
                }
                break;
                case "DE":
                {
                    MessageBox.Show("Der Zweck dieser App ist es, eine zufällige Reihe von Zeichen zu generieren, die als Passwort dienen sollen. Wenn Sie auf die Schaltfläche GENERIEREN klicken, wird ein neues Passwort erstellt. Durch Drücken der Taste clipbaord kopieren Sie das Passwort in Ihre Zwischenablage.\n\nKonfigurierbare Parameter:\n- Passwortlänge von 4-12 Zeichen;\n- Art der Buchstaben (Großbuchstaben, Kleinbuchstaben oder beides);\n- umschaltbare Nummern;\n- umschaltbare Sonderzeichen;\n\n\n\nErstellt von https://github.com/grobinho/", "Password Generator - über");
                }
                break;
                case "ES":
                {
                    MessageBox.Show("El propósito de esta aplicación es generar aleatoriamente una serie de caracteres que servirán como contraseña. Pulsando el botón GENERAR creará una nueva contraseña. Pulsando el botón clipbaord copiará la contraseña en el portapapeles.\n\nParámetros configurables:\n- contraseña de 4-12 caracteres;\n- tipo de letras (mayúsculas, minúsculas o ambas);\n- números intercambiables;\n- caracteres especiales conmutables;\n\n\n\nCreado por https://github.com/grobinho/", "Password Generator - acerca de");
                }
                break;
            }
            
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void ChangeColorTheme_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menuItem)
            {
                string colorTheme = menuItem.Tag.ToString();

                ApplyColorTheme(colorTheme);
            }
        }
        private void ApplyColorTheme(string ColorTheme)
        {
            currentColorTheme = ColorTheme;

            switch (ColorTheme)
            {
                case "Default":
                {
                    UpdateCheckedColorThemeMenuItem(MenuItemColorThemeDefault);

                    ApplyColorToElements(Colors.Silver, Colors.DarkBlue, Colors.Gray, Colors.DarkGray);
                }
                break;
                case "Dark":
                {
                    UpdateCheckedColorThemeMenuItem(MenuItemColorThemeDark);

                    ApplyColorToElements(Colors.Black, Colors.Gray, Colors.Black, Colors.Black);
                }
                break;
                case "Forest":
                {
                    UpdateCheckedColorThemeMenuItem(MenuItemColorThemeForest);

                    ApplyColorToElements(Colors.DarkGreen, Colors.LimeGreen, Colors.ForestGreen, Colors.SeaGreen);
                }
                break;
                case "Ocean":
                {
                    UpdateCheckedColorThemeMenuItem(MenuItemColorThemeOcean);

                    ApplyColorToElements(Colors.LightBlue, Colors.DarkBlue, Colors.RoyalBlue, Colors.LightSkyBlue);
                }
                break;
            }
        }

        private void ApplyColorToElements(Color BackgroundColor, Color FontColor, Color ButtonsBackgroundColor, Color PasswordResultBackgrundColor)
        {
            Background = new SolidColorBrush(BackgroundColor);

            LabelWindowTitle.Foreground = new SolidColorBrush(FontColor);
            LabelPasswordLength.Foreground = new SolidColorBrush(FontColor);
            LabelLettersType.Foreground = new SolidColorBrush(FontColor);
            LabelAllowNumbers.Foreground = new SolidColorBrush(FontColor);
            LabelAllowSpecials.Foreground = new SolidColorBrush(FontColor);

            ButtonGeneratePassword.Background = new SolidColorBrush(ButtonsBackgroundColor);
            ButtonGeneratePassword.BorderBrush = new SolidColorBrush(FontColor);
            ButtonGeneratePassword.Foreground = new SolidColorBrush(FontColor);

            ButtonCopyToClipboard.Background = new SolidColorBrush(ButtonsBackgroundColor);
            ButtonCopyToClipboard.BorderBrush = new SolidColorBrush(FontColor);
            ButtonCopyToClipboard.Foreground = new SolidColorBrush(FontColor);

            TextBoxPasswordResult.Background = new SolidColorBrush(PasswordResultBackgrundColor);
            TextBoxPasswordResult.Foreground = new SolidColorBrush(FontColor);
        }

        private void UpdateCheckedColorThemeMenuItem(MenuItem item)
        {
            MenuItemColorThemeDefault.IsChecked = false;
            MenuItemColorThemeDark.IsChecked = false;
            MenuItemColorThemeForest.IsChecked = false;
            MenuItemColorThemeOcean.IsChecked = false;

            item.IsChecked = true;
        }

        private void ChangeLanguage_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menuItem)
            {
                string language = menuItem.Tag.ToString();
                currentLang = language;

                switch (language)
                {
                    case "EN":
                    {
                        UpdateCheckedLanguageMenuItem(MenuItemLanguageEnglish);

                        MenuItemApplication.Header = "_Application";
                        MenuItemAbout.Header = "_About";
                        MenuItemClose.Header = "_Close";

                        MenuItemColorTheme.Header = "_Color theme";
                        MenuItemColorThemeDefault.Header = "_Default";
                        MenuItemColorThemeDark.Header = "_Dark";
                        MenuItemColorThemeForest.Header = "_Forest";
                        MenuItemColorThemeOcean.Header = "_Ocean";

                        MenuItemLanguage.Header = "_Language";
                        MenuItemLanguageEnglish.Header = "_English";
                        MenuItemLanguageGerman.Header = "_German";
                        MenuItemLanguageSpanish.Header = "_Spanish";

                        LabelWindowTitle.Content = "Password Generator";
                        LabelPasswordLength.Content = "Password length:";
                        LabelLettersType.Content = "Letter type:";
                        LabelAllowNumbers.Content = "Allow numbers:";
                        LabelAllowSpecials.Content = "Allow special characters:";
                        ButtonGeneratePassword.Content = "GENERATE";
                    }
                    break;
                    case "DE":
                    {
                        UpdateCheckedLanguageMenuItem(MenuItemLanguageGerman);

                        MenuItemApplication.Header = "_Anwendung";
                        MenuItemAbout.Header = "_Über";
                        MenuItemClose.Header = "_Schließen";

                        MenuItemColorTheme.Header = "_Thema Farbe";
                        MenuItemColorThemeDefault.Header = "_Standard";
                        MenuItemColorThemeDark.Header = "_Dunkelheit";
                        MenuItemColorThemeForest.Header = "_Wald";
                        MenuItemColorThemeOcean.Header = "_Ozean";

                        MenuItemLanguage.Header = "_Sprache";
                        MenuItemLanguageEnglish.Header = "_Englisch";
                        MenuItemLanguageGerman.Header = "_Deutsch";
                        MenuItemLanguageSpanish.Header = "_Spanisch";

                        LabelWindowTitle.Content = "Passwort-Generator";
                        LabelPasswordLength.Content = "Länge des Passworts:";
                        LabelLettersType.Content = "Briefart:";
                        LabelAllowNumbers.Content = "Zahlen zulassen:";
                        LabelAllowSpecials.Content = "Sonderzeichen zulassen:";
                        ButtonGeneratePassword.Content = "GENERIEREN";
                    }
                    break;
                    case "ES":
                    {
                        UpdateCheckedLanguageMenuItem(MenuItemLanguageSpanish);

                        MenuItemApplication.Header = "_Aplicación";
                        MenuItemAbout.Header = "_Acerca de";
                        MenuItemClose.Header = "_Cerrar";

                        MenuItemColorTheme.Header = "_Tema de color";
                        MenuItemColorThemeDefault.Header = "_Por defecto";
                        MenuItemColorThemeDark.Header = "_Oscuro";
                        MenuItemColorThemeForest.Header = "_Bosque";
                        MenuItemColorThemeOcean.Header = "_Océano";

                        MenuItemLanguage.Header = "_Idioma";
                        MenuItemLanguageEnglish.Header = "_Inglés";
                        MenuItemLanguageGerman.Header = "_Alemán";
                        MenuItemLanguageSpanish.Header = "_Español";

                        LabelWindowTitle.Content = "Generador de contraseñas";
                        LabelPasswordLength.Content = "Longitud de la contraseña:";
                        LabelLettersType.Content = "Tipo de carta:";
                        LabelAllowNumbers.Content = "Permitir números:";
                        LabelAllowSpecials.Content = "Permitir caracteres especiales:";
                        ButtonGeneratePassword.Content = "GENERAR";
                    }
                    break;
                }
            }
        }

        private void UpdateCheckedLanguageMenuItem(MenuItem item)
        {
            MenuItemLanguageEnglish.IsChecked = false;
            MenuItemLanguageGerman.IsChecked = false;
            MenuItemLanguageSpanish.IsChecked = false;

            item.IsChecked = true;
        }
    }
}
