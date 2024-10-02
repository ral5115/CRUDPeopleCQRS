using CRUDPersonCleanArchitecture.Models;
using MediatR;

namespace CRUDPersonCleanArchitecture.Querys
{
    public class GetAllPeopleQuery : IRequest<IEnumerable<Person>>
    {
    }
}
