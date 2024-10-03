namespace Practice1

{
    //Los policías pertenecen a una Comisaría:  
    //Esta tiene una lista de coches de policía y puede registrar coches de policía mediante su matrícula.
    //Además, la comisaría tiene una alerta que puede activarse desde cualquier
    //coche de policía cuando se detecta un vehículo por encima de la velocidad
    //legal.El coche de policía que envíe la alarma proporcionará la matrícula del coche infractor.
    //Cuando la alerta se activa, notifica la matrícula del vehículo infractor a todos
    //los coches de policías que estén patrullando para poder ir en su búsqueda.
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
