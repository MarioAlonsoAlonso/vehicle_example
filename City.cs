namespace Practice2

{
    class City: IMessageWritter
    {
        private string name;
        private List<Taxi> taxiLicenses;
        private PoliceStation policeStation;

        public City(string name)
        {
            this.name = name;
            taxiLicenses = new List<Taxi>();
            policeStation = new PoliceStation();
        }

        public void AddTaxi(Taxi taxi)
        {
            taxiLicenses.Add(taxi);
        }

        public void RemoveTaxi(Taxi taxi)
        {
            taxiLicenses.Remove(taxi);
        }

        public string WriteMessage(string message)
        {
            return $"City {name} {message}";
        }
    }
}
