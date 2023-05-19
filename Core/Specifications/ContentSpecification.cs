using Ardalis.Specification;
using Core.DTO;
using Core.Entities.ContentEntity;

namespace Core.Specifications;

public class ContentSpecification
{
    internal class GetRange : Specification<Content>
    {
        public GetRange(uint documentId, PaginationFilterDTO paginationFilter)
        {
            Query.Where(h => h.DocumentId == documentId)
                .Include(h => h.User)
                .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                .Take(paginationFilter.PageSize);
        }

    }

    internal class GetByDocumentId : Specification<Content>, ISingleResultSpecification<Content>
    {
        public GetByDocumentId(uint documentId)
        {
            Query.Where(h => h.DocumentId == documentId);
        }

    }
}
