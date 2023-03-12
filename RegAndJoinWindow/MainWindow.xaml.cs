using RegAndJoinWindow.Auth;
using RegAndJoinWindow.Forms;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace RegAndJoinWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MenuRegAndJoin menuRegAndJoin = new MenuRegAndJoin();
        bool _check = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            menuRegAndJoin.Owner = this;
            menuRegAndJoin.ShowDialog();
        }

        private void Settings(object sender, RoutedEventArgs e)
        {
            if (AuthData.Level == 1)
            {
                Settings settings = new();
                settings.Owner = this;
                settings.ShowDialog();
            }
            else MessageBox.Show("Вы не администатор, чтобы открыть настройки!");
        }

        private void InfoEnter(object sender, MouseEventArgs e)
        {
            if (_check)
            {
                MessageBox.Show("Введите числа через запятую!");
                _check = false;
            }
        }

        private void SortButton(object sender, RoutedEventArgs e)
        {
            string text = textbox1.Text;
            List<int> list = new List<int>();
            for (int i = 0; i < text.Length; i++)
            {
                list.Add(Int32.Parse(text[i].ToString()));
            }
            list.Remove(',');
            list.Sort();
            for (int i = 0; i < list.Count; i++)
            {
                textboxOut.Text += $"{list[i]}, ";
            }
            textboxOut.Text.Remove(textboxOut.Text.Length - 1); // Sort will be fine...
        }
    }
}
