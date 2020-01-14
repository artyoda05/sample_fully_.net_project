using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using Project.BLL.Interfaces;
using Project.BLL.Services;
using Project.DAL;
using Project.DAL.Interfaces;
using Project.DAL.Entities;
using Project.DAL.Repositories;

namespace Project.WebAPI.Ninject
{
    public class NinjectBinding : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IRepository<Material>>().To<MaterialRepository>();
            Bind<IRepository<Rating>>().To<RatingRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IMaterialService>().To<MaterialService>();
            Bind<IRatingService>().To<RatingService>();
            Bind<IUserService>().To<UserService>();
        }
    }
}