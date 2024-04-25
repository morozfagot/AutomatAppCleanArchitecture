using AutoMapper;
using AutomatApp.Domain.InterfacesRepository;
using MediatR;

namespace AutomatApp.Application.Wallets.Commands.UpdateDepositWallet
{
    internal class UpdateDepositPortfolioCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        : IRequestHandler<UpdateDepositPortfolioCommand, UpdateDepositPortfolioSuccess>
    {
        public async Task<UpdateDepositPortfolioSuccess> Handle(UpdateDepositPortfolioCommand request,
          CancellationToken cancellationToken = default)
        {
            var portfolio = await repositoryManager.PortfolioRepository.GetPortfolioByIdAsync(request.Id, cancellationToken);

            portfolio.Cash += request.Amount;

            repositoryManager.PortfolioRepository.UpdatePortfolio(portfolio);
            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            var result = mapper.Map<UpdateDepositPortfolioSuccess>((portfolio, request));

            return result;
        }
    }
}
