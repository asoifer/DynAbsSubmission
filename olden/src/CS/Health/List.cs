
using System;

//
// A linked list container.
//
public class List 
{
    public ListNode head;
    public ListNode tail;

    public List()
    {
        head = null;
        tail = null;
    }

    public void add(Patient p)
    {
        ListNode node = new ListNode(p);
        if (head == null)
            head = node;
        else
            tail.next = node;
  
        tail = node;
    }

    public void delete(Object o)
    {
        if (head == null)
            return;

        if (tail._object == o)
            tail = null;

        if (head._object == o)
        {
            head = head.next;
            return;
        }

        ListNode p = head;
        for (ListNode ln = head.next; ln != null; ln = ln.next)
        {
            if (ln._object == o)
            {
                p.next = ln.next;
                return;
            }
            p = ln;
        }
    }
}
