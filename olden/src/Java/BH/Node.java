
/**
 * A class that represents the common fields of a cell or body
 * data structure.
 **/
abstract class Node
{
  /**
   * Mass of the node.
   **/
  double     mass;
  /**
   * Position of the node
   **/
  MathVector pos;

  // highest bit of int coord
  static final int IMAX =  1073741824;

  // potential softening parameter
  static final double EPS = 0.05;

  /**
   * Construct an empty node
   **/
  protected Node()
  {
    mass = 0.0;
    pos = new MathVector();
  }

  abstract Node    loadTree(Body p, MathVector xpic, int l, Tree root);
  abstract double  hackcofm();
  abstract HG      walkSubTree(double dsq, HG hg);

  static final int oldSubindex(MathVector ic, int l)
  {
    int i = 0;
    for (int k = 0; k < MathVector.NDIM; k++) 
	{
      if (((int)ic.value(k) & l) != 0)
		i += Cell.NSUB >> (k + 1);
    }
    return i;
  }

  /**
   * Return a string representation of a node.
   * @return a string representation of a node.
   **/
  public String toString()
  {
    return mass + " : " + pos;
  }

  /**
   * Compute a single body-body or body-cell interaction
   **/
  final HG gravSub(HG hg)
  {
    MathVector dr = new MathVector();
    dr.subtraction(pos, hg.pos0);

    double drsq = dr.dotProduct() + (EPS * EPS);
    double drabs = Math.sqrt(drsq);

    double phii = mass / drabs;
    hg.phi0 -= phii;
    double mor3 = phii / drsq;
    dr.multScalar(mor3);
    hg.acc0.addition(dr);
    return hg;
  }
}
