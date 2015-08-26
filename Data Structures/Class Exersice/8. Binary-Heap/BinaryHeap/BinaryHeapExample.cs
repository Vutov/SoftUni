using System;
using BinaryHeap;

public class BinaryHeapExample
{
    static void Main()
    {
        Console.WriteLine("Created an empty heap.");
        var heap = new BinaryHeap<int>();
        heap.Insert(5);
        heap.Insert(8);
        heap.Insert(1);
        heap.Insert(3);
        heap.Insert(12);
        heap.Insert(-4);

        Console.WriteLine();
        Console.WriteLine("Heap elements (max to min):");
        while (heap.Count > 0)
        {
            var max = heap.ExtractMax();
            Console.WriteLine(max);
        }

        var arr = new int[] { 3, 4, -1, 15, 2, 77, -3, 4, 12};
        var heapFromArr = new BinaryHeap<int>(arr);
        Console.WriteLine("Created a heap from array.");

        Console.WriteLine();
        Console.WriteLine("Heap elements (max to min):");
        while (heapFromArr.Count > 0)
        {
            var max = heapFromArr.ExtractMax();
            Console.WriteLine(max);
        }
    }
}
