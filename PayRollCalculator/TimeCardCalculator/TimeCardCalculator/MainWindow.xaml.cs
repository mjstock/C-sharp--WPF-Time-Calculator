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

namespace TimeCardCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        TimeCalculator calculator = new TimeCalculator();

        public MainWindow()
        {
            InitializeComponent();
            txtMonHour.Focus();

        }

        /// <summary>
        /// Exits the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtMonHour_LostFocus(object sender, RoutedEventArgs e)
        {
            Results(txtMonHour, txtMonMin, Day.Monday);
        }

        private void txtMonMin_LostFocus(object sender, RoutedEventArgs e)
        {
            Results(txtMonHour, txtMonMin, Day.Monday);
        }

        private void txtTueHour_LostFocus(object sender, RoutedEventArgs e)
        {
            Results(txtTueHour, txtTueMin, Day.Tuesday);
        }

        private void txtTueMin_LostFocus(object sender, RoutedEventArgs e)
        {
            Results(txtTueHour, txtTueMin, Day.Tuesday);
        }

        private void txtWenHour_LostFocus(object sender, RoutedEventArgs e)
        {
            Results(txtWenHour, txtWenMin, Day.Wendsday);
        }

        private void txtWenMin_LostFocus(object sender, RoutedEventArgs e)
        {
            Results(txtWenHour, txtWenMin, Day.Wendsday);
        }

        private void txtThurHour_LostFocus(object sender, RoutedEventArgs e)
        {
            Results(txtThurHour, txtThurMin, Day.Thursday);
        }

        private void txtThurMin_LostFocus(object sender, RoutedEventArgs e)
        {
            Results(txtThurHour, txtThurMin, Day.Thursday);
        }

        private void txtFriHour_LostFocus(object sender, RoutedEventArgs e)
        {
            Results(txtFriHour, txtFriMin, Day.Friday);
        }

        private void txtFriMin_LostFocus(object sender, RoutedEventArgs e)
        {
            Results(txtFriHour, txtFriMin, Day.Friday);
        }

        private void txtSatHour_LostFocus(object sender, RoutedEventArgs e)
        {
            Results(txtSatHour, txtSatMin, Day.Saturday);
        }

        private void txtSatMin_LostFocus(object sender, RoutedEventArgs e)
        {
            Results(txtSatHour, txtSatMin, Day.Saturday);
        }

        private void txtSunHour_LostFocus(object sender, RoutedEventArgs e)
        {
            Results(txtSunHour, txtSunMin, Day.Sunday);
        }

        private void txtSunMin_LostFocus(object sender, RoutedEventArgs e)
        {
            Results(txtSunHour, txtSunMin, Day.Sunday);
        }
        /// <summary>
        /// Resets all fields in the application and TimeCalculator Class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            calculator.ResetTotals();
            txtMonHour.Text = "0";
            txtMonMin.Text = "0";
            txtTueHour.Text = "0";
            txtTueMin.Text = "0";
            txtWenHour.Text = "0";
            txtWenMin.Text = "0";
            txtThurHour.Text = "0";
            txtThurMin.Text = "0";
            txtFriHour.Text = "0";
            txtFriMin.Text = "0";
            txtSatHour.Text = "0";
            txtSatMin.Text = "0";
            txtSunHour.Text = "0";
            txtSunMin.Text = "0";
            lblRegHours.Content = "0:00";
            lblOverTime.Content = "0:00";
            lblTotalHours.Content = "0:00";
            txtMonHour.Focus();
        }

        /// <summary>
        /// displays results of user input fields
        /// </summary>
        /// <param name="txtHour"> text box of the hour for the day</param>
        /// <param name="txtMin">text box of the minites for the day</param>
        /// <param name="day">day of the week</param>
        private void Results(TextBox txtHour, TextBox txtMin, Day day)
        {
            calculator.AddTime(txtHour.Text, txtMin.Text, day);
            lblTotalHours.Content = calculator.DisplayWorkedTime();
            lblRegHours.Content = calculator.DisplayRegulerHours();
            lblOverTime.Content = calculator.DisplayOverTime();
        }
    }
}
