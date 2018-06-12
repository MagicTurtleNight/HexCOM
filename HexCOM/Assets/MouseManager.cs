﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {

	/* Currently, once the color has changed on an object, I do not know how to reset it specifically to what it was.
	 * I believe I will need to utilize GetComponent<Renderer>().material in some way, but I am not sure how to make it work just yet.
	 * */
	Vector3 initialPosition;// = new Vector3(0.0f, 10.0f, 0.0f);
	Vector3 upwardPosition;// = new Vector3(0.0f, 12.0f, 0.0f);
	public GameObject selectedObject;
	int over;

	void Start(){
		//over = 0;
	}

	void Update(){

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit hitInfo;
		//Creates a blank variable for what will be hit
		//RaycastHit[] hits = Physics.RaycastAll( ray );
		//   This array form catches every hit for a ray. This means that if there is 
		//   overlap it will capture every object hit, also it will return an empty array
		//   if it hits nothing.


		//Future note. Look into layermasks for selecting something specifically

		if (Physics.Raycast (ray, out hitInfo)) {
			//Physics.Raycast takes the blank hitInfo and fills in the information 
			// with whatever was hit first be the raycast.
			/* The collider we hit may not be the "root" of the object.
			 * You can grab the most "root-est" gameobject using
			 * transform.root, though if your objects are nested within 
			 * a larger parent GameObject (like "All units") then this might not work.
			 * An alternative is to move up the transform.parent hierarchy until you find something
			 * with a particular component.
			 * */

			GameObject hitObject = hitInfo.transform.root.gameObject;
			//this goes to the root, so we can't use it if we group objects together
			// i.e. "all pillars". In those cases, we would have to iterate through
			// transform.parent via some means, like testing for a specific collider.


			//initialPosition = hitObject.transform.position;
			//upwardPosition = initialPosition;
			//upwardPosition.y += 2;

			SelectObject (hitObject);

		} 
		else {
			//StartCoroutine (MoveToPosition(selectedObject, initialPosition, 1));
			ClearSelection ();
		}
	}

	void SelectObject (GameObject obj){


		if (selectedObject != null) {
			if (obj == selectedObject)
				return;
			ClearSelection ();
		}

		selectedObject = obj;

		 //This section changes the color when an object is hovered over
		Renderer[] rends = selectedObject.GetComponentsInChildren<Renderer> ();
		foreach(Renderer rend in rends){
			Material m = rend.material;// This is equivalent to rend.materials[0] for if there are more than one materials.
			m.color = Color.green;
			//This currently only adjusts the single selected unit's material
			//If we instead said r.SharedMaterials, then it would change it for any object using that same material.
			rend.material = m;
		}

		//if (over == 0)
		//	StartCoroutine (MoveToPosition(selectedObject, upwardPosition, 1));

	}

	void ClearSelection (){
		if (selectedObject == null)
			return;

		 //this section changes "back" the color of an object when no longer hovered over.
		Renderer[] rends = selectedObject.GetComponentsInChildren<Renderer> ();
		foreach(Renderer rend in rends){
			Material m = rend.material;// This is equivalent to rend.materials[0] for if there are more than one materials.
			m.color = Color.white;
			//This currently only adjusts the single selected unit's material
			//If we instead said r.SharedMaterials, then it would change it for any object using that same material.
			rend.material = m;
		}


		selectedObject = null;
		//over = 0;

	}
	/*
	public IEnumerator MoveToPosition(GameObject selectedObject, Vector3 position, float timeToMove)
	{
		over = 1;
		var currentPos = selectedObject.transform.position;
		var t = 0f;
		while(t < 1)
		{
			t += Time.deltaTime / timeToMove;
			selectedObject.transform.position = Vector3.Lerp(currentPos, position, t);
			yield return null;
		}
	}
	*/
}
