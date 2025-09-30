namespace Task_7;

using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Flight flight = new Flight();

            CreateRoutePoints(flight);

            CreateAndFillPlaces(flight);

            flight.ShowFlightInfo();

            Console.WriteLine("\nОтправить поезд?");
            string? inputAnswerYesOrNo = Console.ReadLine();
            if (inputAnswerYesOrNo == "no")
            {
                Console.WriteLine("Рейс отменен");
                break;
            }
            else
            {
                Console.Clear();
                flight.SendFlight();
                flight.ShowFlightInfo();
            }
            Console.ReadLine();
            Console.Clear();
        }
    }

    private static string ReadStation(string promt)
    {
        Console.WriteLine(promt);
        string? station = Console.ReadLine();
        return station ?? string.Empty;
    }
    
    private static void CreateRoutePoints(Flight flight)
    {
        string departure = ReadStation("Введите станцию отправления:");
        if (!string.IsNullOrEmpty(departure))
            flight.SetDepartureStation(departure);
        else
            Console.WriteLine("Пропущена станция отправления!");
        
        Console.Clear();
        flight.ShowFlightInfo();

        string arrival = ReadStation("Введите станцию назначения");
        if (!string.IsNullOrEmpty(arrival))
            flight.SetArrivalStation(arrival);
        else
            Console.WriteLine("Пропущена станция назначения");
        
        Console.Clear();
    }

    private static void CreateAndFillPlaces(Flight flight)
    {
        Random random = new Random();
        flight.ShowFlightInfo();
        Console.WriteLine("Идет продажа билетов! Подождите...");
        Thread.Sleep(3000);
        flight.SetPassengersAndResetPositions(random.Next(1, 1000));
        Console.WriteLine($"Готово! Продано билетов: {flight.Passengers}\n");
        Console.Clear();

        for (int i = 1; flight.Positions > 0; i++)
        {
            Console.WriteLine($"{flight.Positions} пассажиров ожидают посадку на поезд");
            Console.WriteLine($"Добавление нового вагона в поезд... Введите сколько в вагоне мест: ");
            Carriage carriage = new Carriage();
            carriage.SetCarriageId(Convert.ToString(i));
            carriage.SetCapacity();
            carriage.SetFreePositions(flight);
            flight.RemovePositions(int.Min(flight.Positions, carriage.Capacity));
            flight.AddCarriage(carriage);
            if (flight.Positions == 0)
                break;

            Console.Clear();
        }
    }
}