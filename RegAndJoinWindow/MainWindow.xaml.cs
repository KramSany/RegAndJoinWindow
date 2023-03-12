using RegAndJoinWindow.Auth;
using RegAndJoinWindow.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void SortButton(object sender, RoutedEventArgs e)
        {
            textboxOut.Clear();
            int[] array;
            array = textbox1.Text.Split(',').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToArray();
            BubbleSort(array);
            for (int i = 0; i < array.Length; i++)
            {
                textboxOut.Text += $"{array[i]} ";
            }
            
        }
        static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        static int[] BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        Swap(array, i, j);
                    }
                }
            }
            return array;
        }
    }
}
