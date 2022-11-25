using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace grzejemy.Models
{
    public class FuelType
    { 
        public FuelType()
        {
            Name = string.Empty;
        }


        //[Key]
        public int Id { get; private set; }

        [Column]
        private string Name { get; set; }
    }
}
