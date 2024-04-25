using MediatR;

namespace AutomatApp.Application.AdministrationClients.Commands.DeleteClient
{
    public class DeleteClientCommand : IRequest<DeleteClientSuccess>
    {
        public int Id { get; set; }
    }
}
