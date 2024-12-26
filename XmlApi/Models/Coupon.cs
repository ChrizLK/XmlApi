using System.ComponentModel.DataAnnotations;

namespace XmlApi.Models
{
    public class Coupon
    {
        
        public int Id { get; set; }
        public string Code { get; set; }
        public int Amount { get; set; }
       

    }
}
