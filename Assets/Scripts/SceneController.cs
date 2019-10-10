using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

	public static void SwitchScene(string sceneName) {
		SceneManager.LoadScene(sceneName);
	}
}
