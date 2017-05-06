using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	public int CurrentNumber { get; private set; }

	[SerializeField]
	private Text cursorNumber;
	private float cursorOffset = 20.0f;

	private void Start()
	{
		CurrentNumber = 1;
	}

	private void Update()
	{
		UpdateCursor ();
	}

	private void UpdateCursor()
	{
		cursorNumber.transform.position = Input.mousePosition + new Vector3 (cursorOffset, -cursorOffset, 0.0f);
		cursorNumber.text = "" + CurrentNumber;
	}

	public void OnNumberClick(Text number)
	{
		if (System.Int32.Parse (number.text) == CurrentNumber)
		{
			CurrentNumber++;
			Destroy (number.gameObject);
		}
	}
}
