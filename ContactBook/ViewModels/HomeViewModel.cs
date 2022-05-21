using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBook.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private List<Contact> Contacts;
        public string Name { get; set; }
        public HomeViewModel(List<Contact> Contacts)
        {
            this.Contacts = Contacts;
            Name = "Ly Van Cuong";
        }
    }
}
