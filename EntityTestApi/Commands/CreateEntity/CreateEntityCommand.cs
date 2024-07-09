using MediatR;

namespace EntityTestApi.Commands.CreateEntity
{
    public class CreateEntityCommand : IRequest<CreateEntityResult>
    {
        public Guid Id { get; set; }
        public DateTime OperationDate { get; set; }
        public decimal Amount { get; set; }
    }
}
