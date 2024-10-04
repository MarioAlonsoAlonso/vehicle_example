namespace Practice1
{
    class Scooter : Vehicle
    {
        private const string typeOfVehicle = "Scooter";

        public Scooter() : base(typeOfVehicle)
        {
            Console.WriteLine(WriteMessage("Created"));
        }
    }
}
