using AutoMapper;
using AutomatApp.Domain.Entities;

namespace AutomatApp.Application.AdministrationClients.Commands.UpdateClient
{
    public class UpdateClientSuccess
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Client, UpdateClientSuccess>();
            }
        }
    }
}
