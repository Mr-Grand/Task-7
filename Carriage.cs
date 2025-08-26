namespace Task_7;

public class Carriage
{
    public string Id { get; private set; } = "Вагон №";
    public int Capacity { get; private set; }
    public int FreePositions { get; private set; }

    public void SetCarriageId(string id)
    {
        Id += id;
    }

    public void SetCapacity()
    {
        Console.WriteLine("Введите количество мест в вагоне: ");
        int inputPositionNumber;
        bool ifCorrect = int.TryParse(Console.ReadLine(), out inputPositionNumber);
        if (ifCorrect && inputPositionNumber > 0)
        {
            Capacity = inputPositionNumber;
        }
        else
        {
            Console.WriteLine("Введите корректное значение!");
            SetCapacity();
        }
    }

    public void SetFreePositions(Flight flightObject)
    {
        if (flightObject.Positions >= Capacity)
            FreePositions = 0;
        else
            FreePositions = Capacity - flightObject.Positions;
    }
}