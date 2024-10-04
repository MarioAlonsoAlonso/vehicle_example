namespace Practice1
{
    internal class Program
    {

        static void Main()
        {
            City city = new City("Soria"); //A police station in the city is also created

            PoliceCar policeCar1 = new PoliceCar("0001 CNP", true);
            PoliceCar policeCar2 = new PoliceCar("0002 CNP", false);
            Taxi taxi1 = new Taxi("0001 AAA");
            Taxi taxi2 = new Taxi("0002 BBB");
            
            city.policeStation.RegisterPoliceCar(policeCar1);
            city.policeStation.RegisterPoliceCar(policeCar2);
            city.AddTaxi(taxi1);
            city.AddTaxi(taxi2);

            policeCar2.UseRadar(taxi1);

            taxi1.StartRide();
            policeCar1.StartPatrolling();
            policeCar2.StartPatrolling();
            policeCar1.UseRadar(taxi1);

            city.RemoveTaxi(taxi1);
        }
    }
}
    

