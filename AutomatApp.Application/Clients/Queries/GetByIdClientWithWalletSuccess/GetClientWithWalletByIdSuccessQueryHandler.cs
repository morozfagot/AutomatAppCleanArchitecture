using AutoMapper;
using AutomatApp.Domain.InterfacesRepository;
using MediatR;

namespace AutomatApp.Application.Clients.Queries.GetByIdClientWithWalletSuccess
{
    internal class GetClientWithWalletByIdSuccessQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        : IRequestHandler<GetClientWithWalletByIdSuccessQuery, GetClientWithWalletByIdSuccess>
    {
        public async Task<GetClientWithWalletByIdSuccess> Handle(GetClientWithWalletByIdSuccessQuery request,
            CancellationToken cancellationToken = default)
        {
            var client = await repositoryManager.ClientRepository.GetClientWithWalletByIdAsync(request.Id, cancellationToken);
            var result = mapper.Map<GetClientWithWalletByIdSuccess>(client);

            return result;
        }
    }
}
