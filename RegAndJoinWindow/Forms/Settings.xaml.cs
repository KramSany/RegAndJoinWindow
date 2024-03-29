﻿using System;
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
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }
        private void SaveSettings_Click(object sender, RoutedEventArgs e)
        {
            int[] array;
            array = changeColorBackground.Text.Split(',').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToArray();
            Brush backColor = new SolidColorBrush(Color.FromRgb((byte)array[0], (byte)array[1], (byte)array[2]));
            ChangeColorBackground.ChangeColor(backColor);
            Close();
        }
    }
}
