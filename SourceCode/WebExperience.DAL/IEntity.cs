using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExperience.DAL
{
    /// <summary>
    /// interface for any POCO that will be used in the system
    /// all object will have common  prop with name id 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks></remarks>
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
