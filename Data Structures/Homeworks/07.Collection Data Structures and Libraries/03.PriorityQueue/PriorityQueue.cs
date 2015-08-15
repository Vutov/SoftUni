namespace _03.PriorityQueue
{
    using System;

    /// <summary>
    /// Priority queue implemented by Binary heap. Using integers for
    /// priority, where 1 is highest priority and 5 is lowest priority.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PriorityQueue<T> where T : IEquatable<T>
    {
        private const int InitialSize = 8;
        private Node[] queue;
        private int lastIndex;
        private int addingNum;

        public PriorityQueue()
        {
            this.lastIndex = 1;
            this.addingNum = 0;
            this.queue = new Node[InitialSize];
        }

        public PriorityQueue(int initialSize)
            : this()
        {
            this.queue = new Node[initialSize];
        }

        /// <summary>
        /// Adds new value to the priority queue depending on the priority
        /// the value will be added to the queue in different position.
        /// The lower the priority number, the higher the priority.
        /// Priority can be 1 to 5.
        /// </summary>
        /// <param name="value">Value to be added to the priority queue.</param>
        /// <param name="priority">Number of priority. Lower number has higher priority.</param>
        public void Enqueue(T value, int priority)
        {
            if (priority < 1 || priority > 5)
            {
                throw new InvalidOperationException("Priority must be between 1 and 5");
            }

            if (this.lastIndex == this.queue.Length)
            {
                this.Grow();
            }

            this.addingNum++;
            var newNode = new Node(priority, value, this.addingNum);
            var currentPossition = this.lastIndex;
            this.queue[currentPossition] = newNode;
            var parentPossition = currentPossition / 2;
            var parent = this.queue[currentPossition / 2];
            while (currentPossition > 1 &&
                newNode.CompareTo(parent) == 1)
            {
                this.queue[currentPossition] = parent;
                this.queue[parentPossition] = newNode;
                currentPossition = parentPossition;
                parentPossition = currentPossition / 2;
                parent = this.queue[parentPossition];
            }

            this.lastIndex++;
        }

        public T Dequeue()
        {
            this.CheckForEmptyQueue();

            var removed = this.queue[1].Value;
            this.lastIndex--;

            var last = this.queue[this.lastIndex];
            var currentEmptySpot = 1;
            var hasReplacement = true;
            while (currentEmptySpot * 2 <= this.lastIndex && hasReplacement)
            {
                var replacementChild = this.queue[currentEmptySpot * 2];
                var replacementChildIndex = currentEmptySpot * 2;
                if (this.queue[currentEmptySpot * 2 + 1] != null)
                {
                    var otherChild = this.queue[currentEmptySpot * 2 + 1];
                    if (otherChild.CompareTo(replacementChild) == 1)
                    {
                        replacementChild = otherChild;
                        replacementChildIndex++;
                    }
                }

                // When there are only 2 elements the last and the child will be
                // the same and then it will be 1, so the swap will be done.
                if (replacementChild.CompareTo(last) == 1)
                {
                    this.queue[currentEmptySpot] = replacementChild;
                    this.queue[replacementChildIndex] = last;
                    currentEmptySpot = replacementChildIndex;
                }
                else
                {
                    hasReplacement = false;
                }
            }

            this.queue[this.lastIndex] = default(Node);

            if (this.lastIndex <= this.queue.Length / 3 &&
                this.queue.Length / 3 >= InitialSize / 2)
            {
                this.Shrink();
            }

            return removed;
        }

        public T Peek()
        {
            this.CheckForEmptyQueue();

            return this.queue[1].Value;
        }

        public bool IsEmpty()
        {
            return this.lastIndex == 1;
        }

        public bool Contains(T value)
        {
            for (int i = 1; i < this.lastIndex; i++)
            {
                if (this.queue[i].Value.Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        public int Count()
        {
            return this.lastIndex - 1;
        }

        public int Capacity()
        {
            return this.queue.Length;
        }

        public int GetCurrentHightestPriority()
        {
            this.CheckForEmptyQueue();

            return this.queue[1].Priority;
        }

        /// <summary>
        /// Gives all elements in random order. Only the first element is for 
        /// sure the next one in the queue. This is priority queue.
        /// </summary>
        /// <param name="action">Lambda expression.</param>
        public void ForEach(Action<T> action)
        {
            for (int i = 1; i < this.lastIndex; i++)
            {
                action(this.queue[i].Value);
            }
        }

        private void CheckForEmptyQueue()
        {
            if (this.lastIndex == 1)
            {
                throw new InvalidOperationException("Queue is empty!");
            }
        }

        private void Grow()
        {
            var newQueue = new Node[this.queue.Length * 2];
            for (int i = 1; i < this.queue.Length; i++)
            {
                newQueue[i] = this.queue[i];
            }

            this.queue = newQueue;
        }

        private void Shrink()
        {
            var newQueue = new Node[this.queue.Length / 2];
            for (int i = 1; i < this.lastIndex; i++)
            {
                newQueue[i] = this.queue[i];
            }

            this.queue = newQueue;
        }

        private class Node : IComparable<Node>
        {
            public Node(int priority, T value, int addingNum)
            {
                this.Priority = priority;
                this.Value = value;
                this.AddingNum = addingNum;
            }

            public int Priority { get; private set; }

            public T Value { get; private set; }

            /// <summary>
            /// Number of adding to the queue, used to determine witch
            /// child should go next when both have same priority.
            /// </summary>
            private int AddingNum { get; set; }

            /// <summary>
            /// Comparing two same elements will return 1. Same is defined when
            /// elements have the same priority and the same adding number.
            /// Bigger is the one with lower priority number, if the same the one
            /// with lower adding number.
            /// </summary>
            /// <param name="other">Other Node for comparison</param>
            /// <returns>1 or -1 depending</returns>
            public int CompareTo(Node other)
            {
                if (this.Priority < other.Priority)
                {
                    return 1;
                }

                if (this.Priority > other.Priority)
                {
                    return -1;
                }

                if (this.AddingNum > other.AddingNum)
                {
                    return -1;
                }

                return 1;
            }
        }
    }
}