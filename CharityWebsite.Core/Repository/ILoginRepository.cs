using CharityWebsite.Core.Data;
using CharityWebsite.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWebsite.Core.Repository
{
    public interface ILoginRepository
    {
        Userr Auth(Userr userr);
    }
}
