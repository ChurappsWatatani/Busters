using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SecretSceneManager : MonoBehaviour {

	public void OnTouchTitleButton()
	{
		SceneManager.LoadScene("Title");
	}
}
