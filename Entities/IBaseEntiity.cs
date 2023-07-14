using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace net7_demo_api.Entities
{
    public record IBaseEntiity
    {
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public bool Valid { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}