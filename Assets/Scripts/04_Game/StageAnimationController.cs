using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageAnimationController : MonoBehaviour {
	public Animation anime;

	public void EnterEndAnimation()
	{
		anime.Play("GameClear");
	}

	public void EnterWarning()
	{
		anime.Play("Warning");
	}
	
	public void ExitEndAnimation()
	{
		GameManager.instance.ExitEndAnimation();
	}

	public void ExitWarning()
	{
		GameManager.instance.GameStart();
	}
}
