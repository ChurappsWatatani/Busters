using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour 
{
	
	private float posY;
	void Awake()
	{
		posY = this.transform.localPosition.y;

	}

	void Update()
	{
		this.transform.localPosition += new Vector3 (-10, 0, 0);

		if (this.transform.localPosition.x < -400) {
			this.transform.localPosition = new Vector3 (400, posY, 0);
		}
	}
}
