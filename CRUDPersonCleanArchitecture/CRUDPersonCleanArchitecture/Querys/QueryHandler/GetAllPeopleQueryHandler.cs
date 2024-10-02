using CRUDPersonCleanArchitecture.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRUDPersonCleanArchitecture.Querys.QueryHandler
{
    public class GetAllPeopleQueryHandler : IRequestHandler<GetAllPeopleQuery, IEnumerable<Person>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllPeopleQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> Handle(GetAllPeopleQuery request, CancellationToken cancellationToken)
        {
            try
            {
return await _context.People.ToListAsync();
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }
    }
}
