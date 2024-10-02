using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRUDPersonCleanArchitecture.Commands.CommandsHandler
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
    {
        private readonly ApplicationDbContext _context;

        public DeletePersonCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _context.People.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (person == null)
            {
                throw new KeyNotFoundException($"Person with Id {request.Id} not found.");
            }

            _context.People.Remove(person);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        async Task IRequestHandler<DeletePersonCommand>.Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _context.People.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (person == null)
            {
                throw new KeyNotFoundException($"Person with Id {request.Id} not found.");
            }

            _context.People.Remove(person);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
