namespace grzejemy.Server.Models
{
    public class FuelType
    { 
        public FuelType(string name) 
        {
            Name = name;
        }

        private int Id { get; set; }

        private string Name { get; set; }
    }
}
