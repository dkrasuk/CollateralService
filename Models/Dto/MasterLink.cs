namespace AlfaBank.AlfaCollection.Services.PersonService.Models.DTO
{
    public class MasterLink
    {
        public string Id { get; set; }

        public string MasterId { get; set; }

        public virtual MasterSystem MasterSystem { get; set; }

    }
}
