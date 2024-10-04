namespace Practice1

{
    public class PoliceStation
    {
        private List<PoliceCar> policeCars;
        public string City { get; private set; }

        public PoliceStation(string city)
        {
            policeCars = new List<PoliceCar>();
            City = city;
            Console.WriteLine(WriteMessage("Created"));
        }

        public void RegisterPoliceCar(PoliceCar policeCar)
        {
            policeCars.Add(policeCar);
            policeCar.SetPoliceStation(this);
            Console.WriteLine(policeCar.WriteMessage($"Registered to the police station of {City}"));
        }

        public void ActivateAlert(string plate)
        {
            foreach (PoliceCar policeCar in policeCars)
            {
                if (policeCar.IsPatrolling())
                {
                    policeCar.StartChasing(plate);
                }
            }
        }

        public string WriteMessage(string message)
        {
            return $"{City} Police Station: {message}";
        }
    }
}
