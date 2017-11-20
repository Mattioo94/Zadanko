namespace Fabryka.Models
{
    class Factory
    {
        public static IVehicle Build(string type)
        {
            IVehicle vehicle = null;
            switch(type)
            {
                case "car":
                    vehicle = new Car();
                    break;
                case "motorcycle":
                    vehicle = new Motorcycle();
                    break;
                case "truck":
                    vehicle = new Truck();
                    break;
            }
            vehicle?.Build();
            return vehicle;
        }
    }
}
