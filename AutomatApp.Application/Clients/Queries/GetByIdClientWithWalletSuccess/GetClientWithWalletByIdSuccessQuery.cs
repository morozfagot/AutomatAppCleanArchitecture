using MediatR;

namespace AutomatApp.Application.Clients.Queries.GetByIdClientWithWalletSuccess
{
    public class GetClientWithWalletByIdSuccessQuery : IRequest<GetClientWithWalletByIdSuccess>
    {
        public int Id { get; set; }

        public GetClientWithWalletByIdSuccessQuery(int id) => Id = id;
    }
}
