namespace Task_7;

public class Carriage
{
    public string Name { get; private set; }
    public int Capacity { get; private set; }
    public int FreePositions { get; private set; }
    public Flight flight;

    public void SetCarriageName(string name)
    {
        Name = "Вагон №" + name;
    }

    public void SetCapacity(int capacity) 
    {
        
        Capacity = capacity;
    }

    public void SetFreePositions(Flight flightObject)
    {
        if (flightObject.Positions >= Capacity)
            FreePositions = 0;
        else
            FreePositions = Capacity - flightObject.Positions;
    }
    
}