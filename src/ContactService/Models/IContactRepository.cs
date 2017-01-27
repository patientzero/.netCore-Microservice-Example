using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactService.Models
{
    // ReSharper disable once InconsistentNaming Interface
    public interface IContactRepository
    {
        void Add(Contact contact);
        IEnumerable<Contact> GetAll();
        Contact Find(string key);
        Contact Remove(string key);
        void Update(Contact contact);
    }
}
