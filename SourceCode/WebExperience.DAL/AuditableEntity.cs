using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExperience.DAL
{
    /// <summary>
    /// abstract class for all POCO that need editable columns
    /// that used for audit the record 
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    /// <remarks>ScaffoldColumn(false) is used So that 
    /// ASP.NET MVC Scaffolding will NOT generate controls for this in Views</remarks>
    public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity
    {
        [ScaffoldColumn(false)]
        public DateTime? CreatedDate { get; set; }
        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? UpdatedDate { get; set; }

        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string UpdatedBy { get; set; }
    }
}
