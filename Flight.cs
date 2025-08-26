namespace Task_7;

public class Flight
{
    private int _passengers;
    private List<Carriage> _train = new();
    public int Positions { get; private set; }
    public string? FlightStationOne { get; private set; }
    public string? FlightStationTwo { get; private set; }
    public bool FlightStatus { get; private set; } = false;

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

    public void SetPassengers(int passengers)
    {
        Passengers = passengers;
        Positions = Passengers; // Правильно ли так делать? Позаимствовал свойство
    }

    public void SetFlightStationOne(string flightStation)
    {
        FlightStationOne = flightStation;
    }

    public void SetFlightStationTwo(string flightStation)
    {
        FlightStationTwo = flightStation;
    }

    public void ChangePositions(int count)
    {
        Positions -= count;
    }

    public void SendFlight()
    {
        FlightStatus = true;
    }

    public void AddCarriage(Carriage carriage)
    {
        _train.Add(carriage);
    }

    public void ShowFlightInfo()
    {
        if (FlightStationOne != null)
        {
            Console.WriteLine($"Направления поезда: {FlightStationOne} - {FlightStationTwo}");
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

        if (FlightStatus)
        {
            Console.WriteLine($"Поезд отбывает со станции {FlightStationOne} в направлении {FlightStationTwo}");
        }
    }
}