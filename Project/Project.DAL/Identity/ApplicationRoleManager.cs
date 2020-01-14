using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNet.Identity;
using Project.DAL.Entities;

namespace Project.DAL.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole> store) : base(store)
        {
        }
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> store) : base(store)
        {
        }
    }
}
