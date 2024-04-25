using AutoMapper;
using AutomatApp.Domain.InterfacesRepository;
using MediatR;

namespace AutomatApp.Application.AdministrationClients.Queries.AllClients
{
    internal class AllClientsQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        : IRequestHandler<AllClientsQuery, IEnumerable<ClientSuccess>>
    {
        public async Task<IEnumerable<ClientSuccess>> Handle(AllClientsQuery request,
            CancellationToken cancellationToken = default)
        {
            var clients = await repositoryManager.ClientRepository.GetAllClientsAsync(cancellationToken);
            var result = mapper.Map<IEnumerable<ClientSuccess>>(clients);

            return result;
        }
    }
}
