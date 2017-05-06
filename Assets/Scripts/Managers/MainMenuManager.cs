using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour 
{
	[SerializeField]
	private Slider hardcoreSlider;

	public void Play()
	{
		SceneLoader.Load ("Test", "difficulty", hardcoreSlider.value.ToString());
	}
}
