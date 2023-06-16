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

namespace Wpf_Lsn1_ButtonsCalculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
            SizeToContent = SizeToContent.WidthAndHeight;            
        }       

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window1 wind1 = new Window1();           
            this.Hide();
            wind1.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Window2 wind2 = new Window2();           
            this.Hide();
            wind2.Show();
        }
    }
}
