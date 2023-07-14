using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net7_demo_api.Entities
{
    public record IBaseEntityWithDelete : IBaseEntiity
    {
        // [Column(TypeName = "TimestampTz")]
        public string? DeletedBy { get; set; }
        public DateTime DeletedAt { get; set; }
        
    }
}