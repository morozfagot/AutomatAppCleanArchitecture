using AutoMapper;
using AutomatApp.Application.Wallets.Queries.GetBuyWalletError;
using AutomatApp.Domain.InterfacesRepository;
using MediatR;

namespace AutomatApp.Application.Wallets.Commands.UpdateBuyWalletById
{
    internal class UpdateBuyWalletByIdCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        : IRequestHandler<UpdateBuyWalletByIdCommand, UpdateBuyWalletByIdSuccess>
    {
        public async Task<UpdateBuyWalletByIdSuccess> Handle(UpdateBuyWalletByIdCommand request,
            CancellationToken cancellationToken = default)
        {
            var wallet = await repositoryManager.WalletRepository.GetWalletByIdAsync(request.Id, cancellationToken);

            repositoryManager.WalletRepository.UpdateWallet(wallet);
            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            var result = mapper.Map<UpdateBuyWalletByIdSuccess>((wallet, request));

            return result;
        }
    }
}
