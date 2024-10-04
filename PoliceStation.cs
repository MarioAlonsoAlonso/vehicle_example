namespace Practice2

{
    public class PoliceStation
    {
        private List<PoliceCar> policeCars;

        public PoliceStation()
        {
            policeCars = new List<PoliceCar>();
        }

        public void RegisterPoliceCar(string plate)
        {
            PoliceCar policeCar = new PoliceCar(plate);
            policeCars.Add(policeCar);
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
    }
}
