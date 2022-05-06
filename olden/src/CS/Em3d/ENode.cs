using System;
using System.Collections.Generic;
using System.Text;

//
// This class implements nodes (both E- and H-nodes) of the EM graph. Sets
// up random neighbors and propagates field values among neighbors.
//
public class ENode
{
    //
	// The value of the node.
	//
    public double value;
	//
   // The next node in the list.
   //
    public ENode next;
    //
	// Array of nodes to which we send our value.
	//
    public ENode[] toNodes;
    //
	// Array of nodes from which we receive values.
	//
    public ENode[] fromNodes;
    //
	// Coefficients on the fromNodes edges
	//
    public double[] coeffs;
    //
	// The number of fromNodes edges
	//
    public int fromCount;
    //
	// Used to create the fromEdges - keeps track of the number of edges that have
	// been added
	//
    public int fromLength;
	
	//
	// Constructor for a node with given `degree'.   The value of the
	// node is initialized to a random value.
	//
	public ENode(int degree)
	{
		value = RandomGenerator.NextDouble();
		// create empty array for holding toNodes
		toNodes = new ENode[degree];
		
		next = null;
		fromNodes = null;
		coeffs = null;
		fromCount = 0;
		fromLength = 0;
	}

	//
	// Create the linked list of E or H nodes.  We create a table which is used
	// later to create links among the nodes.
	// @param size   the no. of nodes to create
	// @param degree the out degree of each node
	// @return a table containing all the nodes.
	//
	public static ENode[] fillTable(int size, int degree)
	{
		ENode[] table = new ENode[size];

		ENode prevNode = new ENode(degree);
		table[0] = prevNode;
		for (int i = 1; i < size; i++) 
		{
		  ENode curNode = new ENode(degree);
		  table[i] = curNode;
		  prevNode.next = curNode;
		  prevNode = curNode;
		}
		return table;
	}

	//
	// Create unique `degree' neighbors from the nodes given in nodeTable.
	// We do this by selecting a random node from the give nodeTable to
	// be neighbor. If this neighbor has been previously selected, then
	// a different random neighbor is chosen.
	// @param nodeTable the list of nodes to choose from.
	//
	public void makeUniqueNeighbors(ENode[] nodeTable)
	{
		for(int filled = 0; filled < toNodes.Length; filled++)
		{
			int k;
			ENode otherNode = null;

			do
			{
				// generate a random number in the correct range
				int index = RandomGenerator.Next();
				if(index < 0)
					index = -index;
				index = index % nodeTable.Length;

				// find a node with the random index in the given table
				otherNode = nodeTable[index];

				for(k = 0; k < filled; k++)
				{
					if(otherNode == toNodes[filled])
						break;
				}
			} while(k < filled);

			// other node is definitely unique among "filled" toNodes
			toNodes[filled] = otherNode;

			// update fromCount for the other node
			otherNode.fromCount = otherNode.fromCount + 1;
		}
	}

	//
	// Allocate the right number of FromNodes for this node. This
	// step can only happen once we know the right number of from nodes
	// to allocate. Can be done after unique neighbors are created and known.
	// <p/>
	// It also initializes random coefficients on the edges.
	//
	public void makeFromNodes()
	{
		fromNodes = new ENode[fromCount]; // nodes fill be filled in later
		coeffs = new double[fromCount];
	}

	//
	// Fill in the fromNode field in "other" nodes which are pointed to
	// by this node.
	//
	public void updateFromNodes()
	{
		for(int i = 0; i < this.toNodes.Length; ++i)
		{
			ENode otherNode = this.toNodes[i];
			int count = otherNode.fromLength++;
			otherNode.fromNodes[count] = this;
			otherNode.coeffs[count] = RandomGenerator.NextDouble();
		}
	}

	//
	// Get the new value of the current node based on its neighboring
	// from_nodes and coefficients.
	//
	public void computeNewValue()
	{
		for(int i = 0; i < fromCount; i++)
			value -= coeffs[i] * fromNodes[i].value;
	}

	//
   // Override the toString method to return the value of the node.
   // @return the value of the node.
   //
	public string toString()
	{
		return "value " + value + ", from_count " + fromCount;
	}
}
