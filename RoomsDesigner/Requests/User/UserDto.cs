using System.Collections.Generic;

namespace RoomsDesigner.Api.Requests.User
{
    public class UserDto
    {
        public bool IsAuthenticated { get; set; }

        public string Scheme { get; set; }

        public List<object> Claims { get; set; } = new List<object>();
    }
}
