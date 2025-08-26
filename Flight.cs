namespace Task_7;

public class Flight
{
    private int _passengers;
    private List<Carriage> _train = new();
    public int Positions { get; private set; }
    public string? DepartureStation { get; private set; }
    public string? ArrivalStation { get; private set; }
    public bool IsDeparted { get; private set; } = false;

    public int Passengers
    {
        get { return _passengers; }
        set
        {
            if (value > 0)
                _passengers = value;
            else
                Console.WriteLine("Passengers count can't be negative");
        }
    }

    public void SetPassengersAndResetPositions(int passengers)
    {
        Passengers = passengers;
        Positions = Passengers;
    }

    public void SetDepartureStation(string flightStation)
    {
        DepartureStation = flightStation;
    }

    public void SetArrivalStation(string flightStation)
    {
        ArrivalStation = flightStation;
    }

    public void ChangePositions(int count)
    {
        Positions -= count;
    }

    public void SendFlight()
    {
        IsDeparted = true;
    }

    public void AddCarriage(Carriage carriage)
    {
        _train.Add(carriage);
    }

    public void ShowFlightInfo()
    {
        if (DepartureStation != null)
        {
            Console.WriteLine($"Направления поезда: {DepartureStation} - {ArrivalStation}");
        }

        if (Passengers > 0)
        {
            Console.WriteLine($"Количество пассажиров: {Passengers}");
        }

        if (_train.Count != 0)
        {
            foreach (Carriage carriage in _train)
            {
                Console.WriteLine($"{carriage.Id} - вместимость {carriage.Capacity}," +
                                  $" свободно {carriage.FreePositions}");
            }
        }

        if (IsDeparted)
        {
            Console.WriteLine($"Поезд отбывает со станции {DepartureStation} в направлении {ArrivalStation}");
        }
    }
}