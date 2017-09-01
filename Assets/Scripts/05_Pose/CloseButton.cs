using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseButton : MonoBehaviour {

	public void OnPushCloseButton()
	{
		SceneManager.UnloadSceneAsync("05_Pose");
	}
}
