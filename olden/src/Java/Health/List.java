
import java.util.Enumeration;

/**
 * A linked list container.
 **/
class List 
{
  ListNode head;
  ListNode tail;

  List()
  {
    head = null;
    tail = null;
  }

  void add(Patient p)
  {
    ListNode node = new ListNode(p);
    if (head == null)
      head = node;
    else
      tail.next = node;
  
    tail = node;
  }

  void delete(Object o)
  {
    if (head == null) 
		return;
    
    if (tail.object == o)
      tail = null;

    if (head.object == o) 
	{
      head = head.next;
      return;
    }
      
    ListNode p = head;
    for (ListNode ln = head.next; ln != null; ln = ln.next) 
	{
      if (ln.object == o) 
	  {
		p.next = ln.next;
		return;
      }
      p = ln;
    }
  }
}
