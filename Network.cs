using System;
using System.Collections.Generic;

class Network
{
    private readonly int _numberOfElements;
    private readonly Dictionary<int, HashSet<int>> _relationship;

    /// <summary>
    /// Initializes a new instance of the Network class with the specified number of elements.
    /// </summary>
    /// <param name="numberOfElements"></param>
    public Network(int numberOfElements)
    {
        ValidateNumber(numberOfElements, nameof(numberOfElements));

        _numberOfElements = numberOfElements;
        _relationship = new Dictionary<int, HashSet<int>>();

        for (int i = 1; i <= numberOfElements; i++)
        {
            _relationship[i] = new HashSet<int>();
        }
    }

    /// <summary>
    /// Connect two elements in set.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    public void Connect(int a, int b)
    {
        ValidateElement(a);
        ValidateElement(b);

        if (a != b)
        {
            _relationship[a].Add(b);
            _relationship[b].Add(a);
        }
    }

    /// <summary>
    /// Disconnect two elements in set.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    public void Disconnect(int a, int b)
    {
        ValidateElement(a);
        ValidateElement(b);

        if (!_relationship[a].Contains(b))
        {
            throw new InvalidOperationException("Elements are not connected.");
        }

        _relationship[a].Remove(b);
        _relationship[b].Remove(a);
    }

    /// <summary>
    /// Query whether two elements are directly and indirectly connected.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public bool Query(int a, int b)
    {
        ValidateElement(a);
        ValidateElement(b);

        if (a == b)
        {
            return true;
        }

        var visited = new HashSet<int>();
        var queue = new Queue<int>();
        queue.Enqueue(a);
        visited.Add(a);

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            foreach (int nearbyElement in _relationship[current])
            {
                if (nearbyElement == b)
                    return true;

                if (!visited.Contains(nearbyElement))
                {
                    visited.Add(nearbyElement);
                    queue.Enqueue(nearbyElement);
                }
            }
        }

        return false;
    }

    /// <summary>
    /// return values in level connection between two elements
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int LevelConnetion(int a, int b)
    {
        ValidateElement(a);
        ValidateElement(b);

        if (a == b)
        {
            return 0;
        };

        var visited = new HashSet<int>();
        var queue = new Queue<(int node, int level)>();
        queue.Enqueue((a, 0));
        visited.Add(a);

        while (queue.Count > 0)
        {
            var (current, level) = queue.Dequeue();

            foreach (int nearbyElement in _relationship[current])
            {
                if (nearbyElement == b){
                    return level + 1;
                }
                if (!visited.Contains(nearbyElement))
                {
                    visited.Add(nearbyElement);
                    queue.Enqueue((nearbyElement, level + 1));
                }
            }
        }

        return 0;
    }

    private void ValidateElement(int element)
    {
        if (element < 1 || element > _numberOfElements)
            throw new ArgumentOutOfRangeException("Element is out of valid range.");
    }

    private void ValidateNumber(int number, string parameterName)
    {
        if (number <= 0)
        {
            throw new ArgumentOutOfRangeException(
                parameterName,
                number,
                "The number of elements must be a positive integer greater than zero.");
        }
    }
}