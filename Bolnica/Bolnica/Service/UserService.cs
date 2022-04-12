using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.Repository;
using Bolnica.Model;
namespace Bolnica.Service
{
    public class UserService
    {
        UserRepository repository = new UserRepository();

    
    
        
        public Boolean validate(RegisteredUser ru)
        {
             return repository.validate(ru);
        }
    }
}
