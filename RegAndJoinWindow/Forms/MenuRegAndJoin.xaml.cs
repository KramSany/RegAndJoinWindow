using RegAndJoinWindow.Auth;
using System.Windows;

namespace RegAndJoinWindow.Forms
{
    /// <summary>
    /// Логика взаимодействия для MenuRegAndJoin.xaml
    /// </summary>
    public partial class MenuRegAndJoin : Window
    {
        int level = 0;
        private AuthData _authData = new();
        public MenuRegAndJoin()
        {
            InitializeComponent();
        }

        public int Level
        {
            get { return level; }
            set { level = value; }

        }

        private void SingIn_Click(object sender, RoutedEventArgs e)
        {
            SignIn singIn = new SignIn(_authData);
            singIn.Owner = this;
            singIn.ShowDialog();

        }

        private void SingUp_Click(object sender, RoutedEventArgs e)
        {
            SignUp window2 = new SignUp(_authData);
            window2.Owner = this;
            window2.ShowDialog();

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Close();

        }
    }
}
