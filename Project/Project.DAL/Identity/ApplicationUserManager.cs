using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNet.Identity;
using Project.DAL.Entities;

namespace Project.DAL.Identity
{
    class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
        }
    }
}
