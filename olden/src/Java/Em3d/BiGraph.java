import java.util.Enumeration;

/** 
 * A class that represents the irregular bipartite graph used in
 * EM3D.  The graph contains two linked structures that represent the
 * E nodes and the N nodes in the application.
 **/
final class BiGraph
{
  /**
   * Nodes that represent the electrical field.
   **/
  Node eNodes;
  /**
   * Nodes that representhe the magnetic field.
   **/
  Node hNodes;

  /**
   * Construct the bipartite graph.
   * @param e the nodes representing the electric fields
   * @param h the nodes representing the magnetic fields
   **/ 
  BiGraph(Node e, Node h)
  {
    eNodes = e;
    hNodes = h;
  }

  /**
   * Create the bi graph that contains the linked list of
   * e and h nodes.
   * @param numNodes the number of nodes to create
   * @param numDegree the out-degree of each node
   * @param verbose should we print out runtime messages
   * @return the bi graph that we've created.
   **/
  static BiGraph create(int numNodes, int numDegree, boolean verbose)
  {
    // making nodes (we create a table)
    if (verbose) 
		System.out.println("making nodes (tables in orig. version)");
    Node[] hTable = Node.fillTable(numNodes, numDegree);
    Node[] eTable = Node.fillTable(numNodes, numDegree);

    // making neighbors
    if (verbose)
		System.out.println("updating from and coeffs");
	Node tNode = hTable[0];
    while (tNode != null) 
	{
      tNode.makeUniqueNeighbors(eTable);
	  tNode = tNode.next;
    }
	tNode = eTable[0];
    while (tNode != null) 
	{
      tNode.makeUniqueNeighbors(hTable);
	  tNode = tNode.next;
    }

    // Create the fromNodes and coeff field
    if (verbose) 
		System.out.println("filling from fields");
	
	tNode = hTable[0];
    while (tNode != null) 
	{
      tNode.makeFromNodes();
	  tNode = tNode.next;
    }
	tNode = eTable[0];
    while (tNode != null) 
	{
      tNode.makeFromNodes();
	  tNode = tNode.next;
    }
	
    // Update the fromNodes
    tNode = hTable[0];
    while (tNode != null) 
	{
      tNode.updateFromNodes();
	  tNode = tNode.next;
    }
	tNode = eTable[0];
    while (tNode != null) 
	{
      tNode.updateFromNodes();
	  tNode = tNode.next;
    }

    BiGraph g = new BiGraph(eTable[0], hTable[0]);
    return g;
  }

  /** 
   * Update the field values of e-nodes based on the values of
   * neighboring h-nodes and vice-versa.
   **/
  void compute()
  {
	Node tNode = eNodes;
	while (tNode != null) 
	{
		tNode.computeNewValue();
		tNode = tNode.next;
	}
	tNode = hNodes;
	while (tNode != null) 
	{
		tNode.computeNewValue();
		tNode = tNode.next;
	}
  }

  /**
   * Override the toString method to print out the values of the e and h nodes.
   * @return a string contain the values of the e and h nodes.
   **/
  public String toString()
  {
    StringBuffer retval = new StringBuffer();
	Node tNode = eNodes;
	while (tNode != null) 
	{
		retval.append("E: " + tNode + "\n");
		tNode = tNode.next;
	}
	tNode = hNodes;
	while (tNode != null) 
	{
		retval.append("H: " + tNode + "\n");
		tNode = tNode.next;
	}
    return retval.toString();
  }
}
