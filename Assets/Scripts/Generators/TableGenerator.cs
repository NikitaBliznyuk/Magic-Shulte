using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableGenerator
{
	private int count;

	public TableGenerator (int count)
	{
		this.count = count;
	}

	public int[] Generate()
	{
		var sequence = GetNumberSquence ();
		var randomizedSequence = RandomizeSequence (sequence);
		return randomizedSequence;
	}

	private List<int> GetNumberSquence()
	{
		var sequence = new List<int> ();

		for (var i = 1; i <= count; i++)
		{
			sequence.Add (i);
		}

		return sequence;
	}

	private int[] RandomizeSequence(List<int> sequence)
	{
		var matrix = new int[count];

		for (var i = 0; i < count; i++)
		{
			int randomIndex = Random.Range (0, sequence.Count);
			matrix [i] = sequence [randomIndex];
			sequence.RemoveAt (randomIndex);
		}

		return matrix;
	}
}
