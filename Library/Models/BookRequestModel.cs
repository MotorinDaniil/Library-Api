using System.ComponentModel.DataAnnotations;
namespace Library.Models
{
    public class BookRequestModel
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime DateTaken { get; set; }
        public DateTime DateToReturn { get; set; }
    }
}
