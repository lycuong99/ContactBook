using ContactBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactBook.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private List<Contact> Contacts;
        static readonly string CREATE = "CREATE";
        static readonly string EDIT = "EDIT";
        private Guid SelectedContactId = Guid.Empty;

        private string saveMode = "CREATE";

        public HomeView(ref List<Contact> Contacts)
        {
            InitializeComponent();
            // InitData();
            this.Contacts = Contacts;
            contactBookGrid.ItemsSource = Contacts;
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void New_Button_Click(object sender, RoutedEventArgs e)
        {
            Clear();

            txtName.Focus();

            saveMode = CREATE;

            

        }
        private void Clear()
        {
            txtName.Text = "";
            txtSurname.Text = "";
            txtTel.Text = "";
            txtEmail.Text = "";
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (contactBookGrid.SelectedItem is Contact)
            {
                var selected = (Contact)contactBookGrid.SelectedItem;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var name = txtName.Text;
            var surname = txtSurname.Text;
            var email = txtEmail.Text;
            var dob = doBPicker.SelectedDate;
            var tel = txtTel.Text;

            if(name.Length == 0 || surname.Length == 0|| email.Length == 0 || tel.Length == 0 || dob == null)
            {
                MessageBox.Show("Something is empty!" , "Invalid!");
                return;
            }

            if(name.Length > 16)
            {
                MessageBox.Show("Name too Long!", "Invalid!");
                return;
            }

            if (surname.Length > 16)
            {
                MessageBox.Show("Surname too Long!", "Invalid!");
                return;
            }

            Boolean checkTel = Regex.IsMatch(tel, @"\d{10}$");
            if(!checkTel)
            {
                MessageBox.Show("Telephone must have 10 digit!", "Invalid!");
                return;
            }
            string regexPattern = @"^[a-zA-Z0-9_!#$%&’*+/=?`{|}~^.-]+@[a-zA-Z0-9.-]+$";
            Boolean checkEmail = Regex.IsMatch(email, regexPattern);
            if (!checkEmail)
            {
                MessageBox.Show("Email is wrong format!", "Invalid!");
                return;
            }
            if(dob!=null)
            {
                Boolean checkDate = DateTime.Compare(DateTime.Now, dob.Value) >= 0;
                if (!checkDate)
                {
                    MessageBox.Show("Date of Birth must be earlier than Now!", "Invalid!");
                    return;
                }
            }
       

            var newContact = new Contact() { Name = name, DoB = (DateTime)dob, Email = email, SurName = surname, Tel = tel, };

            if (saveMode == CREATE)
            {
                newContact.Id = Guid.NewGuid();

                Contacts.Add(newContact);
                contactBookGrid.ClearValue(ItemsControl.ItemsSourceProperty);
                contactBookGrid.ItemsSource = Contacts;

                MessageBox.Show("Successful", "Create Successful");
            }
            else if (saveMode == EDIT && SelectedContactId != Guid.Empty)
            {
                var oldContact = Contacts.Where(c => c.Id == SelectedContactId).First();
                var index = Contacts.IndexOf(oldContact);
                newContact.Id = SelectedContactId;
                if (index != -1)
                {
                    Contacts[index] = newContact;
                }
                contactBookGrid.ClearValue(ItemsControl.ItemsSourceProperty);
                contactBookGrid.ItemsSource = Contacts;

                MessageBox.Show("Successful", "Update Successful");
                SelectedContactId = Guid.Empty;
            }

            Clear();





        }

        private void contactBookGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {




        }

   

        private void DeleteContact(object sender, RoutedEventArgs e)
        {
            if (contactBookGrid.SelectedItem is Contact)
            {

                var selected = (Contact)contactBookGrid.SelectedItem;
                Contacts.Remove(selected);
                contactBookGrid.ClearValue(ItemsControl.ItemsSourceProperty);
                contactBookGrid.ItemsSource = Contacts;

            }
        }

        private void EditContact(object sender, RoutedEventArgs e)
        {
            if (contactBookGrid.SelectedItem is Contact)
            {
                Contact selected = (Contact)contactBookGrid.SelectedItem;
                txtName.Text = selected.Name;
                txtSurname.Text = selected.SurName;
                txtTel.Text = selected.Tel;
                txtEmail.Text = selected.Email;
                doBPicker.SelectedDate = selected.DoB;

                saveMode = EDIT;
                SelectedContactId = selected.Id;
            }
        }

        private void textBox6_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keySearch = txtSearch.Text;
            var results = Contacts.Where(c => c.Name.Contains(keySearch) || c.Email.Contains(keySearch)
                        || c.SurName.Contains(keySearch) || c.Tel.Contains(keySearch) || c.DoB.ToShortDateString().Contains(keySearch));

            contactBookGrid.ClearValue(ItemsControl.ItemsSourceProperty);
            contactBookGrid.ItemsSource = results;
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtTel_KeyDown(object sender, KeyEventArgs e)
        {
           /* Boolean result = Regex.IsMatch(e.Key.ToString(), @"\d");
            if (!result)
            {
                MessageBox.Show("Invalid Input !");
                txtTel.Text = txtTel.Text.Remove(txtTel.Text.Length - 1);
            }
          
            
            Console.Write(e);*/
        }
    }
}
