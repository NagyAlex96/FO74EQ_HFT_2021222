using FO74EQ_HFT_2021222.Logic.Classes;
using FO74EQ_HFT_2021222.Logic.Interfaces;
using FO74EQ_HFT_2021222.Repository.Database;
using FO74EQ_HFT_2021222.Repository.Interfaces;
using FO74EQ_HFT_2021222.Repository.Model_Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FO74EQ_HFT_2021222.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IClassRoom, ClassRoomLogic>();
            services.AddTransient<ClassRoomRepository, ClassRoomRepository>(); //ez így jó lesz?  
            
            services.AddTransient<ICourse, CourseLogic>();
            services.AddTransient<CourseRespository, CourseRespository>();            
            services.AddTransient<IGradeBook, GradeBookLogic>();
            services.AddTransient<GradeBookRepository, GradeBookRepository>();            
            services.AddTransient<IStudent, StudentLogic>();
            services.AddTransient<StudentRepository, StudentRepository>();            
            services.AddTransient<ITeacher, TeacherLogic>();
            services.AddTransient<TeacherRepository, TeacherRepository>();

            services.AddTransient<NeptunDbContext, NeptunDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
