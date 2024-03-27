using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryProject.Data_Structure
{
    class Node<T>
    {
        internal T data;
        internal Node<T> next;
        public Node(T data)
        {
            this.data = data;
            next = null;
        }
    }
    internal class Linked_List<T>
    {
        private Node<T> head;
        internal int count;

        internal int Count { get { return count; } }
        public void AddFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            if (head != null)
                node.next = head;
            head = node;
            count++;
        }
        public void AddLast(T value)
        {
            Node<T> node = head;
            while (node.next != null)
            {
                node = node.next;
            }
            node.next = new Node<T>(value);
            count++;
        }
        public Node<T> Find(T data)
        {
            Node<T> node = head;
            while (!node.data.Equals(data))
            {
                node = node.next;
            }
            return node;
        }
        public Node<T> FindLast(T data)
        {
            Node<T> node = head;
            Node<T> temp = null;
            while (node.next != null)
            {
                if (node.data.Equals(data))
                    temp = node;
                node = node.next;
            }
            return temp;
        }

        public void AddBefore(LinkedListNode<T> node, T value)
        {
            Node<T> prevNode = head;
            Node<T> nextNode = null;
            while (prevNode.next != null)
            {
                if (prevNode.next.Equals(node))
                {
                    nextNode = prevNode.next;
                    prevNode.next = new Node<T>(value);
                    prevNode.next.next = nextNode;
                }
            }
            count++;
        }
        internal void AddAfter(LinkedListNode<T> node, T value)
        {
            Node<T> prevNode = head;
            Node<T> nextNode = null;
            while (prevNode.next != null)
            {
                if (prevNode.Equals(node))
                {
                    nextNode = prevNode.next;
                    prevNode.next = new Node<T>(value);
                    prevNode.next.next = nextNode;
                }
            }
            count++;
        }
        internal void RemoveFirst()
        {
            if (head.next != null)
                head = head.next;
            else
                head = null;
            count--;
        }
        internal void RemoveLast()
        {
            Node<T> node = head;
            Node<T> temp = null;
            while (node.next != null)
            {
                if(node.next.next == null)
                    temp = node;
                node = node.next;
            }
            if(temp != null)
            {
                temp.next = null;
                count--;
            }
        }
        internal void Remove(Node<T> node)
        {
        }
        internal void Clear()
        {
        }
        internal bool Contains(Node<T> node)
        {
        }
        internal T[] ToArray(Node<T> node)
        {
        }
        internal void CopyTo(T[] array, int index)
        {
        }
        internal void GetEnumerator()
        {
        }
        
        /*
        AddFirst(T value): 리스트의 맨 앞에 요소를 추가합니다.
        AddLast(T value): 리스트의 맨 뒤에 요소를 추가합니다.
        Find(T value): 리스트에서 특정 값을 가진 첫 번째 노드를 반환합니다.
        FindLast(T value): 리스트에서 특정 값을 가진 마지막 노드를 반환합니다.
        AddBefore(LinkedListNode<T> node, T value): 특정 노드 앞에 요소를 추가합니다.
        AddAfter(LinkedListNode<T> node, T value): 특정 노드 뒤에 요소를 추가합니다.
        RemoveFirst(): 리스트의 맨 앞 요소를 제거합니다.
        RemoveLast(): 리스트의 맨 뒤 요소를 제거합니다.
        Remove(LinkedListNode<T> node): 특정 노드를 제거합니다.
        Clear(): 리스트의 모든 요소를 제거합니다.
        Contains(T value): 리스트에 특정 값을 포함하고 있는지 여부를 확인합니다.
        ToArray(): 리스트의 모든 요소를 배열로 변환합니다.
        CopyTo(T[] array, int index): 리스트의 요소를 지정된 배열에 복사합니다.
        GetEnumerator(): 리스트를 반복하는 데 사용할 수 있는 열거자를 반환합니다.
        Count: 리스트에 포함된 요소의 개수를 반환합니다.
         */
    }
}
