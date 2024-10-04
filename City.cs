namespace Practice1

{
    class City: IMessageWritter
    {
        private string name;
        private List<Taxi> taxis;
        public PoliceStation policeStation;

        public City(string name)
        {
            this.name = name;
            taxis = new List<Taxi>();
            policeStation = new PoliceStation(name);
            Console.WriteLine(WriteMessage($"{name} Created"));
        }

        public void AddTaxi(Taxi taxi)
        {
            taxis.Add(taxi);
            Console.WriteLine(taxi.WriteMessage($"Added to {name}"));
        }

        public void RemoveTaxi(Taxi taxi)
        {
            taxis.Remove(taxi);
            Console.WriteLine(taxi.WriteMessage($"Removed from {name}"));
        }

        public string WriteMessage(string message)
        {
            return $"City {name} {message}";
        }
    }
}
