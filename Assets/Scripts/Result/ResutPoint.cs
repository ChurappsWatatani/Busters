using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResutPoint : MonoBehaviour 
{
	[SerializeField]
	private Image _ImgDust;
	[SerializeField]
	private Text _TxtDustNum;
	[SerializeField]
	private Text _TxtDustPoint;

	public void setPoint(Sprite iGarbageImage,string iGarbageNum,string iGarbagePoint)
	{
		_ImgDust.sprite = iGarbageImage;
		_TxtDustNum.text = iGarbageNum;
		_TxtDustPoint.text = iGarbagePoint;
	}
}
