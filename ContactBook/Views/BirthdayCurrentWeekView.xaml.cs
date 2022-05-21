using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using System.Linq;

namespace ContactBook.Views
{
    /// <summary>
    /// Interaction logic for BirthdayCurrentWeek.xaml
    /// </summary>
    public partial class BirthdayCurrentWeek : UserControl
    {
        private List<Contact> Contacts;
    
        public BirthdayCurrentWeek(ref List<Contact> Contacts)
        {
            InitializeComponent();
            Contacts = Contacts;
          //  this.contactBookGrid.ItemsSource = Contacts;

            int currentWeekOfYear = ISOWeek.GetWeekOfYear(DateTime.Now);
            this.contactBookGrid.ItemsSource = Contacts.Where(c => ISOWeek.GetWeekOfYear(c.DoB) == currentWeekOfYear);

            txtCurrentWeek.Text = $"{GetFirstDayOfWeek(DateTime.Now).ToString("dd/MM/yyyy")} - {GetLasttDayOfWeek(DateTime.Now).ToString("dd/MM/yyyy")}";
        }

        public DateTime GetFirstDayOfWeek(DateTime date)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = date.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0)
                diff += 7;
            return date.AddDays(-diff + 1).Date;
        }

        //To Get The Last Day of the Week in C#
        public DateTime GetLasttDayOfWeek(DateTime date)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = date.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0)
                diff += 7;
            DateTime start = date.AddDays(-diff).Date;
            return start.AddDays(6 + 1).Date;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
