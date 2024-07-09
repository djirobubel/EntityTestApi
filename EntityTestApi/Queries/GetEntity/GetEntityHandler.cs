using EntityTestApi.Interface;
using MediatR;

namespace EntityTestApi.Queries.GetEntity
{
    public class GetEntityHandler : IRequestHandler<GetEntityQuery, GetEntityResult>
    {
        private readonly IEntityRepository _entityRepository;

        public GetEntityHandler(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public async Task<GetEntityResult> Handle(GetEntityQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _entityRepository.GetEntityAsync(request.Id);

            GetEntityResult result = new GetEntityResult
            {
                Id = entity.Id,
                OperationDate = entity.OperationDate,
                Amount = entity.Amount,
            };

            return result;
        }
    }
}
