using Core.Entities;

namespace Core.Specifications
{
    public class UserForCountingSpecification : Specification<User>
    {
        public UserForCountingSpecification(UserSpecificationParams userParams) : base(x =>
        (string.IsNullOrEmpty(userParams.Search) || x.Name.Contains(userParams.Search)) &&
        (string.IsNullOrEmpty(userParams.Name) || x.Name.Contains(userParams.Name)) &&
        (string.IsNullOrEmpty(userParams.LastName) || x.LastName.Contains(userParams.LastName)))
        { }
    }
}