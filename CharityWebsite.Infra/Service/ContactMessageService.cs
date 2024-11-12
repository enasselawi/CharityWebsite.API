using CharityWebsite.Core.Data;
using CharityWebsite.Core.Repository;
using CharityWebsite.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWebsite.Infra.Service
{
    public class ContactMessageService : IContactMessageService
    {
        private readonly IContactMessageRepository _repository;

        public ContactMessageService(IContactMessageRepository repository)
        {
            _repository = repository;
        }
        public void AddContactMessage(ContactMessage message) => _repository.AddContactMessage(message);

        public List<ContactMessage> GetAllContactMessages() => _repository.GetAllContactMessages();
    }
}
