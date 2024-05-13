using Edu.BLL.Student;
using Microsoft.Extensions.DependencyInjection;
using Edu.DAL.Configuration;
using Edu.Shared.Interfaces.StudentInterfaces;
using Edu.BLL.Teacher;
using Edu.BLL.Admin;
using Edu.BLL.User;
using Edu.BLL.Home;
using Edu.BLL.Tutorial;
using Edu.BLL.Helper;
namespace Edu.BLL.Configuration
{
    public static class BLLExtension
    {

       
        public static IServiceCollection RegisterServices(this IServiceCollection services, string connectionString)
        {
            services.RegisterDataContext(connectionString);
            services.AddScoped<AdminService>();
            services.AddScoped<UserBLL>();
            services.AddScoped<IStudentBLL, StudentBLL>();
            services.AddScoped<TeacherBLL>();
            services.AddScoped<HomeBLL>();
           services.AddScoped<TechnologyBLL>();    
            return services;
        }
        
    }
}
