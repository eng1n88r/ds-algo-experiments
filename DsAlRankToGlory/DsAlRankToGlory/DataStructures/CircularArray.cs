namespace DsAlRankToGlory.DataStructures;

public class CircularArray<T>
{
    private T[] _array;
    private int _head; // Points to the oldest data
    private int _tail; // Points to the next insertion point
    private int _count; // Number of elements in the array

    public CircularArray(int capacity)
    {
        if (capacity <= 0)
        {
            throw new ArgumentException("Capacity must be greater than zero.");
        }

        _array = new T[capacity];
        _head = 0;
        _tail = 0;
        _count = 0;
    }

    public int Count => _count;
    public int Capacity => _array.Length;
    
    public void Add(T item)
    {
        _array[_tail] = item; // Add item at the tail position
        _tail = (_tail + 1) % _array.Length; // Move the tail forward

        if (_count == _array.Length) // If full, move head forward (override oldest)
        {
            _head = (_head + 1) % _array.Length;
        }
        else
        {
            _count++;
        }
    }
    
    public T Remove()
    {
        if (_count == 0)
        {
            throw new InvalidOperationException("Circular array is empty.");
        }

        T item = _array[_head];
        _array[_head] = default; // Clear the reference
        _head = (_head + 1) % _array.Length;
        _count--;
        return item;
    }
    
    public T Peek()
    {
        if (_count == 0)
        {
            throw new InvalidOperationException("Circular array is empty.");
        }

        return _array[_head];
    }
    
    public T[] ToArray()
    {
        T[] result = new T[_count];
        for (int i = 0; i < _count; i++)
        {
            result[i] = _array[(_head + i) % _array.Length];
        }
        return result;
    }
}