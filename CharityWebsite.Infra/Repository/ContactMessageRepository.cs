using CharityWebsite.Core.Common;
using CharityWebsite.Core.Data;
using CharityWebsite.Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
namespace CharityWebsite.Infra.Repository
{
    public class ContactMessageRepository : IContactMessageRepository
    {
        private readonly IDbContext _dbContext;

        public ContactMessageRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddContactMessage(ContactMessage message)
        {
            var p = new DynamicParameters();
            p.Add("p_name", message.Name, DbType.String, ParameterDirection.Input);
            p.Add("p_email", message.Email, DbType.String, ParameterDirection.Input);
            p.Add("p_subject", message.Subject, DbType.String, ParameterDirection.Input);
            p.Add("p_message_content", message.Messagecontent, DbType.String, ParameterDirection.Input);

            _dbContext.Connection.Execute("CONTACT_MESSAGES_PACKAGE.ADD_CONTACT_MESSAGE", p, commandType: CommandType.StoredProcedure);
        }

        public List<ContactMessage> GetAllContactMessages()
        {
         
            using (var command = _dbContext.Connection.CreateCommand())
            {
                command.CommandText = "CONTACT_MESSAGES_PACKAGE.GET_ALL_CONTACT_MESSAGES";
                command.CommandType = CommandType.StoredProcedure;

           
                var refCursor = new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
                command.Parameters.Add(refCursor);

                using (var reader = command.ExecuteReader())
                {
                    var result = new List<ContactMessage>();
                    while (reader.Read())
                    {
                        result.Add(new ContactMessage
                        {
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            Subject = reader["Subject"].ToString(),
                            Messagecontent = reader["MessageContent"].ToString()
                        });
                    }
                    return result;
                }
            }
        }
    }
}
