using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExperience.DAL
{
    public abstract class BaseEntity
    {

    }

    /// <summary>
    /// abstract class for all POCO that will be used in the system
    /// that contain key  autogerated column
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks></remarks>
    public abstract class EntityAutoIncKey<T> : BaseEntity, IEntity<T>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual T Id { get; set; }
    }
    /// <summary>
    /// abstract class for all POCO that will be used in the system
    /// that contain key not autogerated column
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks></remarks>
    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual T Id { get; set; }
    }
}
