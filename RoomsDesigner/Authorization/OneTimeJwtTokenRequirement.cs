using Microsoft.AspNetCore.Authorization;

namespace RoomsDesigner.Api.Authorization
{
    public class OneTimeJwtTokenRequirement : IAuthorizationRequirement
    {
        public OneTimeJwtTokenRequirement(string redisKeyPrefix)
        {
            RedisKeyPrefix = redisKeyPrefix;
        }
        public string RedisKeyPrefix { get; }
    }
}
