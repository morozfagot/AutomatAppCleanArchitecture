using AutoMapper;
using AutomatApp.Application.Wallets.Queries.GetWalletByIdSucces;
using AutomatApp.Domain.Entities;

namespace AutomatApp.Application.Clients.Queries.GetByIdClientWithWalletSuccess
{
    public class GetClientWithWalletByIdSuccess
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public GetWalletByIdSuccess Wallet { get; set; } = null;

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Client, GetClientWithWalletByIdSuccess>();
            }
        }
    }
}
