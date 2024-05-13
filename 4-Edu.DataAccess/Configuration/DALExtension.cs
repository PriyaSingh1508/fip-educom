using Edu.DAL.Mapper;
using Edu.DAL.Repositories.Admin;
using Edu.DAL.Repositories.User;
using Edu.Shared.Interfaces;
﻿using Edu.DAL.Automapper;
using Edu.DAL.Data;
using Edu.DAL.Repository;

using Edu.Shared.Interfaces.StudentInterfaces;
using Edu.Shared.Interfaces.Teacher;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.DAL.Repositories.Home;

using Edu.Shared.Interfaces.Technology;
using Edu.DAL.Repositories.Technologies;
using Edu.DAL.Repository.Teachers;

namespace Edu.DAL.Configuration
{
    public static class DALExtension
    {
        public static IServiceCollection RegisterDataContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<EduContext>(options =>
                options.UseSqlServer(connectionString));



            services.AddAutoMapper(typeof(AdminProfile));
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IHomeRepository, HomeRepository>();
            services.AddScoped<ITechnologyRepository,TechnologyRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository,TeacherRepository>();
            services.AddAutoMapper(typeof(MappingProfiles));
           

          
            services.AddDbContext<EduContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }

       
    }
}
