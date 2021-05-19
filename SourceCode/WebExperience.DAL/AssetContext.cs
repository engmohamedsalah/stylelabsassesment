using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebExperience.DAL
{
    /// <summary>
    /// data base context for used for ORM
    /// </summary>
    /// <remarks></remarks>
    public class AssetContext : DbContext
    {
        public AssetContext()
            : base("Name=DefaultConnection")
        {

        }
        //Table Asset
        public DbSet<Asset> Assets { get; set; }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// and update the editable column
        /// </summary>
        /// <returns>
        /// The number of state entries written to the underlying database. This can include
        ///             state entries for entities and/or relationships. Relationship state
        /// entries are created for 
        ///             many-to-many relationships and relationships where there is no
        /// foreign key property
        ///             included in the entity class (often referred to as independent
        /// associations).
        /// </returns>
        /// <exception cref="System.InvalidOperationException">
        ///             Some error occurred attempting to process entities in the context
        /// either before or after sending commands
        ///             to the database.
        ///             </exception>
        /// <exception cref="System.ObjectDisposedException">The context or connection have
        /// been disposed.</exception>
        /// <exception cref="System.NotSupportedException">
        ///             An attempt was made to use unsupported behavior such as executing
        /// multiple asynchronous commands concurrently
        ///             on the same context instance.</exception>
        /// <exception cref="System.Data.Entity.Validation.DbEntityValidationException">
        ///             The save was aborted because validation of entity property values
        /// failed.
        ///             </exception>
        /// <exception cref="System.Data.Entity.Infrastructure.DbUpdateConcurrencyException">
        ///             A database command did not affect the expected number of rows. This
        /// usually indicates an optimistic 
        ///             concurrency violation; that is, a row has been changed in the
        /// database since it was queried.
        ///             </exception>
        /// <exception cref="System.Data.Entity.Infrastructure.DbUpdateException">An error
        /// occurred sending updates to the database.</exception>
        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity
                    && (x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                IAuditableEntity entity = entry.Entity as IAuditableEntity;
                if (entity != null)
                {
                    string identityName = Thread.CurrentPrincipal.Identity.Name;
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == System.Data.Entity.EntityState.Added)
                    {
                        if (string.IsNullOrEmpty(entity.CreatedBy))
                            entity.CreatedBy = identityName;
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.UpdatedBy = identityName;
                    entity.UpdatedDate = now;
                }
            }

            return base.SaveChanges();
        }
    }
}
