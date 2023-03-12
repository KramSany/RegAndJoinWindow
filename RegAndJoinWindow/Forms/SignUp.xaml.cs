using RegAndJoinWindow.Auth;
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
using System.Windows.Shapes;
using UserRegistration;

namespace RegAndJoinWindow.Forms
{
    /// <summary>
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        bool _check = true;
        public SignUp(AuthData authData)
        {
            InitializeComponent();
            AuthData = authData;
        }
        public AuthData AuthData { get; set; }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (AuthData.AddUser(Login_TB.Text, passwordTB.Text)) Close();
            else
            {
                Login_TB.Clear();
                passwordTB.Clear();
                Login_TB.Focus(); 
            }
        }

        private void passwordTB_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_check)
            {
                MessageBox.Show("Используйте спец. символы, числа, заглавные буквы!");
                _check = false;
            }
        }

        private void passwordTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PasswordStrengthCheker.GetPasswordStrength(passwordTB.Text) == 0)
            {
                progressBar.Value = 0;
                levelPassLabel.Content = "Сделайте сложный пароль!";
            }
            if (PasswordStrengthCheker.GetPasswordStrength(passwordTB.Text) == 1)
            {
                progressBar.Value = 1;
                levelPassLabel.Content = "Ну это отстой...";
            }
            if (PasswordStrengthCheker.GetPasswordStrength(passwordTB.Text) == 2)
            {
                progressBar.Value = 2;
                levelPassLabel.Content = "Уже лучше...";
            }
            if (PasswordStrengthCheker.GetPasswordStrength(passwordTB.Text) == 3)
            {
                progressBar.Value = 3;
                levelPassLabel.Content = "Не взломать за час...";
            }
            if (PasswordStrengthCheker.GetPasswordStrength(passwordTB.Text) == 4)
            {
                progressBar.Value = 4;
                levelPassLabel.Content = "Придётся ломать неделю...";
            }
            if (PasswordStrengthCheker.GetPasswordStrength(passwordTB.Text) == 5)
            {
                progressBar.Value = 5;
                levelPassLabel.Content = "ВЕРИ СУПЕР ГУД ПАРОЛЬ";
            }
        }
    }
}
