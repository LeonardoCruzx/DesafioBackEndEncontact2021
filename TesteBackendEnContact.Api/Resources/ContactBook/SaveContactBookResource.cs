namespace TesteBackendEnContact.Api.Resources.ContactBook
{
    public class SaveContactBookResource
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CompanyId { get; set; }

        public SaveContactBookResource(){}
        public SaveContactBookResource (SaveContactBookResource saveContactBookResource)
        {
            Name = saveContactBookResource.Name;
            Description = saveContactBookResource.Description;
            CompanyId = saveContactBookResource.CompanyId;
        }
    }
}