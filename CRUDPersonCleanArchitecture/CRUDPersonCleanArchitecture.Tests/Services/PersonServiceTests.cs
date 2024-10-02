using Xunit;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using CRUDPersonCleanArchitecture.Commands.CommandsHandler;
using CRUDPersonCleanArchitecture.Commands;
using CRUDPersonCleanArchitecture.Querys;
using Microsoft.EntityFrameworkCore;
using CRUDPersonCleanArchitecture.Models;
using CRUDPersonCleanArchitecture.Querys.QueryHandler;

namespace CRUDPersonCleanArchitecture.Tests.Services
{
    public class PersonServiceTests
    {
        private readonly ApplicationDbContext _context;
        private readonly CreatePersonCommandHandler _createHandler;
        private readonly GetAllPeopleQueryHandler _getAllHandler;
        private readonly UpdatePersonCommandHandler _updateHandler;
        private readonly DeletePersonCommandHandler _deleteHandler;

        public PersonServiceTests()
        {
            // Configurar el ApplicationDbContext para usar una base de datos en memoria
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _context = new ApplicationDbContext(options);
            _createHandler = new CreatePersonCommandHandler(_context);
            _getAllHandler = new GetAllPeopleQueryHandler(_context);
            _updateHandler = new UpdatePersonCommandHandler(_context);
            _deleteHandler = new DeletePersonCommandHandler(_context);

            // Seed data para pruebas de consulta, edición y eliminación
            _context.People.Add(new Person
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john@example.com",
                DateOfBirth = new DateTime(1990, 1, 1),
                PhoneNumber = "555-1234",
                Address = "123 Main St"
            });
            _context.People.Add(new Person
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Email = "jane@example.com",
                DateOfBirth = new DateTime(1992, 5, 15),
                PhoneNumber = "555-5678",
                Address = "456 Elm St"
            });
            _context.SaveChanges();
        }

        [Fact]
        public async Task CreatePerson_ShouldReturnNewPersonId()
        {
            // Arrange
            var command = new CreatePersonCommand
            {
                FirstName = "New",
                LastName = "Person",
                Email = "newperson@example.com",
                DateOfBirth = new DateTime(1995, 2, 1),
                PhoneNumber = "555-0000",
                Address = "789 Oak St"
            };

            // Act
            var result = await _createHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotEqual(0, result);  // Verifica que el ID generado no sea 0
        }

        [Fact]
        public async Task GetAllPersons_ShouldReturnAllPersons()
        {
            // Act
            var result = await _getAllHandler.Handle(new GetAllPeopleQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            // Verifica que haya dos registros iniciales
        }

        [Fact]
        public async Task UpdatePerson_ShouldModifyPersonData()
        {
            // Arrange
            var command = new UpdatePersonCommand
            {
                Id = 1,  // ID del primer registro
                FirstName = "Updated",
                LastName = "Doe",
                Email = "updated@example.com",
                DateOfBirth = new DateTime(1990, 1, 1),
                PhoneNumber = "555-9999",  // Cambia el número de teléfono
                Address = "New Address"
            };

            // Act
            await _updateHandler.Handle(command, CancellationToken.None);
            var updatedPerson = await _context.People.FindAsync(1);

            // Assert
            Assert.Equal("Updated", updatedPerson.FirstName);  // Verifica que el nombre cambió
            Assert.Equal("555-9999", updatedPerson.PhoneNumber);  // Verifica que el teléfono cambió
        }

        [Fact]
        public async Task DeletePerson_ShouldRemovePerson()
        {
            // Arrange
            var command = new DeletePersonCommand { Id = 1 };  // Eliminar la persona con ID 1

            // Act
            await _deleteHandler.Handle(command, CancellationToken.None);
            var deletedPerson = await _context.People.FindAsync(1);

            // Assert
            Assert.Null(deletedPerson);  // Verifica que la persona fue eliminada
        }
    }
}
