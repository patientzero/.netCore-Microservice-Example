using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactService.Models
{
    public class ContactRepository : IContactRepository
    {
        private static ConcurrentDictionary<string, Contact> _contacts = 
            new ConcurrentDictionary<string, Contact>();

        public ContactRepository()
        {
            Add(new Contact{FirstName = "Max", LastName = "Mustermann"});
        }


        public void Add(Contact contact)
        {
            contact.Key = Guid.NewGuid().ToString();
            _contacts[contact.Key] = contact;
        }
       
        public IEnumerable<Contact> GetAll()
        {
            return _contacts.Values;
        }

        public Contact Find(string key)
        {
            ContactService.Models.Contact contact;
            _contacts.TryGetValue(key, out contact);
            return contact;
        }

        public Contact Remove(string key)
        {
            Contact contact;
            _contacts.TryRemove(key, out contact);
            return contact;
        }

        public void Update(Contact contact)
        {
            _contacts[contact.Key] = contact;
        }
    }
}
