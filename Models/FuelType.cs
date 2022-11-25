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

        public int Id { get; set; }

        public string Name { get; set; }

        
    }
}
