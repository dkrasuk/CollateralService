using System.Collections.Generic;
using Models.DTO;

namespace AlfaBank.AlfaCollection.Services.PersonService.DataAccess.Interface
{
    public interface IPersonData
    {
        /// <summary>
        /// Determines whether is person exist by the specified master link.
        /// </summary>
        /// <param name="masterLink">The master link.</param>
        /// <param name="MasterSystem.Id">The master system identifier.</param>
        /// <returns><c>true</c> if [is person exist] [the specified master link]; otherwise, <c>false</c>.</returns>
        bool IsPersonExist(string masterLink, string masterSystemId);

        /// <summary>
        /// Updates the person.
        /// </summary>
        /// <param name="person">The person.</param>
        void UpdatePerson(Person person);

        /// <summary>
        /// Creates the person.
        /// </summary>
        /// <param name="person">The person.</param>
        void CreatePerson(Person person);
    }
}
