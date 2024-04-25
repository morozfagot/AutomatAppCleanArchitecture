using AutoMapper;
using AutomatApp.Domain.InterfacesRepository;
using MediatR;

namespace AutomatApp.Application.AdministrationClients.Commands.DeleteClient
{
    internal class DeleteClientCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        : IRequestHandler<DeleteClientCommand, DeleteClientSuccess>
    {
        public async Task<DeleteClientSuccess> Handle(DeleteClientCommand request,
            CancellationToken cancellationToken = default)
        {
            var client = await repositoryManager.ClientRepository.GetClientByIdAsync(request.Id, cancellationToken);

            repositoryManager.ClientRepository.DeleteClient(client);
            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            var result = mapper.Map<DeleteClientSuccess>(client);

            return result;
        }
    }
}
