using AutoMapper;
using AutomatApp.Application.Wallets.Commands.UpdateBuyWallet;
using AutomatApp.Application.Wallets.Commands.UpdateDepositWallet;
using AutomatApp.Application.Wallets.Commands.UpdateWithdrawWallet;
using AutomatApp.Application.Wallets.Queries.CheckBuyWallet;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutomatApp.Presentation.Controllers
{
    public class ClientController(ISender sender, IMapper mapper) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> List(int id, CancellationToken cancellationToken)
        {
            ViewData["Title"] = "Акции";

            var model = await sender.Send(new ClientWithPortfolioByIdQuery(id), cancellationToken);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Buy(UpdateBuyWalletCommand input, CancellationToken cancellationToken)
        {
            if (await sender.Send(new CheckBuyWalletQuery(input), cancellationToken))
            {
                var model = await sender.Send(input, cancellationToken);

                return Ok(model);
            }
            else
            {
                var error = await sender.Send(new GetBuyPortfolioErrorQuery(input), cancellationToken);

                return UnprocessableEntity(error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Sell(UpdateSellPortfolioCommand input, CancellationToken cancellationToken)
        {
            if (await sender.Send(new CheckSellPortfolioCommand(input), cancellationToken))
            {
                var model = await sender.Send(input, cancellationToken);

                return Ok(model);
            }
            else
            {
                var error = await sender.Send(new GetSellPortfolioErrorQuery(input), cancellationToken);

                return UnprocessableEntity(error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Withdraw(UpdateWithdrawPortfolioCommand input, CancellationToken cancellationToken)
        {
            if (await sender.Send(new CheckWithdrawPortfolioCommand(input), cancellationToken))
            {
                var model = await sender.Send(input, cancellationToken);

                return Ok(model);
            }
            else
            {
                return UnprocessableEntity();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Deposit(UpdateDepositPortfolioCommand input, CancellationToken cancellationToken)
        {
            var model = sender.Send(input, cancellationToken);

            return Ok(model);
        }
    }
}