using Ardalis.Specification;
using Core.DTO;
using Core.Entities.ContentEntity;
using Core.Entities.HistoryEntity;

namespace Core.Specifications;

public class HistoriesSpecification
{
    internal class GetRange : Specification<History>
    {
        public GetRange(uint contentId, PaginationFilterDTO paginationFilter)
        {
            Query.Where(h => h.ContentId == contentId)
                .Include(h => h.User)
                .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                .Take(paginationFilter.PageSize);
        }

    }

    internal class GetByContentId : Specification<History>, ISingleResultSpecification<History>
    {
        public GetByContentId(uint contentId)
        {
            Query.Where(h => h.ContentId == contentId);
        }

    }
}
