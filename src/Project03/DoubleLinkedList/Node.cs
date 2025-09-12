namespace DoubleLinkedListDemo
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T>? Next { get; internal set; }
        public Node<T>? Prev { get; internal set; }
        internal DoublyLinkedList<T>? List { get; set; }

        public Node(T value, DoublyLinkedList<T> list)
        {
            Value = value;
            List = list;
        }
    }
}
