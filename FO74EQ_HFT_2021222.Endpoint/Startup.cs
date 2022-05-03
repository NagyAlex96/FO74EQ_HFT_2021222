using FO74EQ_HFT_2021222.Logic.Classes;
using FO74EQ_HFT_2021222.Logic.Interfaces;
using FO74EQ_HFT_2021222.Models;
using FO74EQ_HFT_2021222.Repository.Database;
using FO74EQ_HFT_2021222.Repository.Interfaces;
using FO74EQ_HFT_2021222.Repository.Model_Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            //nagyon fontos a sorrend. Ha IRepository késõbb van meghívva, mint az Logic, akkor hibát dob

            services.AddTransient<NeptunDbContext>();

            services.AddTransient<IRepository<ClassRoom>, ClassRoomRepository>();
            services.AddTransient<IRepository<Course>, CourseRespository>();
            services.AddTransient<IRepository<GradeBook>, GradeBookRepository>();
            services.AddTransient<IRepository<Student>, StudentRepository>();
            services.AddTransient<IRepository<Teacher>, TeacherRepository>();

            services.AddTransient<IClassRoomLogic, ClassRoomLogic>();
            services.AddTransient<ICourseLogic, CourseLogic>();
            services.AddTransient<IGradeBookLogic, GradeBookLogic>();
            services.AddTransient<IStudentLogic, StudentLogic>();
            services.AddTransient<ITeacherLogic, TeacherLogic>();

            services.AddControllers();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        //8.fejezet 10.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //TODO error, Nem kötelezõ!
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieDbApp.Endpoint v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { Msg = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
