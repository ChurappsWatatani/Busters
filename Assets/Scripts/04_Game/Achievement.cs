using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Achievement : MonoBehaviour {

	[SerializeField] private float _defaultPositionX;
	[SerializeField] private float _positionX;
	[SerializeField] private float _moveDuration;
	[SerializeField] private float _alphaDuration;

	[SerializeField] private Image _image;
	[SerializeField] private AudioClip _sound;
	public enum AchievementType 
	{ 
		Stage1Clear,
		Stage2Clear,
		Stage3Clear,
		Stage4Clear,
		Stage5Clear,
		Stage6Clear,
		Stage7Clear, 
		Stage8Clear, 
		TotalPoint1000
	}

	//アチーブメントを獲得した時に呼ぶ
	void MakeAchevement(AchievementType achievementType)
	{
		//ここで画像とか文言とか差し替える

		this.gameObject.SetActive(true);

		this.transform.DOLocalMoveX(_positionX, _moveDuration)
			.OnComplete(() =>
			{
				DOTween.ToAlpha(
					() => _image.color,
					color => _image.color = color,
					0,
					_alphaDuration
				).OnComplete(() => {
					this.gameObject.SetActive(false);
					this.transform.DOLocalMoveX(_defaultPositionX, 0);
					_image.color = Color.white;
				});
			});
		
		//音を鳴らす
		//_sound.;

	}
}
