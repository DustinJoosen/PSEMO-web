using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Interfaces
{
    public interface ICrudAPIService<T> where T : class
    {
        /// <summary>
        /// Asynchronously gets all entities from the API and deserializes them.
        /// </summary>
        /// <returns>IEnumerable containing all entities.</returns>
        Task<IEnumerable<T>?> GetAll();

        /// <summary>
        /// Asynchronously gets the specified entity from the API and deserializes it.
        /// </summary>
        /// <param name="id">Id of the entity to find.</param>
        /// <returns>Found entity, or null.</returns>
        Task<T?> GetById(int id);

        /// <summary>
        /// Sends a new entity to the API to be created. 
        /// </summary>
        /// <param name="dto">New entity to create.</param>
        /// <returns>The created entity.</returns>
        Task<T?> Create(T dto);
        
        /// <summary>
        /// Sends an existing entity to the API to be updated.
        /// Updates happen based on given Id.
        /// </summary>
        /// <param name="dto">Entity to update.</param>
        /// <returns>The updated entity.</returns>
        Task<T?> Update(T dto);

        /// <summary>
        /// Sends an existing entity to the API to be deleted.
        /// </summary>
        /// <param name="dto">Id of the entity to delete.</param>
        /// <returns>Boolean indicating success</returns>
        Task<bool> Delete(int id);
    }
}
