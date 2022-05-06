using System;
using System.Collections.Generic;

//
// A class that represents the root of the data structure used
// to represent the N-bodies in the Barnes-Hut algorithm.
//
public class BTree
{
	public MathVector rmin;
	public double rsize;
	//
	// A reference to the root node.
	//
	public Node root;
	//
	// The complete list of bodies that have been created.
	//
	public Body bodyTab;
	//
	// The complete list of bodies that have been created - in reverse.
	//
	private Body bodyTabRev;
	
	//
	// Construct the root of the data structure that represents the N-bodies.
	//
	public BTree()
	{
		rmin = new MathVector();
		rsize = -2.0 * -2.0;
		root = null;
		bodyTab = null;
		bodyTabRev = null;

		rmin.setValue(0, -2.0);
		rmin.setValue(1, -2.0);
		rmin.setValue(2, -2.0);
	}
	
	//
    // Return an enumeration of the bodies.
    // @return an enumeration of the bodies.
    //
	public Body bodies()
	{
		return bodyTab;
	}

    //
    // Return an enumeration of the bodies - in reverse.
    // @return an enumeration of the bodies - in reverse.
    //
    public Body bodiesRev()
	{
		return bodyTabRev;
	}

	//
	// Create the testdata used in the benchmark
	// @param nbody the number of bodies to create
	//
	public void createTestData(int nbody)
	{
		MathVector cmr = new MathVector();
		MathVector cmv = new MathVector();

		Body head = new Body();
		Body prev = head;

		double rsc = 3.0 * 3.1415 / 16.0;
		double vsc = Math.Sqrt(1.0 / rsc);
		double seed = 123.0;

		for(int i = 0; i < nbody; i++)
		{
			Body p = new Body();
			prev.setNext(p);
			prev = p;
			p.mass = 1.0 / (double)nbody;

			seed = BH.myRand(seed);
			double t1 = BH.xRand(0.0, 0.999, seed);
			t1 = Math.Pow(t1, (-2.0 / 3.0)) - 1.0;
			double r = 1.0 / Math.Sqrt(t1);

			double coeff = 4.0;
			for(int k = 0; k < MathVector.NDIM; k++)
			{
				seed = BH.myRand(seed);
				r = BH.xRand(0.0, 0.999, seed);
				p.pos.setValue(k, coeff * r);
			}

			cmr.addition(p.pos);

			double x = 0.0;
			double y = 0.0;
			do
			{
				seed = BH.myRand(seed);
				x = BH.xRand(0.0, 1.0, seed);
				seed = BH.myRand(seed);
				y = BH.xRand(0.0, 0.1, seed);
			} while(y > x * x * Math.Pow(1.0 - x * x, 3.5));

			double v = Math.Sqrt(2.0) * x / Math.Pow(1.0 + r * r, 0.25);

			double rad = vsc * v;
			double rsq = 0.0;
			do
			{
				for(var k = 0; k < MathVector.NDIM; k++)
				{
					seed = BH.myRand(seed);
					p.vel.setValue(k, BH.xRand(-1.0, 1.0, seed));
				}
				rsq = p.vel.dotProduct();
			} while(rsq > 1.0);
			double rsc1 = rad / Math.Sqrt(rsq);
			p.vel.multScalar1(rsc1);
			cmv.addition(p.vel);
		}

		// mark end of list
		prev.setNext(null);
		// toss the dummy node at the beginning and set a reference to the first element
		bodyTab = head.getNext();
		
		cmr.divScalar((double)nbody);
		cmv.divScalar((double)nbody);

		prev = null;
			
		Body current = bodyTab;
		while(current != null) 
		{
		  current.pos.subtraction1(cmr);
		  current.vel.subtraction1(cmv);
		  current.setProcNext(prev);
		  prev = current;
		  current = current.getNext();
		}
		
		// set the reference to the last element
		bodyTabRev = prev;
	}

	//
	// Advance the N-body system one time-step
	// @param nstep the current time step
	//
	public void stepSystem(int nstep)
	{
		// free the tree
		root = null;

		makeTree(nstep);

		// compute the gravity for all the particles
		Body current = bodyTabRev;
		while(current != null) 
		{
		  current.hackGravity(rsize, root);
		  current = current.getProcNext();
		}

		vp(bodyTabRev, nstep);
	}

	//
	// Initialize the tree structure for hack force calculation
	// @param nsteps the current time step
	//
	private void makeTree(int nstep)
	{
		Body current = bodyTabRev;
	  while(current != null) 
	  {
		  if (current.mass != 0.0) 
		  {
			  current.expandBox(this, nstep);
			  MathVector xqic = intcoord(current.pos);
			  if (root == null)
				  root = current;
			  else
				  root = root.loadTree(current, xqic, Node.IMAX >> 1, this);
		  }
		  current = current.getProcNext();
	  }
	  root.hackcofm();
	}

	//
	// Compute integerized coordinates
	// @return the coordinates or null if rp is out of bounds
	//
	public MathVector intcoord(MathVector vp)
	{
		MathVector xp = new MathVector();

		double xsc = (vp.value(0) - rmin.value(0)) / rsize;
		if(0.0 <= xsc && xsc < 1.0)
			xp.setValue(0, Math.Floor(Node.IMAX * xsc));
		else
			return null;

		xsc = (vp.value(1) - rmin.value(1)) / rsize;
		if(0.0 <= xsc && xsc < 1.0)
			xp.setValue(1, Math.Floor(Node.IMAX * xsc));
		else
			return null;

		xsc = (vp.value(2) - rmin.value(2)) / rsize;
		if(0.0 <= xsc && xsc < 1.0)
			xp.setValue(2, Math.Floor(Node.IMAX * xsc));
		else
			return null;
		return xp;
	}

	static private void vp(Body bv, int nstep)
	{
		MathVector dacc = new MathVector();
		MathVector dvel = new MathVector();
		double dthf = 0.5 * BH.DTIME;

		Body current = bv;
		while(current != null) 
		{
		  MathVector acc1 = (MathVector)current.newAcc.cloneMathVector();
		  if (nstep > 0) 
		  {
			dacc.subtraction2(acc1, current.acc);
			dvel.multScalar2(dacc, dthf);
			dvel.addition(current.vel);
			current.vel = (MathVector)dvel.cloneMathVector();
		  }
		  current.acc = (MathVector)acc1.cloneMathVector();
		  dvel.multScalar2(current.acc, dthf);

		  MathVector vel1 = (MathVector)current.vel.cloneMathVector();
		  vel1.addition(dvel);
		  MathVector dpos = (MathVector)vel1.cloneMathVector();
		  dpos.multScalar1(BH.DTIME);
		  dpos.addition(current.pos);
		  current.pos = (MathVector)dpos.cloneMathVector();
		  vel1.addition(dvel);
		  current.vel = (MathVector)vel1.cloneMathVector();
		  current = current.getProcNext();
		}
	}
}
