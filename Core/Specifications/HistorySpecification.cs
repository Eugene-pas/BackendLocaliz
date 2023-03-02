using Ardalis.Specification;
using Core.DTO;
using Core.Entities.HistoryEntity;

namespace Core.Specifications;

public class HistorySpecification
{
    internal class GetRange : Specification<History>
    {
        public GetRange(uint documentId, PaginationFilterDTO paginationFilter)
        {
            Query.Where(h => h.DocumentId == documentId)
                .Include(h => h.User)
                .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                .Take(paginationFilter.PageSize);
        }

    }

    internal class GetByDocumentId : Specification<History>, ISingleResultSpecification<History>
    {
        public GetByDocumentId(uint documentId)
        {
            Query.Where(h => h.DocumentId == documentId);
        }

    }

}