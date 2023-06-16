using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Data;
using System.Media;

namespace Wpf_Lsn1_ButtonsCalculator
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {       
        double first_number;       
        string memory;
        int equals_flag;
        int on_off_sound = 1;
        char operation;

        public string ViewModel2 { get; set; }

        public Window2()
        {
            InitializeComponent();
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }
        public void ShowViewModel()
        {
            MessageBox.Show(ViewModel2);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();          
            //mainWindow.Close();
            mainWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if((equals_flag == 1 || txt1.Text == "0") && txt1.Text != "0,") txt1.Clear();
            equals_flag = 0;
            Button btn = (Button)sender;
            txt1.Text += btn.Content.ToString();
            if (txt1.Text == ",") txt1.Text = "0,";
            SounD();
        }

        private void PlusMinus_Click(object sender, RoutedEventArgs e)
        {
            first_number = double.Parse(txt1.Text);
            first_number *= -1;    
            txt1.Text = first_number.ToString();
            SounD();
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            first_number = double.Parse(txt1.Text);
            Result();            
            operation = '/';           
            TxtUpContent();
            SounD();
        }

        private void Multiple_Click(object sender, RoutedEventArgs e)
        {
            first_number = double.Parse(txt1.Text);
            Result();
            operation = '*';           
            TxtUpContent();
            SounD();
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            first_number = double.Parse(txt1.Text);
            Result();          
            operation = '-';          
            TxtUpContent();
            SounD();
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            first_number = double.Parse(txt1.Text);
            Result();            
            operation = '+';            
            TxtUpContent();
            SounD();
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            Result();
            txtUp.Text = "";
            equals_flag = 1;
            SounD();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)  // кома
        {
            try
            {
                if (!txt1.Text.Contains(',')) 
                    if(equals_flag == 0) txt1.Text += ",";
                    //if (int.Parse(txt1.Text) < 10) txt1.Text += ',';
            }
            catch
            {
                txt1.Text = "0,";
            }
            SounD();
        }

        private void DeleteLastSymbol_Click(object sender, RoutedEventArgs e)
        {
            string str = txt1.Text;            
            txt1.Text = str.Remove(str.Length-1, 1);
            SounD();
        }

        private void DeleteNumber_Click(object sender, RoutedEventArgs e)
        {
            if(txt1.Text == "0" && on_off_sound == 0) on_off_sound = 1;  // кнопка CE включення звука коли на екрані "0"
            txt1.Text = "0";
            SounD();
        }

        private void DeleteAll_Click(object sender, RoutedEventArgs e)   // кнопка C виключення звука коли на екрані "0"
        {
            if (txt1.Text == "0") on_off_sound = 0;
            txt1.Text = txtUp.Text = "0";
            SounD();
        }

        private void Result()
        {
            try
            {
                DataTable dt = new DataTable();
                string str = txtUp.Text + txt1.Text;
                string newstr = str.Replace(",", ".");
                var value = dt.Compute(newstr, null);
                txt1.Text = value.ToString();
            }
            catch
            {
                txtUp.Text = ""; txt1.Text = "ERR";
            }
        }
        private void TxtUpContent()
        {
            if (txt1.Text != "0" )
            {
                if (txtUp.Text == "0") txtUp.Text = "";
                txtUp.Text = txtUp.Text + ' ' + first_number.ToString() + ' ' + operation;
                equals_flag = 1;                  
            }            
        }

        private void MC_Click(object sender, RoutedEventArgs e)
        {
            memory = "0";
            SounD();
        }

        private void MR_Click(object sender, RoutedEventArgs e)
        {
            txt1.Text = memory;
            equals_flag = 1;
            SounD();
        }

        private void MS_Click(object sender, RoutedEventArgs e)
        {
            memory = txt1.Text;
            equals_flag = 1;
            SounD();
        }

        private void Mplus_Click(object sender, RoutedEventArgs e)
        {
            txt1.Text = (double.Parse(memory) + double.Parse(txt1.Text)).ToString();
            equals_flag = 1;
            SounD();
        }

        private void Mminus_Click(object sender, RoutedEventArgs e)
        {
            txt1.Text = (double.Parse(memory) - double.Parse(txt1.Text)).ToString();
            equals_flag = 1;
            SounD();
        }
        private void SounD()
        {
            if (on_off_sound == 1)
            {
                SoundPlayer sp = new SoundPlayer();
                sp.SoundLocation = "sound.wav";
                sp.Load();
                sp.Play();
            }
        }
    }
}
