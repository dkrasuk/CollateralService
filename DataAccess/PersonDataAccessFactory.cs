using AlfaBank.AlfaCollection.Services.PersonService.DataAccess.Interface;

namespace AlfaBank.AlfaCollection.Services.PersonService.DataAccess
{
    public class PersonDataAccessFactory : IPersonDataAccessFactory
    {
        /// <summary>
        /// Gets the person data.
        /// </summary>
        /// <returns>IPersonData.</returns>
        public IPersonData GetPersonData()
        {
            return new PersonData();
        }
    }
}
