namespace Task_7;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        while (true)
        {
            
            Flight flight = new Flight();
            
            flight.ShowFlightInfo();
            
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
            
            flight.ShowFlightInfo();
            Console.WriteLine("Идет продажа билетов! Подождите...");
            Thread.Sleep(3000);
            flight.SetPassengers(random.Next(1,1000));
            Console.WriteLine($"Готово! Продано билетов: {flight.Passengers}\n");
            Console.Clear();

            for (int i = 1; flight.Positions > 0; i++)
            {
                Console.WriteLine($"{flight.Positions} пассажиров ожидают посадку на поезд");
                Console.WriteLine($"Добавление нового вагона в поезд... Введите сколько в вагоне мест: ");
                Carriage carriage = new Carriage();
                carriage.SetCarriageName(Convert.ToString(i));
                int inputPositionNumber = Convert.ToInt32(Console.ReadLine());
                carriage.SetCapacity(inputPositionNumber);
                carriage.SetFreePositions(flight);
                flight.ChangePositions(carriage.Capacity);
                flight.AddCarriage(carriage);
                if (flight.Positions == 0)
                    break;

                Console.Clear();
            }
            
            flight.ShowFlightInfo();
            
            Console.WriteLine("\nОтправить поезд?");
            string inputAnswerYesOrNo = Console.ReadLine();
            if (inputAnswerYesOrNo == "yes")
            {
                Console.Clear();
                flight.ShowFlightInfo();
            }
            else if (inputAnswerYesOrNo == "no")
            {
                break;
            }
            

            
            Console.ReadLine();
            Console.Clear();
        }
    }
}