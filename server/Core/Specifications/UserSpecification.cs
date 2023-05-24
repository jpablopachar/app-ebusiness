using Core.Entities;

namespace Core.Specifications
{
    public class UserSpecification : Specification<User>
    {
        public UserSpecification(UserSpecificationParams userParams) : base(x =>
        (string.IsNullOrEmpty(userParams.Search) || x.Name.Contains(userParams.Search)) &&
        (string.IsNullOrEmpty(userParams.Name) || x.Name.Contains(userParams.Name)) &&
        (string.IsNullOrEmpty(userParams.LastName) || x.LastName.Contains(userParams.LastName)))
        {
            ApplyPaging(userParams.PageSize * (userParams.PageIndex - 1), userParams.PageSize);

            if (!string.IsNullOrEmpty(userParams.Sort))
            {
                switch (userParams.Sort)
                {
                    case "nameAsc":
                        AddOrderBy(param => param.Name);
                        break;
                    case "nameDesc":
                        AddOrderByDescending(param => param.Name);
                        break;
                    case "emailAsc":
                        AddOrderBy(param => param.Email);
                        break;
                    case "emailDesc":
                        AddOrderByDescending(u => u.Email);
                        break;
                    default:
                        AddOrderBy(param => param.Name);
                        break;
                }
            }
        }
    }
}