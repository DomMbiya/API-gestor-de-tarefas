using Gestor_de_tarefas.Data;
using Gestor_de_tarefas.Repository;
using Gestor_de_tarefas.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gestor_de_tarefas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); 

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<GestorTarefasDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepositorio>();
            builder.Services.AddScoped<ITarefaRepository, TarefaRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
}
}