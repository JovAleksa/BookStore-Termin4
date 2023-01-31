using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    [NotMapped]
    public class BookModel
    {

        [Required]
        public String Name { get; set; }
        public static int brojacID = 0;
        public  int id { get; set; }

        public Genre genre { get; set; }
        public enum Genre { Science =1, Comedy=2, Horror=3 }
        [Required]
        public Double Price { get; set; }
        public bool Deleted { get; set; }

     
        public BookModel()
        {
            brojacID++;
            id = brojacID;
            

        }

    }
}
