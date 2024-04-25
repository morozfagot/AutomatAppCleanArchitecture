using MediatR;

namespace AutomatApp.Application.Clients.Queries.ClientById
{
    public class ClientByIdQuery : IRequest<ClientByIdSuccess>
    {
        public int Id { get; set; }
    }
}
