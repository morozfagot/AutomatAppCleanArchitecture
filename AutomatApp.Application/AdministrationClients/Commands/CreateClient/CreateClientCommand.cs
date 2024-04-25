using AutoMapper;
using AutomatApp.Domain.Entities;
using MediatR;

namespace AutomatApp.Application.AdministrationClients.Commands.CreateClient
{
    public class CreateClientCommand : IRequest<CreateClientSuccess>
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public List<Coin>? Coins { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<CreateClientCommand, Client>()
                    .ForPath(c =>
                    c.Wallet.CoinCases.,
                    opt => opt.MapFrom(src => src.PortfolioCash));
            }
        }
    }
}
