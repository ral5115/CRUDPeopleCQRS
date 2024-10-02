using MediatR;

namespace CRUDPersonCleanArchitecture.Commands
{
    public class DeletePersonCommand : IRequest
    {
        public int Id { get; set; }
    }
}
