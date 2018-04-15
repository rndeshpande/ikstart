using System;

namespace IKStart
{
    internal class SwapKthNodes
    {
        public void Run()
        {
            //Test1();
            Test2();
        }
        private class LinkedListNode
        {
            public int val;
            public LinkedListNode next;

            public LinkedListNode(int value)
            {
                val = value;
            }
        };

        private LinkedListNode swap_nodes(LinkedListNode head, int k)
        {
            if (head == null)
            {
                return null;
            }

            var nodeA = head;
            var nodeB = head;

            var i = 0;
            while (i < k)
            {
                if (nodeB.next == null)
                {
                    break;
                }
                nodeB = nodeB.next;
                
                i++;
            }

            LinkedListNode prevA = null;
            LinkedListNode prevB = null;
            var count = 1;

            while (nodeB.next != null)
            {
                count++;

                if (count == k)
                {
                    prevA = nodeA;
                }

                prevB = nodeA;
                nodeA = nodeA.next;
                nodeB = nodeB.next;
            }

            //Console.WriteLine(prevA.val);
            //Console.WriteLine(prevB.val);

            Swap(prevA, prevB);
            return head;
        }

        private void Swap(LinkedListNode prevA, LinkedListNode prevB)
        {
            var tempA = prevA.next;
            var tempB = prevB.next;
            var tempC = tempB.next;

            prevA.next = tempB;
            tempB.next = tempA.next;

            prevB.next = tempA;
            tempA.next = tempC;
        }

        void Test1()
        {
            var head = new LinkedListNode(1);
            var node2 = new LinkedListNode(2);
            var node3 = new LinkedListNode(3);
            var node4 = new LinkedListNode(4);
            var node7 = new LinkedListNode(7);
            var node0 = new LinkedListNode(0);

            head.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node7;
            node7.next = node0;

            Print(head);
            swap_nodes(head, 2);
            Print(head);
        }

        void Test2()
        {
            var head = new LinkedListNode(1);
            var node2 = new LinkedListNode(2);            

            head.next = node2;            

            Print(head);
            swap_nodes(head, 2);
            Print(head);
        }

        void Print(LinkedListNode head)
        {
            var temp = head;

            while (temp != null)
            {
                Console.Write(temp.val + " -> ");
                temp = temp.next;
            }

            Console.WriteLine();
        }
    }
}