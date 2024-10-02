using CRUDPersonCleanArchitecture.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRUDPersonCleanArchitecture.Commands.CommandsHandler
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
    {
        private readonly ApplicationDbContext _context;

        public UpdatePersonCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _context.People.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (person == null)
            {
                throw new KeyNotFoundException($"Person with Id {request.Id} not found.");
            }

            person.FirstName = request.FirstName;
            person.LastName = request.LastName;
            person.Email = request.Email;
            person.DateOfBirth = request.DateOfBirth;
            person.PhoneNumber = request.PhoneNumber;
            person.Address = request.Address;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        async Task IRequestHandler<UpdatePersonCommand>.Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _context.People.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (person == null)
            {
                throw new KeyNotFoundException($"Person with Id {request.Id} not found.");
            }

            person.FirstName = request.FirstName;
            person.LastName = request.LastName;
            person.Email = request.Email;
            person.DateOfBirth = request.DateOfBirth;
            person.PhoneNumber = request.PhoneNumber;
            person.Address = request.Address;

            await _context.SaveChangesAsync(cancellationToken);

            
        }
    }
    
}

