using System.ComponentModel.DataAnnotations;

namespace XmlApi.Models
{
    public class Products
    {

        [Key]
        public int id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
      

    }
}
