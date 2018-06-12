using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarStandard : MonoBehaviour {
	
	Vector3 initialPosition;// = new Vector3(0.0f, 5.0f, 0.0f);
	/* The pillar currently has a height of ten units. I am setting it at a height of 5 as a middle point to move from.
	 * Eventually we will want to avoid this.
	 * We will probably set up the levels our selves and not want to care about where exactly it is, only that it goes up/down.
	 * Once/if we do so, we will need to have the script find the starting position and just use that. I think.
	 * */
	Vector3 upwardPosition;// = new Vector3(0.0f, 10.0f, 0.0f);
	//Vector3 downwardPosition = new Vector3(0.0f, 0.0f, 0.0f);
	//The desired positions 

	//Vector3 targetPosition;
	//float timeToReachTarget;

	// Use this for initialization
	void Start () {
		Debug.Log ("It is printing");
		initialPosition = GetComponent<Collider>().transform.root.position;
		upwardPosition = initialPosition;
		upwardPosition.y += 2;
		//Edits position to starting position on initialization.
		//Now also sets the target destination so no movement occurs accidentally.
		//Debug.Log ("It's printing out"); it is

	}

	// Update is called once per frame
	/*
	void Update () {
		
		targetPosition = transform.position;

		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			//Debug.Log ("Up Arrow");
			targetPosition = upwardPosition;
			StartCoroutine (MoveToPosition(transform, targetPosition, 3));

		} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			//Debug.Log ("Down Arrow");
			targetPosition = downwardPosition;
			StartCoroutine (MoveToPosition(transform, targetPosition, 3));

		} else if (Input.GetKeyDown(KeyCode.O)) {
			//Debug.Log ("Circle Arrow");
			targetPosition = initialPosition;
			StartCoroutine (MoveToPosition(transform, targetPosition, 3));

		}

	}
	*/

	void OnMouseEnter(){
		Debug.Log ("Mouse entered");
		StartCoroutine (MoveToPosition(GetComponent<Collider>().transform.root, upwardPosition, 0.3f));
	}

	void OnMouseExit(){
		Debug.Log ("Mouse left");
		StartCoroutine (MoveToPosition(GetComponent<Collider>().transform.root, initialPosition, 0.3f));
	}

	public IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove)
	{
		var currentPos = GetComponent<Collider>().transform.root.position;
		var t = 0f;
		while(t < 1)
		{
			t += Time.deltaTime / timeToMove;
			GetComponent<Collider>().transform.root.position = Vector3.Lerp(currentPos, position, t);
			yield return null;
		}
	}

}
