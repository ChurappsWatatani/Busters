using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageController : MonoBehaviour
{
	public enum GarbageType
	{
		A,
		B,
		C,
		D
	}

	public int hp = 1;
	public int point = 100;
	public GarbageType type = GarbageType.A;
}
