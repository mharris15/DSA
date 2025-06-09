namespace DSA.DataStructures
{
    /// <summary>
    /// Represents a singly linked list node.
    /// </summary>
    /// <typeparam name="T">The type of the data item stored in the node.</typeparam>
    public class LinkedList<T> 
    {
        /// <summary>
        /// Gets or sets the data item contained in this node.
        /// </summary>
        public T Item { get; set; }

        /// <summary>
        /// Gets or sets the reference to the next node in the linked list.
        /// </summary>
        public LinkedList<T>? Next { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkedList{T}"/> class with the specified item.
        /// </summary>
        /// <param name="item">The data item to store in the node.</param>
        public LinkedList(T item)
        {
            Item = item;
            Next = null;
        }

        /// <summary>
        /// Recursively searches the linked list starting from the given node for a node containing the specified item.
        /// </summary>
        /// <param name="node">The starting node of the search.</param>
        /// <param name="x">The item to search for.</param>
        /// <returns>
        /// The first <see cref="LinkedList{T}"/> node containing the item if found; otherwise, <c>null</c>.
        /// </returns>
        public static LinkedList<T>? Search(LinkedList<T>? node, T x)
        {
            if (node == null)
                return null;

            if (EqualityComparer<T>.Default.Equals(node.Item, x))
                return node;

            return Search(node.Next, x);
        }

        /// <summary>
        /// Inserts a new node containing the specified item at the beginning of the linked list.
        /// </summary>
        /// <param name="head">The current head of the list (passed by reference).</param>
        /// <param name="x">The item to insert.</param>
        public static void InsertAtHead(ref LinkedList<T>? head, T x)
        {
            var newNode = new LinkedList<T>(x)
            {
                Next = head
            };
            head = newNode;
        }

        /// <summary>
        /// Deletes the specified node from the linked list.
        /// </summary>
        /// <param name="head">Reference to the head of the list.</param>
        /// <param name="target">Reference to the node to be deleted.</param>
        public static void DeleteNode(ref LinkedList<T>? head, LinkedList<T> target)
        {
            if (head == null || target == null)
                return;

            var predecessor = FindPreviousNode(head, target);

            if (predecessor == null)
            {
                head = head.Next;
            }
            else
            {
                predecessor.Next = target.Next;
            }

            target.Next = null;
        }

        /// <summary>
        /// Recursively finds the node that comes immediately before the specified node <paramref name="target"/>.
        /// </summary>
        /// <param name="head">The starting node to begin the search.</param>
        /// <param name="target">The node whose predecessor is to be found.</param>
        /// <returns>
        /// The node that precedes <paramref name="target"/> in the list; or <c>null</c> if not found or if <paramref name="target"/> is the head.
        /// </returns>
        private static LinkedList<T>? FindPreviousNode(LinkedList<T>? head, LinkedList<T> target)
        {
            if (head == null || head.Next == null)
                return null;

            if (head.Next == target)
                return head;

            return FindPreviousNode(head.Next, target);
        }
    }
}

