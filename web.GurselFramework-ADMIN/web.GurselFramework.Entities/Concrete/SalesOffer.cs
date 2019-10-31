using web.GurselFramework.Core.Entities;

namespace web.GurselFramework.Entities.Concrete
{
    public class SalesOffer : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string NameSurname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
