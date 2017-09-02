using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove2 : MonoBehaviour 
{
	private float posY;

	private float speedX = -3;
	private float speedY = 3;


	void Update()
	{
		this.transform.localPosition += new Vector3 (speedX,speedY, 0);

		if (this.transform.localPosition.x < -250 || this.transform.localPosition.x > 250) {
			speedX *= -1;
		}

		if (this.transform.localPosition.y < -400 || this.transform.localPosition.y > 400) {
			speedY *= -1;
		}
	}
}
