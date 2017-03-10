using OnlineShop.Libs.Models.Contracts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Libs.Data.Contracts
{
    public interface IEfQuerable<TEntity> : IQueryable<TEntity>, IEnumerable<TEntity>, IQueryable, IEnumerable where TEntity : class, IDbModel
    {
        /// <summary>
        /// Expose only element with IsDeleted == false
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAvailabe { get; }

        //
        // Summary:
        //     Finds an entity with the given primary key values. If an entity with the given
        //     primary key values exists in the context, then it is returned immediately without
        //     making a request to the store. Otherwise, a request is made to the store for
        //     an entity with the given primary key values and this entity, if found, is attached
        //     to the context and returned. If no entity is found in the context or the store,
        //     then null is returned.
        //
        // Parameters:
        //   keyValues:
        //     The values of the primary key for the entity to be found.
        //
        // Returns:
        //     The entity found, or null.
        //
        // Remarks:
        //     The ordering of composite key values is as defined in the EDM, which is in turn
        //     as defined in the designer, by the Code First fluent API, or by the DataMember
        //     attribute.
        TEntity FindByKey(params object[] keyValues);

        //
        // Summary:
        //     Adds the given entity to the context underlying the set in the Added state such
        //     that it will be inserted into the database when SaveChanges is called.
        //
        // Parameters:
        //   entity:
        //     The entity to add.
        //
        // Returns:
        //     The entity.
        //
        // Remarks:
        //     Note that entities that are already in the context in some other state will have
        //     their state set to Added. Add is a no-op if the entity is already in the context
        //     in the Added state.
        TEntity Add(TEntity entity);

        //
        // Summary:
        //     Marks the given entity as Deleted such that it will be deleted from the database
        //     when SaveChanges is called. Note that the entity must exist in the context in
        //     some other state before this method is called.
        //
        // Parameters:
        //   entity:
        //     The entity to remove.
        //
        // Returns:
        //     The entity.
        //
        // Remarks:
        //     Note that if the entity exists in the context in the Added state, then this method
        //     will cause it to be detached from the context. This is because an Added entity
        //     is assumed not to exist in the database such that trying to delete it does not
        //     make sense.
        TEntity Remove(TEntity entity);

        /// <summary>
        /// Set Entity IsDeleted to true and marks the given entity as Modified such that it will be updated 
        /// in the database when SaveChanges is called.
        /// </summary>
        /// <param name="entity">Entity to hide</param>
        void Hide(TEntity entity);
    }
}
