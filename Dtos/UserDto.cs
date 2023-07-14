using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net7_demo_api.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public string? UserCode { get; init; }
        public string? UserName { get; init; }
        public string? MobileNo { get; init; }
        public string? FirstName { get; init; }
		public string? LastName { get; init; }
        public string? FullName { get { return $"{FirstName} {LastName}"; } }
        public string? DeletedBy { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}