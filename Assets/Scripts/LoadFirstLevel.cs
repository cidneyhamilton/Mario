using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cyborg.Scenes;

public class LoadFirstLevel : MonoBehaviour
{
	bool loaded;
	
    // Start is called before the first frame update
    void Update()
    {
		if (!loaded) {
			Debug.Log("Changing scene.");
			SceneEvents.ChangeScene("SampleScene");
		}
    }

}
