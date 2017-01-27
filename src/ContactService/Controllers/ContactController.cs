using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactService.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactService.Controllers
{
    [Route("api/Contact")]
    public class ContactController : Controller
    {
        public ContactController(IContactRepository contactItems)
        {
            ContactItems = contactItems;
        }
        public  IContactRepository ContactItems { get; set; }


        [HttpGet(Name="GetAll")]
        public IEnumerable<Contact> GetAll()
        {
            return ContactItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetContact")] 
        public IActionResult GetById(string id)
        {
            // http://localhost:32768/api/contact/getcontact/
            var contact = ContactItems.Find((id));
            if (contact == null)
            {
                return NotFound();
            }
            return new ObjectResult(contact);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }
            ContactItems.Add(contact);
            return CreatedAtRoute("GetContact", new {id = contact.Key}, contact);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Contact contact)
        {
            if (contact == null || contact.Key != id)
            {
                return BadRequest();
            }

            var contactItem = ContactItems.Find(id);
            if (contactItem == null)
            {
                return NotFound();
            }

            ContactItems.Update(contact);
            return  new NoContentResult();
        }

        [HttpDelete("{id")]
        public IActionResult Delete(string id)
        {
            var contact = ContactItems.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            ContactItems.Remove(id);
            return new NoContentResult();
        }
    }
}
