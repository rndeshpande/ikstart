 /*
 Algorithm
  * 1. For each group of K nodes, 
  *     a. Keep track of current head 
  *     b. Keep track of the K+1th node
  *     c. Keep track of tail of the previous K-nodes
  *     d. Reverse the current group of K-nodes
  *     e. Assign the new head of the reversed list to the tail of the previous k-nodes
  *     f. Re-initialize the tail to the head of the current k-nodes before it was reversed
  *     g. Move current head to head of the next group of k nodes
    2. Repeat until last node processed
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKStart
{
    class ReverseLinkedListKGroups
    {
        public void Run()
        {
            Test1();
        }

        public class LinkedListNode {
            public int val;
            public LinkedListNode next;

            public LinkedListNode(int value)
            {
                val = value;
            }
        }        

        public LinkedListNode ReverseInKGroups(LinkedListNode head, int k)
        {
            LinkedListNode resHead = null;
            var currHead = head;
            var nextHead = currHead;
            LinkedListNode prevTail = null;

            while (currHead != null)
            {
                var temp = currHead;
                
                var i = 0;
                while (nextHead != null && i < k)
                {
                    nextHead = nextHead.next;
                    i++;
                }
                
                var newHead = Reverse(currHead, k);

                if (prevTail != null)
                {
                    prevTail.next = newHead;    
                }
                
                prevTail = temp;

                if (resHead == null)
                {
                    resHead = newHead;
                }                
                                
                currHead = nextHead;
            }

            return resHead;
        }

        LinkedListNode Reverse(LinkedListNode head, int k)
        {
            var curr = head;
            LinkedListNode prev = null;
            
            var i = 0;
            while (curr != null && i < k)
            {
                var next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
                i++;
            }
            
            return prev;
        }

        void Test1()
        {
            var head = new LinkedListNode(1);
            var node2 = new LinkedListNode(2);
            var node3 = new LinkedListNode(3);
            var node4 = new LinkedListNode(4);
            var node5 = new LinkedListNode(5);
            var node6 = new LinkedListNode(6);
            var node7 = new LinkedListNode(7);
            var node8 = new LinkedListNode(8);

            head.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node6;
            node6.next = node7;
            node7.next = node8;
            
            Print(head);
            head = ReverseInKGroups(head, 3);
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
