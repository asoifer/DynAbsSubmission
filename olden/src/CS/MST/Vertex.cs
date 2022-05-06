using System;
//
// A class that represents a vertex in a graph.  We maintain a linked list
// representation of the vertices.
//
internal class Vertex
{
	//
   // The minimum distance value for the node
   //
	internal int mindist;
	//
   // The next vertex in the graph.
   //
	internal Vertex next;
	//
   // A hashtable containing all the connected vertices.
   //
	internal Hashtable neighbors;

	//
   // Create a vertex and initialize the fields.  
   // @param n the next element 
   //
	internal Vertex(Vertex n, int numvert)
	{
		mindist = 9999999;
		next = n;
		neighbors = new Hashtable(numvert / 4);
	}

	public virtual int Mindist()
	{
		return mindist;
	}

	public virtual void setMindist(int m)
	{
		mindist = m;
	}

	public virtual Vertex Next()
	{
		return next;
	}

	public virtual void SetNext(Vertex v)
	{
		next = v;
	}

	public virtual Hashtable Neighbors()
	{
		return neighbors;
	}
}
