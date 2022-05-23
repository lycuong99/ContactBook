using ContactBook.Views;
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

namespace ContactBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Contact> Contacts;
     
        public MainWindow()
        {
            InitializeComponent();
            InitData();
           // DataContext = new HomeViewModel(Contacts);
            mainControl.Content = new HomeView(ref Contacts);
            
        }
        private void InitData()
        {
          
            var c1 = new Contact() { Id = Guid.NewGuid(), Name = "Hung", DoB = new DateTime(1999, 5, 22), Email = "abc1@gmailcom", SurName = "Ly", Tel = "0279561357", };
            var c2 = new Contact() { Id = Guid.NewGuid(), Name = "Kha", DoB = new DateTime(1999, 11, 20, 6, 20, 40), Email = "abc2@gmailcom", SurName = "Ngo", Tel = "0379528357", };
            var c3 = new Contact() { Id = Guid.NewGuid(), Name = "Cuong", DoB = new DateTime(2000, 11, 20, 6, 20, 40), Email = "abc3@gmailcom", SurName = "Tran", Tel = "0976568327", };
            var c4 = new Contact() { Id = Guid.NewGuid(), Name = "Anh", DoB = new DateTime(2001, 11, 20, 6, 20, 40), Email = "abc9@gmailcom", SurName = "Nguyen", Tel = "0979868217", };
            var c5 = new Contact() { Id = Guid.NewGuid(), Name = "Van", DoB = new DateTime(1998, 11, 20, 6, 20, 40), Email = "abc99@gmailcom", SurName = "Ho", Tel = "0976128357", };
            Contacts = new List<Contact> {
                c1, c2, c3, c4, c5
            };
          
          

            


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainControl.Content = new HomeView(ref Contacts);
        }

        private void viewBirthday(object sender, RoutedEventArgs e)
        {
            mainControl.Content = new BirthdayCurrentWeek(ref Contacts);
        }
    }
}
