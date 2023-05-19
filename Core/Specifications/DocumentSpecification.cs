using Ardalis.Specification;
using Core.Entities.DocumentEntity;

namespace Core.Specifications;

public class DocumentSpecification
{
    internal class GetDocumentByProjectId : Specification<Document>
    {
        public GetDocumentByProjectId(uint projectId)
        {
            Query.Where(p => p.ProjectId == projectId);
        }
    }

    internal class GetDocumentWithHistories 
        : Specification<Document>, ISingleResultSpecification<Document>
    {
        public GetDocumentWithHistories(uint documentId)
        {
            Query.Where(p => p.Id == documentId)
                .Include(d => d.Contents);
        }
    }
}
