using AutoMapper;
using AutomatApp.Domain.Entities;
using MediatR;

namespace AutomatApp.Application.AdministrationClients.Commands.UpdateClient
{
    public class UpdateClientCommand : IRequest<UpdateClientSuccess>
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<UpdateClientCommand, Client>();
            }
        }
    }
}
