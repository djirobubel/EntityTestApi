using MediatR;

namespace EntityTestApi.Queries.GetEntity
{
    public class GetEntityQuery : IRequest<GetEntityResult>
    {
        public Guid Id { get; set; }

        public GetEntityQuery(Guid id)
        {
            Id = id;
        }
    }
}
