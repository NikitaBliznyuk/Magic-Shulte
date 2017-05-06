using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableManager : MonoBehaviour 
{
	public int TileCount;

	[SerializeField]
	private GameObject[] tilePrefabs;
	[SerializeField]
	private Text cursorText;

	private GameManager gameManager;

	private TableGenerator generator;

	private void Awake()
	{
		var parameter = SceneLoader.GetParam ("difficulty");
		if(parameter != "")
			TileCount = System.Int32.Parse (parameter);
		
		generator = new TableGenerator (TileCount * TileCount * 10);
		gameManager = FindObjectOfType<GameManager> ();
	}

	private void Start()
	{
		var table = generator.Generate ();
		var tiles = GenerateTiles ();

		AssignValues (ref tiles, table);
		ScaleTilesWithScreenSize (ref tiles);
		SetPositionToTiles (ref tiles);

		cursorText.transform.SetParent (transform);
	}

	private GameObject[,] GenerateTiles()
	{
		var tiles = new GameObject[TileCount, TileCount];

		for (var i = 0; i < TileCount; i++)
		{
			for (var j = 0; j < TileCount; j++)
			{
				var index = Random.Range (0, tilePrefabs.Length);
				tiles [i, j] = Instantiate (tilePrefabs [index]);
				tiles [i, j].transform.SetParent (transform);

				var buttons = tiles [i, j].GetComponentsInChildren<Button> ();
				foreach (var button in buttons)
				{
					button.onClick.AddListener (() =>
					{
						gameManager.OnNumberClick (button.gameObject.GetComponent<Text> ());
					});
				}
			}
		}

		return tiles;
	}

	private void AssignValues(ref GameObject[,] tiles, int[] table)
	{
		int index = 0;

		for (var i = 0; i < TileCount; i++)
		{
			for (var j = 0; j < TileCount; j++)
			{
				var numbers = tiles [i, j].GetComponentsInChildren<Text> ();

				foreach (var number in numbers)
				{
					number.text = table [index++] + "";
				}
			}
		}
	}

	private void ScaleTilesWithScreenSize(ref GameObject[,] tiles)
	{
		var rectTransform = GetComponent<RectTransform> ();
		var width = rectTransform.rect.width / TileCount;
		var height = rectTransform.rect.height / TileCount;

		for (var i = 0; i < TileCount; i++)
		{
			for (var j = 0; j < TileCount; j++)
			{
				var tileRectTransform = tiles [i, j].GetComponent<RectTransform> ();

				var scaleX = tileRectTransform.localScale.x * width / tileRectTransform.rect.width;
				var scaleY = tileRectTransform.localScale.y * height / tileRectTransform.rect.height;

				tileRectTransform.localScale = new Vector3 (scaleX, scaleY, 1.0f);
			}
		}
	}

	private void SetPositionToTiles(ref GameObject[,] tiles)
	{
		var xStep = 0.0f;
		var yStep = 0.0f;

		for (var i = 0; i < TileCount; i++)
		{
			for (var j = 0; j < TileCount; j++)
			{
				var tileRectTransform = tiles [i, j].GetComponent<RectTransform> ();

				xStep = tileRectTransform.rect.width * tileRectTransform.localScale.x;
				yStep = tileRectTransform.rect.height * tileRectTransform.localScale.y;

				tileRectTransform.anchoredPosition = new Vector2 (xStep * j, yStep * i);
			}
		}
	}
}