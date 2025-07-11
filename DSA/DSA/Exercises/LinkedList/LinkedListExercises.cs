using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Exercises.LinkedList
{
    // These exercises are from leetcode
    public class LinkedListExercises
    {
        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode result = new ListNode();  
            ListNode tail = result;

            while (list1 != null && list2 != null)
            {
                if(list1.val <= list2.val)
                {
                    tail.next = list1;
                    list1 = list1.next;
                    tail = tail.next;
                }
                else
                {
                    tail.next = list2;
                    list2 = list2.next;
                    tail = tail.next;
                }
            }

            if(list1 != null)
            {
                tail.next = list1;
            }
            if(list2 != null)
            {
                tail.next = list2;
            }

            return result.next;
        }

        public static ListNode DeleteDuplicates(ListNode head)
        {
            ListNode result = new ListNode(-101);
            ListNode tail = result;

            while (head != null)
            {
                if (head.val != tail.val)
                {
                    tail.next = head;
                    tail = tail.next;
                }
                else
                {
                    tail.next = null;
                }
                head = head.next;
                                                         
            }
            return result.next;
        }

        public static bool HasCycle(ListNode head)
        {
            if (head == null || head.next == null) return false;

            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast) return true;
            }

            return false;
        }
    }
}
