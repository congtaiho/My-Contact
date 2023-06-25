using System.Collections.Generic;
using DataAccess;
using Modell;



namespace BussinessLayer
{
    public class FuntionsLogic
    {
        public static bool CheckLogin(string counrriel, string passWord)
        {
            return DataConnect.CheckLogin(counrriel, passWord);
        }
        public static bool AddContact(Contact contacts)
        {
            return DataConnect.AddContact(contacts);
        }
        public static List<Contact> SearchByyName(string nameToSearch)
        {
            return DataConnect.SearchByyName(nameToSearch);
        }

        public static List<Contact> ShowContacts()
        {
            return DataConnect.ShowContacts();
        }




        public static bool DeleteContactById(int Id)
        {
            return DataConnect.DeleteContactById(Id);
        }
        public static bool EditContact(Contact contact)
        {
            return DataConnect.EditContact(contact);
        }
    }
}
