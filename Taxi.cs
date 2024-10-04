namespace Practice1
{
    public class Taxi : Vehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances.
        private static string typeOfVehicle = "Taxi";
        private bool isCarryingPassengers;
        private string plate;

        public Taxi(string plate) : base(typeOfVehicle)
        {
            //Values of atributes are set just when the instance is done if not needed before.
            isCarryingPassengers = false;
            this.plate = plate;
            SetSpeed(45.0f);
            Console.WriteLine(WriteMessage("Created"));
        }

        public string GetPlate()
        {
            return plate;
        }

        public void StartRide()
        {
            if (!isCarryingPassengers)
            {
                isCarryingPassengers = true;
                SetSpeed(100.0f);
                Console.WriteLine(WriteMessage("starts a ride."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already in a ride."));
            }
        }

        public void StopRide()
        {
            if (isCarryingPassengers)
            {
                isCarryingPassengers = false;
                SetSpeed(45.0f);
                Console.WriteLine(WriteMessage("finishes ride."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is not on a ride."));
            }
        }

        public override string WriteMessage(string message)
        {
            return $"{GetTypeOfVehicle()} with plate {GetPlate()}: {message}";
        }
    }
}