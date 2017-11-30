namespace AlfaBank.AlfaCollection.Services.PersonService.DataAccess.Interface
{
    public interface IPersonDataAccessFactory
    {
        /// <summary>
        /// Gets the person data.
        /// </summary>
        /// <returns>IPersonData.</returns>
        IPersonData GetPersonData();
    }
}
