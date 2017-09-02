using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Achievement : MonoBehaviour {

	[SerializeField] private float _defaultPositionX;
	[SerializeField] private float _positionX;
	[SerializeField] private float _moveDuration;
	[SerializeField] private float _preAlphaDuration;
	[SerializeField] private float _alphaDuration;
	[SerializeField] private Sprite _achievementSprite1;
	[SerializeField] private Sprite _achievementSprite2;
	[SerializeField] private Sprite _achievementSprite3;
	[SerializeField] private Sprite _achievementSprite4;
	[SerializeField] private Sprite _achievementSprite5;
	[SerializeField] private Sprite _achievementSprite6;
	[SerializeField] private Sprite _achievementSprite7;

	[SerializeField] private Image _image;
	[SerializeField] private AudioClip _sound;
	public enum AchievementType 
	{ 
		//Stage1Clear,
		Stage2Clear,
		Stage3Clear,
		Stage4Clear,
		Stage5Clear,
		Stage6Clear,
		Stage7Clear, 
		Stage8Clear
	}

	//アチーブメントを獲得した時に呼ぶ
	public void MakeAchevement(int stageCount)
	{
		if(stageCount ==1)
		{
			return;
		}
		
		//ここで画像とか文言とか差し替える
		switch(stageCount)
		{
			case 2 :
				_image.sprite = _achievementSprite1;
				break;
			case 3 :
				_image.sprite = _achievementSprite2;
				break;
			case 4 :
				_image.sprite = _achievementSprite3;
				break;
			case 5 :
				_image.sprite = _achievementSprite4;
				break;
			case 6 :
				_image.sprite = _achievementSprite5;
				break;
			case 7 :
				_image.sprite = _achievementSprite6;
				break;
			case 8 :
				_image.sprite = _achievementSprite7;
				break;
		}

		this.gameObject.SetActive(true);

		DOTween.Sequence()
			.Append(this.transform.DOLocalMoveX(_positionX, _moveDuration))
			.AppendInterval(_preAlphaDuration)
			.Append(
				DOTween.ToAlpha(
					() => _image.color,
					color => _image.color = color,
					0,
					_alphaDuration
				))
			.AppendCallback(() =>
			{
				this.gameObject.SetActive(false);
				this.transform.DOLocalMoveX(_defaultPositionX, 0);
				_image.color = Color.white;
			})
			;


		// this.transform.DOLocalMoveX(_positionX, _moveDuration)
		// 	.OnComplete(() =>
		// 	{
		// 		DOTween.ToAlpha(
		// 			() => _image.color,
		// 			color => _image.color = color,
		// 			0,
		// 			_alphaDuration
		// 		).OnComplete(() => {

		// 		});
		// 	});
		
		//音を鳴らす
		//_sound.;

	}
}
