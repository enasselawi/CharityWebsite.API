using CharityWebsite.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWebsite.Core.Service
{
    public interface IContactMessageService
    {
        void AddContactMessage(ContactMessage message);
        List<ContactMessage> GetAllContactMessages();
    }
}
