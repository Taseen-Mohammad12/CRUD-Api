using System.ComponentModel.DataAnnotations;

namespace APICurd.Model
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string ?FirstName { get; set; }

        public string? LastName { get; set; }

        public int phoneNo { get; set; }

        public string? EmailId { get; set; }
    }
}
