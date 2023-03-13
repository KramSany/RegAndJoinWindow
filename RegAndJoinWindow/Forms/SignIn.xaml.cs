using RegAndJoinWindow.Auth;
using System.Windows;
using System.Windows.Controls;

namespace RegAndJoinWindow.Forms
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn(AuthData authData)
        {
            InitializeComponent();
            AuthData = authData;
        }
        public AuthData AuthData { get; set; }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (!AuthData.Authorization(Login_TB.Text, PasswordBox.Text))
            {
                return;
            }
            AuthData.CheckRule(Login_TB.Text);
            AuthData.ListUsers();
            if (AuthData.Level == 1) MessageBox.Show("Добрый день!\nВы вашли как Администатор программы.\nВы на пол шишки оператор");
            else if (AuthData.Level == 2) MessageBox.Show("Добрый день!\nВы вашли как Оператор программы.\nВы бог...");
            else MessageBox.Show("Добрый день!\nВы вашли как пользователь программы.\nВы никто...");
            Owner.Close();
        }
    }
}
