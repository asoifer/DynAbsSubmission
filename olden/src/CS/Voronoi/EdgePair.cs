

//*
// A class that represents an edge pair
//*/
public class EdgePair
{
	internal Edge left;
	internal Edge right;

	public EdgePair(Edge l, Edge r)
	{
		left = l;
		right = r;
	}

	public virtual Edge getLeft()
	{
		return left;
	}

	public virtual Edge getRight()
	{
		return right;
	}
}
