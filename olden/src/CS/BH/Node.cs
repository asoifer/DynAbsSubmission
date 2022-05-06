using System;
//
// A class that represents the common fields of a cell or body
// data structure.
//
public abstract class Node
{
	//
	// Mass of the node.
	//
	public double mass;
	//
	// Position of the node
	//
	public MathVector pos;

	// highest bit of int coord
	public static int IMAX = 1073741824;

	// potential softening parameter
	public static double EPS = 0.05;

	//
	// Construct an empty node
	//
	public Node()
	{
		mass = 0.0;
		pos = new MathVector();
	}

	public abstract Cell loadTree(Body p, MathVector xpic, int l, BTree root);
	public abstract double hackcofm();
	public abstract HG walkSubTree(double dsq, HG hg);

	public static int oldSubindex(MathVector ic, int l)
	{
		int i = 0;
		for(int k = 0; k < MathVector.NDIM; k++)
		{
			if(((int)ic.value(k) & l) != 0)
				i += Cell.NSUB >> (k + 1);
		}
		return i;
	}
	
	//
    // Return a string representation of a node.
    // @return a string representation of a node.
    //
	  public override string ToString()
	  {
		return mass + " : " + pos;
	  }

	//
	// Compute a single body-body or body-cell interaction
	//
	public HG gravSub(HG hg)
	{
		MathVector dr = new MathVector();
		dr.subtraction2(pos, hg.pos0);

		double drsq = dr.dotProduct() + (EPS * EPS);
		double drabs = Math.Sqrt(drsq);

		double phii = mass / drabs;
		hg.phi0 -= phii;
		double mor3 = phii / drsq;
		dr.multScalar1(mor3);
		hg.acc0.addition(dr);
		return hg;
	}
}
