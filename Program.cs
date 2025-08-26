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

    private static void CreateRoutePoints(Flight flight)
    {
        Console.WriteLine("Введите пункт отправления: ");
        string? stationOne = Console.ReadLine();
        if (stationOne != null)
            flight.SetFlightStationOne(stationOne);
        else
            Console.WriteLine("Пропущена первая станция!");
        Console.Clear();

        flight.ShowFlightInfo();
        Console.WriteLine("Введите пункт назначения: ");
        string? stationTwo = Console.ReadLine();
        if (stationTwo != null)
            flight.SetFlightStationTwo(stationTwo);
        else
            Console.WriteLine("Пропущена первая станция!");
        Console.Clear();
    }

    private static void CreateAndFillPlaces(Flight flight)
    {
        Random random = new Random();
        flight.ShowFlightInfo();
        Console.WriteLine("Идет продажа билетов! Подождите...");
        Thread.Sleep(3000);
        flight.SetPassengers(random.Next(1, 1000));
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
            flight.ChangePositions(carriage.Capacity);
            flight.AddCarriage(carriage);
            if (flight.Positions == 0)
                break;

            Console.Clear();
        }
    }
}