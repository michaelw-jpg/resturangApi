using System.ComponentModel.DataAnnotations;

namespace resturangApi.Dto.TablesDtos
{
    public class CreateTableDto
    {

        [Required]
        public int TableNumber { get; set; }
        [Required]
        public int Seats { get; set; }
    }
}
