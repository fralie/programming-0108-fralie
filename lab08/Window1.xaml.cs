using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace lab08
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public DateTime time;
        public Window1()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            string format = "HH:mm";
            if (textBoxName.Text.Length > 2 && textBoxNumber.Text.Length > 0
                && DateTime.TryParseExact(textBoxDate.Text, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out time))
            {
                this.DialogResult = true;
            }
        }
    }
}
