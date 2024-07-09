using EntityTestApi.Interface;
using EntityTestApi.Models;
using MediatR;

namespace EntityTestApi.Commands.CreateEntity
{
    public class CreateEntityHandler : IRequestHandler<CreateEntityCommand, CreateEntityResult>
    {
        private readonly IEntityRepository _entityRepository;

        public CreateEntityHandler(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public async Task<CreateEntityResult> Handle(CreateEntityCommand request,
            CancellationToken cancellationToken)
        {
            Entity entity = new Entity
            {
                Id = request.Id,
                OperationDate = request.OperationDate,
                Amount = request.Amount,
            };

            await _entityRepository.CreateEntityAsync(entity);

            CreateEntityResult result = new CreateEntityResult
            {
                Message = "Successfully created and saved."
            };

            return result;
        }
    }
}
