using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnicaCamiloCadavid.Domain.Models;
using PruebaTecnicaCamiloCadavid.Domain.ValueObjects;
using PruebaTecnicaCamiloCadavid.Infra.Data;

namespace PruebaTecnicaCamiloCadavid.ApiTests
{
    public class ApiApp:WebApplicationFactory<Program>
    {
        public string PathPersonApi { get; } = "/api/person";

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<DataContext>));

                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddDbContext<DataContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryTestDb");
                });

                var sp = services.BuildServiceProvider();
                using var scope = sp.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<DataContext>();
                db.Database.EnsureCreated();
                //SeedTestData(db);
            });
        }

        private static void SeedTestData(DataContext db)
        {
            var roleAdmin = Role.Create("Admin");
            var roleUser = Role.Create("Usuario");

            var person1 = Person.Create(
                "nombreUno",
                "apellidoUno",
                DocumentType.Cedula,
                "123456789",
                "test1@test.com",
                new DateOnly(1990, 1, 1),
                "Masculino",
                "3258756969"
            );

            var person2 = Person.Create(
                "nombreDos",
                "apellidoDos",
                DocumentType.Pasaporte,
                "64564657",
                "test2@test.com",
                new DateOnly(1990, 1, 1),
                "Femenino",
                "3128965757"
            );

            var address1 = Address.Create(
                "Calle 123",
               person1.Id,
                "Ciudad A",
                "Pais A"
            );

            var address2 = Address.Create(
                "Calle 456",
               person2.Id,
                "Ciudad B",
                "Pais B",
                "56789"
            );

            var rolePerson1 = RolePerson.Create(roleAdmin.Id, person1.Id);
            var rolePerson2 = RolePerson.Create(roleUser.Id, person2.Id);

            db.Roles.AddRange(roleAdmin, roleUser);
            db.People.AddRange(person1, person2);
            db.Addresses.AddRange(address1, address2);
            db.RolePeople.AddRange(rolePerson1, rolePerson2);

            db.SaveChanges();
        }
    }
}
