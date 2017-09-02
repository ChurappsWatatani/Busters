using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class CreditSceneManager : MonoBehaviour {

	[SerializeField] private float _distance;
	[SerializeField] private float _moveDuration;
	[SerializeField] private float _buttonDuration;
	[SerializeField] private GameObject _panel;
	[SerializeField] private Image _buttonImage;
	public void OnTouchTitleButton()
	{
		SceneManager.LoadScene("01_Title");
	}

	public void Start()
	{
		DOTween.ToAlpha(
			() => _buttonImage.color,
			color => _buttonImage.color = color,
			0,
			0
		);

		_panel.transform.DOLocalMoveY(_distance, _moveDuration)
			.SetRelative()
			.SetEase(Ease.Linear)
			.OnComplete(() => DOTween.ToAlpha(
				() => _buttonImage.color,
				color => _buttonImage.color = color,
				1f,
				_buttonDuration
			));
	}
}
