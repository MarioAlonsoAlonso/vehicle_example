namespace Practice1
{
    class PoliceCar : Vehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car";
        private bool isPatrolling;
        private bool isChasing;
        private string plate;
        private SpeedRadar? speedRadar;
        public PoliceStation? policeStation;

        public PoliceCar(string plate, bool radar) : base(typeOfVehicle)
        {
            this.plate = plate;
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

        public string GetPlate()
        {
            return plate;
        }

        public void UseRadar(Taxi taxi)
        {
            if (speedRadar is SpeedRadar)
            {
                if (isPatrolling)
                {
                    speedRadar.TriggerRadar(taxi);
                    string meassurement = speedRadar.GetLastReading();
                    Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
                    if (meassurement.Contains("above"))
                    {
                        StartChasing(taxi.GetPlate());
                        PoliceStation? policeStation = GetPoliceStation();
                        if (policeStation != null)
                        {
                            policeStation.ActivateAlert(taxi.GetPlate());
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