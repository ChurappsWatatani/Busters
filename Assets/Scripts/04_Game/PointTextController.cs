using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointTextController : MonoBehaviour {
	private int point = 0;
	private Text pointText;

	// Use this for initialization
	void Start () {
		pointText = GetComponent<Text>();
		pointText.text = point.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (point != GameManager.instance.point){
			point = GameManager.instance.point;
			pointText.text = point.ToString();
		}
	}
}
