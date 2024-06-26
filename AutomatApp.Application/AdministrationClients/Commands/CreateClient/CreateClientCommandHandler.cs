﻿using AutoMapper;
using AutomatApp.Domain.Entities;
using AutomatApp.Domain.InterfacesRepository;
using MediatR;

namespace AutomatApp.Application.AdministrationClients.Commands.CreateClient
{
    internal class CreateClientCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        : IRequestHandler<CreateClientCommand, CreateClientSuccess>
    {
        public async Task<CreateClientSuccess> Handle(CreateClientCommand request,
            CancellationToken cancellationToken = default)
        {
            var client = mapper.Map<Client>(request);

            repositoryManager.ClientRepository.CreateClient(client);
            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            var result = mapper.Map<CreateClientSuccess>(client);

            return result;
        }
    }
}
