using Ardalis.Specification;
using Core.Entities.ProjectUserEntity;
using Core.Entities.UserEntity;

namespace Core.Specifications;

public class ProjectUserSpecification
{
    internal class GetProjectsByUserId : Specification<ProjectUser>
    {
        public GetProjectsByUserId(string userId)
        {
            Query.Where(p => p.UserId == userId)
                .Include(p => p.Project);
        }
    }

    internal class GetProjectByUserId : Specification<ProjectUser>, ISingleResultSpecification<ProjectUser>
    {
        public GetProjectByUserId(string userId)
        {
            Query.Where(p => p.UserId == userId);
        }
    }
}