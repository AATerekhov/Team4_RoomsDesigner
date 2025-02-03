using Microsoft.AspNetCore.Authorization;

namespace RoomsDesigner.Api.Authorization
{
    public class MinAgeRequirement : IAuthorizationRequirement
    {
        public MinAgeRequirement(int minAge)
        {
            MinAge = minAge;
        }

        public int MinAge { get; }
    }
}
