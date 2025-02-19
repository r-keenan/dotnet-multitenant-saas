namespace Domain.Entities
{
    // This will be the tenant. Application is school management system
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EstablishedDate { get; set; }
    }
}
