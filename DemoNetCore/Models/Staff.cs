using System.ComponentModel.DataAnnotations;

namespace DemoNetCore.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public Sex Sex { get; set; }
        public string Address { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; }
    }
}
