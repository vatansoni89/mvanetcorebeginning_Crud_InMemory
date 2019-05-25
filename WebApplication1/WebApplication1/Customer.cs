using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{
    public class Customer
    {
        //[Range(1,100)]
        public int Id { get; set; }

        [Required, StringLength(10)]
        public string Name { get; set; }
    }
}