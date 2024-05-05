using System.ComponentModel.DataAnnotations;

namespace KubaBlogApi.DataAccessLayer
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
