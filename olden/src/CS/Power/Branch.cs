using System;
//
// A class that represents a branch node in the power pricing
// architecture.  A branch node is another type of intermediate node
// that represents a split in the electrical power path.  The branch
// nodes hang from the lateral nodes.
// <b>
// Each branch node contains a direct link to a set of customers.
//
public class Branch
{
	//
	// Demand for the customers supported by the branch node.
	//
	private Demand D;
	private double alpha = 0.0;
	private double beta = 0.0;
	private double R = 0.0001;
	private double X = 0.00002;
	//
	// A link to the next branch node that has the same parent (lateral) node.
	//
	private Branch nextBranch;
	//
	// A list of customers - represented a leaf nodes.
	//
	System.Collections.Generic.List<Leaf> leaves;

	
	//
	// Create all the branch nodes for a single lateral node.
	// Also, create the customers supported by this branch node
	//
	// @param num     a counter to limit the branch nodes created for the lateral node
	// @param nleaves the nubmer of leafs to create per branch
	//
	public Branch(int num, int nleaves)
	{
		D = new Demand();

		if(num <= 1)
			nextBranch = null;
		else
			nextBranch = new Branch(num - 1, nleaves);

		// fill in children
		leaves = new System.Collections.Generic.List<Leaf>();
		for(int k = 0; k < nleaves; k++)
			leaves.Add(new Leaf());
	}

	//
	// Pass the prices down and compute the demand for the power system.
	// @param theta_R real power multiplier
	// @param theta_I reactive power multiplier
	// @param pi_R    the real power price
	// @param pi_I    the reactive power price
	// @return the demand for the customers supported by this branch
	//
	public Demand compute(double theta_R, double theta_I, double pi_R, double pi_I)
	{
		double new_pi_R = pi_R + alpha * (theta_R + (theta_I * X) / R);
		double new_pi_I = pi_I + beta * (theta_I + (theta_R * R) / X);

		Demand a1 = null;
		if(nextBranch != null)
			a1 = nextBranch.compute(theta_R, theta_I, new_pi_R, new_pi_I);

		// Initialize and pass the prices down the tree
		D.reset();
		for(int i = 0; i < this.leaves.Count; ++i)
			D.increment(this.leaves[i].compute(new_pi_R, new_pi_I));

		if(nextBranch != null)
			D.increment(a1);

		// pass demand up, P, Q
		double a = R * R + X * X;
		double b = 2.0 * R * X * D.Q - 2.0 * X * X * D.P - R;
		double c = R * D.Q - X * D.P;
		c = c * c + R * D.P;
		double root = (-b - Math.Sqrt(b * b - 4.0 * a * c)) / (2.0 * a);
		D.Q = D.Q + ((root - D.P) * X) / R;
		D.P = root;
		// compute alpha, beta
		a = 2.0 * R * D.P;
		b = 2.0 * X * D.Q;
		alpha = a / (1.0 - a - b);
		beta = b / (1.0 - a - b);

		return D;
	}
}
