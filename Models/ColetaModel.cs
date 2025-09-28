using System.ComponentModel.DataAnnotations;

namespace ColetaAPI.Models
{
    public class ColetaModel
    {
        [Key]
        public int ID { get; set; }
        public string Local { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Collected { get; set; } = false;
        public DateTime DateOfCreation { get; set; } = DateTime.Now.ToLocalTime();
    }
}
