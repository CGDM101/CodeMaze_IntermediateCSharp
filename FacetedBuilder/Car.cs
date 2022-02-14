namespace FacetedBuilder
{
    public class Car
    {
        // The info part. (for one builder)
        public string Type { get; set; }
        public string Colour { get; set; }
        public int NumberOfDoors { get; set; }

        // The address part. (for another builder)
        public string City { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"CarType: {Type}, Colour: {Colour}, Number of doors: {NumberOfDoors}, Manufactured in {City}, at address: {Address}";
        }
    }
}
