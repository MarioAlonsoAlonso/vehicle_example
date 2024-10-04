namespace Practice1
{
    class PoliceCar : Vehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car";
        private bool isPatrolling;
        private bool isChasing;
        private SpeedRadar? speedRadar;
        public PoliceStation? policeStation;

        public PoliceCar(string plate, bool radar) : base(typeOfVehicle, plate)
        {
            policeStation = null;
            isChasing = false;
            isPatrolling = false;
            if (radar)
            {
                speedRadar = new SpeedRadar();
            }
            else
            {
                speedRadar = null;
            }
        }

        public PoliceStation GetPoliceStation()
        {
            return policeStation;
        }

        public void SetPoliceStation(PoliceStation policeStation)
        {
            this.policeStation = policeStation;
        }




        public void UseRadar(Vehicle vehicle)
        {
            if (speedRadar is SpeedRadar)
            {
                if (isPatrolling)
                {
                    speedRadar.TriggerRadar(vehicle);
                    string meassurement = speedRadar.GetLastReading();
                    Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
                    if (meassurement.Contains("above"))
                    {
                        StartChasing(vehicle.GetPlate());
                        PoliceStation? policeStation = GetPoliceStation();
                        if (policeStation != null)
                        {
                            policeStation.ActivateAlert(vehicle.GetPlate());
                        }
                    }
                }
                else
                {
                    Console.WriteLine(WriteMessage($"has no active radar."));
                }
            }
            else
            {
                Console.WriteLine(WriteMessage($"has no radar."));
            }
        }

        public bool IsPatrolling()
        {
            return isPatrolling;
        }

        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                Console.WriteLine(WriteMessage("stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("was not patrolling."));
            }
        }

        public void PrintRadarHistory()
        {
            if (speedRadar is SpeedRadar)
            {
                Console.WriteLine(WriteMessage("Report radar speed history:"));
                foreach (float speed in speedRadar.SpeedHistory)
                {
                    Console.WriteLine(speed);
                }
            }
            else
            {
                Console.WriteLine(WriteMessage("has no radar."));
            }
        }

        public void StartChasing(string plate)
        {
            if (isChasing)
            {
                Console.WriteLine(WriteMessage("is already chasing."));
            }
            else
            {
                isChasing = true;
                Console.WriteLine(WriteMessage($"started chasing {plate}."));
            }
        }
    }
}