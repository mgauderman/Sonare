using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAction : MonoBehaviour 
{
	[SerializeField]
	GameObject[] gemPrefabs;

	public void Throw()
	{
		Debug.Log ("throwing");
	}
}
