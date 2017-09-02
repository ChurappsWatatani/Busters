using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PoseManager : MonoBehaviour {

	private enum ButtonType	{ Left, Right, Top, Bottom, A, B } 
	private ButtonType[] InputPattern = new [] 
	{
		ButtonType.Top,
		ButtonType.Top,
		ButtonType.Bottom,
		ButtonType.Bottom,
		ButtonType.Left,
		ButtonType.Right,
		ButtonType.Left,
		ButtonType.Right,
		ButtonType.B,
		ButtonType.A
	};

	private int _currentIndex;

	public void OnPushLeftButton() { OnPushButton(ButtonType.Left);	}
	public void OnPushRightButton() { OnPushButton(ButtonType.Right); }
	public void OnPushTopButton() { OnPushButton(ButtonType.Top); }
	public void OnPushBottomButton() { OnPushButton(ButtonType.Bottom);	}
	public void OnPushAButton() { OnPushButton(ButtonType.A); }
	public void OnPushBButton() { OnPushButton(ButtonType.B);	}

	private void OnPushButton(ButtonType buttonType)
	{
		if(buttonType == InputPattern[_currentIndex])
		{
			if(_currentIndex == InputPattern.Length - 1)
			{
				//コナミコマンドを入力した時の処理
				return;
			}
			_currentIndex++;
			return;
		}
		_currentIndex = 0;
	}
	public void OnPushTitleButton()
	{
		SceneManager.LoadScene("01_Title");
	}
}
