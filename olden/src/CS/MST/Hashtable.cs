using System;
public class Hashtable
{
	public HashEntry[] array;
	public int size;

	public Hashtable(int sz)
	{
		size = sz;
		array = new HashEntry[size];
		for (int i = 0; i < size; i++)
			array[i] = null;
	}

	private int hashMap(object key)
	{
		return ((key.GetHashCode() >> 3) % size);
	}

	public virtual object get(object key)
	{
		int j = hashMap(key);
		
		HashEntry ent = null;
		
		for (ent = array[j]; ent != null && ent.Key() != key; ent = ent.Next()) { }
		
		if (ent != null)
			return ent.Entry();
		return null;
	}

	public virtual void put(object key, object value)
	{
		int j = hashMap(key);
		HashEntry ent = new HashEntry(key, value, array[j]);
		array[j] = ent;
	}

	public virtual void remove(object key)
	{
		int j = hashMap(key);
		HashEntry ent = array[j];
		if (ent != null && ent.Key() == key)
			array[j] = ent.Next();
		else
		{
			HashEntry prev = ent;
			for (ent = ent.Next(); ent != null && ent.Key() != key; prev = ent, ent = ent.Next()) { }
			prev.SetNext(ent.Next());
		}
	}
}

public class HashEntry
{
	public object key;
    public object entry;
    public HashEntry next;

	public HashEntry(object key, object entry, HashEntry next)
	{
		this.key = key;
		this.entry = entry;
		this.next = next;
	}

	public virtual object Key()
	{
		return key;
	}

	public virtual object Entry()
	{
		return entry;
	}

	public virtual HashEntry Next()
	{
		return next;
	}

	public virtual void SetNext(HashEntry n)
	{
		next = n;
	}
}
