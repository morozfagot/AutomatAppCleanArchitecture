using AutomatApp.Application.AdministrationClients.Commands.CreateClient;
using AutomatApp.Application.AdministrationClients.Commands.UpdateClient;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutomatApp.Presentation.Controllers
{
    public class AdministrationClientController(ISender sender) : Controller
    {

        [HttpGet]
        public async Task<IActionResult> List(CancellationToken cancellationToken)
        {
            ViewData["Title"] = "Список клиентов";

            var model = await sender.Send(new AllClientsQuery(), cancellationToken);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClientCommand input, CancellationToken cancellationToken)
        {
            try
            {
                var model = await sender.Send(input, cancellationToken);

                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateClientCommand input, CancellationToken cancellationToken)
        {
            try
            {
                var model = await sender.Send(input, cancellationToken);

                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}