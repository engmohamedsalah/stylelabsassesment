using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExperience.DAL
{
    [Table("Asset")]
    public class Asset : AuditableEntity<Guid>
    {
        //[Required]
        //public Guid AssetId { get; set; }
        [Required]
        [MaxLength(100)]
        public string FileName { get; set; }
        [MaxLength(100)]
        public string MimeType { get; set; }
        //[MaxLength(20)]
        //public string CreatedBy { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        


    }
}
