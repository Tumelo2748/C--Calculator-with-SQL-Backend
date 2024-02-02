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
using System.Data;
using Datalayer;

namespace _220050062_Thinane_LabEx5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataLayerClass dataLayer = new DataLayerClass();

        public MainWindow()
        {
            InitializeComponent();
            LoadCalculations();
        }

        private void Num1_Click(object sender, RoutedEventArgs e)
        {
            Results.Text += "1";
        }

        private void Num2_Click(object sender, RoutedEventArgs e)
        {
            Results.Text += "2";
        }

        private void Num3_Click(object sender, RoutedEventArgs e)
        {
            Results.Text += "3";
        }

        private void Num4_Click(object sender, RoutedEventArgs e)
        {
            Results.Text += "4";
        }

        private void Num5_Click(object sender, RoutedEventArgs e)
        {
            Results.Text += "5";
        }

        private void Num6_Click(object sender, RoutedEventArgs e)
        {
            Results.Text += "6";
        }

        private void Num7_Click(object sender, RoutedEventArgs e)
        {
            Results.Text += "7";
        }

        private void Num8_Click(object sender, RoutedEventArgs e)
        {
            Results.Text += "8";
        }

        private void Num9_Click(object sender, RoutedEventArgs e)
        {
            Results.Text += "9";
        }

        private void Num0_Click(object sender, RoutedEventArgs e)
        {
            Results.Text += "0";
        }

        private void Addition_Click(object sender, RoutedEventArgs e)
        {
            Results.Text += "+";
        }

        private void Subtraction_Click(object sender, RoutedEventArgs e)
        {
            Results.Text += "-";
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            Results.Text += "*";
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            Results.Text += "/";
        }

        private void Clearbtn_Click(object sender, RoutedEventArgs e)
        {
            Results.Text = "";
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable Calc = new DataTable();
                var calculation = Results.Text; // Stores the calculation in a variable
                var ans = Calc.Compute(calculation, " ");
                Results.Text = $"{calculation}  =  {ans}"; // Shows the calculation and the result

                // Save the calculation to the database
                var calculationResult = new DataLayerClass.Calculation { Results = $"{calculation} = {ans}" };
                dataLayer.Results(calculationResult);

                // Add the calculation to the list box
                Calculations.Items.Insert(0, calculationResult.Results);

            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void LoadCalculations()
        {
            Calculations.Items.Clear();
            var dataLayer = new DataLayerClass();
            List<DataLayerClass.Calculation> computes = dataLayer.GetAllCalculations();
            
            Calculations.Items.Add("ID            Results");
            foreach (DataLayerClass.Calculation compute in computes)
            {
                Calculations.Items.Add($"{compute.Id,-5}         {compute.Results}");
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            
        }
    }
}
