using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
	private static Dictionary<string, string> parameters;

	public static void Load(string sceneName, Dictionary<string, string> parameters = null)
	{
		SceneLoader.parameters = parameters;
		SceneManager.LoadScene (sceneName);
	}

	public static void Load(string sceneName, string paramKey, string paramValue)
	{
		SceneLoader.parameters = new Dictionary<string, string> ();
		SceneLoader.parameters.Add (paramKey, paramValue);
		SceneManager.LoadScene (sceneName);
	}

	public static string GetParam(string paramKey)
	{
		if (parameters == null)
			return "";
		return parameters [paramKey];
	}

	public static void SetParam(string paramKey, string paramValue)
	{
		if (parameters == null)
			SceneLoader.parameters = new Dictionary<string, string> ();
		SceneLoader.parameters.Add (paramKey, paramValue);
	}
}
