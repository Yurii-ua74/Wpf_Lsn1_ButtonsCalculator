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

namespace Wpf_Lsn1_ButtonsCalculator
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public string ViewModel1 { get; set; }
        public Window1()
        {
            InitializeComponent();            
        }

        public void ShowViewModel()
        {
            MessageBox.Show(ViewModel1);
        }
       
        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();            
            //mainWindow.Close();
            mainWindow.Show();
        }
    }
}
