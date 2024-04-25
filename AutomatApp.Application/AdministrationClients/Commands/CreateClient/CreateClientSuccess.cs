using AutoMapper;
using AutomatApp.Domain.Entities;

namespace AutomatApp.Application.AdministrationClients.Commands.CreateClient
{
    public class CreateClientSuccess
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Client, CreateClientSuccess>();
            }
        }
    }
}
