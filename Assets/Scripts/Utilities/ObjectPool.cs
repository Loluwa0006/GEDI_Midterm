using System.Collections.Generic;
public class ObjectPool<T> where T: class
{
    Queue<T> pool;

    public void AddToPool(T obj)
    {
        pool.Enqueue(obj);
    }

    public T GetNewObject()
    {
        var obj = pool.Dequeue();
        pool.Enqueue(obj);
        return obj;
    }
}
