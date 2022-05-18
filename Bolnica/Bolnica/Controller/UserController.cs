using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Bolnica.Model;
using Bolnica.Service;
namespace Bolnica.Controller
{
    public class UserController
    {
        UserService userService=new UserService();
        public static implicit operator UserController(UserControl v)
        {
            throw new NotImplementedException();
        }
        public Boolean validate(RegisteredUser ru)
        {
            return userService.validate(ru);
        }

    }
}
