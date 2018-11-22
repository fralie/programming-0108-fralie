using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab08
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<Train> trains = new List<Train>();
        public MainWindow()
        {
            InitializeComponent();



        }

        struct Train
        {
            public string PunktName;
            public int TrainNumber;
            public DateTime Q;

            public override string ToString()
            {
                return String.Format("Потяг №{0}, відправляється о {1} до {2}", TrainNumber, Q, PunktName);
            }

        }

        private class TrainComparer : Comparer<Train>
        {
            public override int Compare(Train x, Train y)
            {
                return String.Compare(x.PunktName, y.PunktName);
            }
        }


        private void add_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();


            if (window.ShowDialog() == true)
            {
                Train train = new Train();

                train.PunktName = window.textBoxName.Text;
                train.TrainNumber = Convert.ToInt32(window.textBoxNumber.Text);
                train.Q = window.time;

                trains.Add(train);
                trains.Sort(new TrainComparer());

                fillListBox();

                window.Close();
            }
            else
            {
                window.Close();
            }
        }

        private void fillListBox()
        {
            listBox.Items.Clear();
            foreach (Train t in trains)
                listBox.Items.Add(t);
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s = search.Text;
            if (s.Length == 5)
            {
                DateTime time = new DateTime();
                if (DateTime.TryParseExact(s, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out time))
                {
                    listBox.Items.Clear();
                    foreach (Train t in trains)
                    {
                        if (t.Q.CompareTo(time) == 1 || t.Q.CompareTo(time) == 0) listBox.Items.Add(t);
                    }
                    if (!listBox.HasItems) listBox.Items.Add(String.Format("Немає потягів, які відправляються після {0}", time));
                }
            } else
            {
                fillListBox();
            }
        }
    }
    
}

