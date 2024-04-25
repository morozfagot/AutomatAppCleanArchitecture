using AutoMapper;
using AutomatApp.Domain.InterfacesRepository;
using MediatR;

namespace AutomatApp.Application.Clients.Queries.ClientById
{
    internal class ClientByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        : IRequestHandler<ClientByIdQuery, ClientByIdSuccess>
    {
        public async Task<ClientByIdSuccess> Handle(ClientByIdQuery request,
            CancellationToken cancellationToken = default)
        {
            var client = await repositoryManager.ClientRepository.GetClientByIdAsync(request.Id, cancellationToken);
            var result = mapper.Map<ClientByIdSuccess>(client);

            return result;
        }
    }
}
