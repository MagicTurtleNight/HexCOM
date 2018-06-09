using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {


	Vector3 startPosition;
	float t;
	Vector3 target;
	float timeToReachTarget;

	void Start()
	{
		startPosition = new Vector3(0.0f, 0.0f, 0.0f);
		target = new Vector3(0.0f, 5.0f, 0.0f);
		transform.position = startPosition;
		//setting the intitial position of the pillar to 0,0,0 -- Working just fine

		StartCoroutine (MoveToPosition(transform, target, 3));
	}

	void Update() 
	{
		
	}

	public IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove)
	{
		var currentPos = transform.position;
		var t = 0f;
		while(t < 1)
		{
			t += Time.deltaTime / timeToMove;
			transform.position = Vector3.Lerp(currentPos, position, t);
			yield return null;
		}
	}
}
