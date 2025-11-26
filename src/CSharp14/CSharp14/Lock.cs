namespace CSharp14;

public class BikeStock
{
    readonly object lockObject = new();
    int bikesInStock = 100;
    
    public void UpdateBikeStock(int numberOfBikes)
    {
        // Acquire the lock
        lock (lockObject)
        {
            bikesInStock += numberOfBikes;
        }
    }
    public int BikesInStock => bikesInStock;
}

public class BikeStockWithLock
{
    readonly Lock lockObject = new();
    int bikesInStock = 100;
    
    public void UpdateBikeStock(int numberOfBikes)
    {
        // Acquire the lock
        lock (lockObject)
        {
            bikesInStock += numberOfBikes;
        }
        // using (lockObject.EnterScope())
        // {
        //     bikesInStock += numberOfBikes;
        // }
    }
    public int BikesInStock => bikesInStock;
}

/*
 
public sealed class Lock 
{
   public Lock();
   public bool IsHeldByCurrentThread 
   {
       get;
   }
   public void Enter();
   public Scope EnterScope();
   public void Exit();
   public bool TryEnter();
   public ref struct Scope {
       public void Dispose();
   }
}

var mutex = new System.Threading.Lock();
lock (mutex)
{
   Console.WriteLine("Inside the critical section.");
}

Lock.Scope scope = new Lock().EnterScope();
try
{
   Console.WriteLine("Inside the critical section.");
}
finally
{
   scope.Dispose();
}

*/