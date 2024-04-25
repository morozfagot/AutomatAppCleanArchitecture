using MediatR;

namespace AutomatApp.Application.AdministrationClients.Queries.AllClients
{
    public class AllClientsQuery : IRequest<IEnumerable<ClientSuccess>>
    {
    }
}
