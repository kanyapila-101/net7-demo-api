using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net7_demo_api.Entities
{
    public class UserModel : IBaseEntityWithDelete
    {
        public string? UserCode { get; init; }
        public string? UserName { get; init; }
        public string? MobileNo { get; init; }
        public string? FirstName { get; init; }
		public string? LastName { get; init; }
        public string? FullName { get { return $"{FirstName} {LastName}"; } }
    }
}