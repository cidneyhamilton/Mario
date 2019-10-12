using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{

	public SceneConfig config;
	
	IEnumerator Start() {
		// Load the UI
		yield return SceneManager.LoadSceneAsync(config.HUD, LoadSceneMode.Additive);

		// Load the first scene
		yield return LoadSceneAndSetActive(config.FirstLevel);
	}

	public void GameOver() {
		SwitchScene(config.FirstLevel);
	}
	
	public void SwitchScene(string sceneName) {
		StartCoroutine(Instance.SwitchScenes(sceneName));
	}

	IEnumerator SwitchScenes(string sceneName) {
		// Unload the old scene
		yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
		yield return Instance.LoadSceneAndSetActive(sceneName);

	}
	
	IEnumerator LoadSceneAndSetActive(string sceneName) {
		yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

		SceneManager.SetActiveScene(SceneManager.GetSceneAt(SceneManager.sceneCount - 1));
	}
}
