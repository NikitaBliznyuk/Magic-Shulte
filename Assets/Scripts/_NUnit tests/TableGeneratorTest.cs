using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class TableGeneratorTest {
	private TableGenerator generator;
	private int tableSize = 120;

	[SetUp]
	public void Construct()
	{
		generator = new TableGenerator (tableSize);
	}

	[Test]
	public void TableGeneration()
	{
		var table = generator.Generate ();
		var sequence = new List<int> ();

		foreach (var item in table)
		{
			Assert.AreEqual (false, sequence.Contains (item));
			sequence.Add (item);
		}
	}

	[Test]
	public void NumbersInList()
	{
		var table = generator.Generate ();
		var list = new List<int> ();

		for (var i = 0; i < tableSize; i++)
			list.Add (table [i]);

		for (var i = 1; i <= tableSize; i++)
			Assert.AreEqual (true, list.Contains (i));
	}
}
