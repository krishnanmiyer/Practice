using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class LinkedListProblems
    {

        public class LinkedListNode
        {
            public int Data { get; set; }

            public LinkedListNode Next { get; set; }
        }

        public bool IsPalindrome(LinkedListNode node)
        {
            if (node == null) return false;
            
            Stack<LinkedListNode> stack = new Stack<LinkedListNode>();

            LinkedListNode current = node;

            while(current != null)
            {
                if (stack.Count > 0)
                {
                    if (stack.Peek() == current)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(current);
                    }
                }
                current = current.Next;
            }

            return (stack.Count == 0);
        }

        public LinkedListNode ReverseLinkedList(LinkedListNode node)
        {
            if (node == null) return null;

            LinkedListNode h = node;
            LinkedListNode c = node;

            while (c != null)
            {
                LinkedListNode t1 = h;
                LinkedListNode t2 = c.Next;
                c.Next = t2.Next;
                h = t2;
                h.Next = t1;
                c = c.Next;
            }
            return h;
        }

        public bool IsCyclic(LinkedListNode node)
        {
            if (node == null) return false;

            LinkedListNode s = node;
            LinkedListNode f = node;

            while(s != null && f != null)
            {
                s = s.Next;
                f = f.Next.Next;
                if (s == f) return true;
            }

            return false;
        }

        public static LinkedListNode FindFromEnd(LinkedListNode node, int k)
        {
            if (node == null)
            {
                return null;
            }

            LinkedListNode lead = node;
            LinkedListNode current = node;

            int count = 0;

            while (lead != null)
            {
                lead = lead.Next;
                count++;

                if (count > 5)
                {
                    current = current.Next;
                }
            }
            return current;
        }
    }
}
