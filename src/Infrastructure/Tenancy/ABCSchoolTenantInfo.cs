using Finbuckle.MultiTenant.Abstractions;

namespace Infrastructure.Tenancy
{
    public class ABCSchoolTenantInfo : ITenantInfo
    {
        public string Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        // To their own db or a db with multiple tenants in it
        public string ConnectionString { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // Date Subscription Expires
        public DateTime ValidUpTo { get; set; }
        // Is their subscription active?
        public bool IsActive { get; set; }
    }
}
