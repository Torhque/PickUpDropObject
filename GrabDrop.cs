using UnityEngine;
using System.Collections;
using System;

public class GrabDrop : MonoBehavior 
{
	private Grabbable grabbableObject; // PLACEHOLDER: Find better solution later
	Transform grabbedObjectTf; // Grab the colliding object's Transform
    
	[SerializeField]
	private Transform handTf = null;

	//	Grabs a grabbable object that is within range.
	public void Grab ()
	{
		// If there is a grabbable object available
		if (grabbableObject != null && objectInHand == false) 
		{
			// Disable the grabbed object's rigidbody
			grabbableObject.GetComponent<Rigidbody> ().isKinematic = true;
			grabbableObject.GetComponent<Rigidbody> ().detectCollisions = false;

			grabbedObjectTf = grabbableObject.GetComponent<Transform> ();

			// Move the Grabbable object to the player's hand
			grabbedObjectTf.position = handTf.position;
			grabbedObjectTf.parent = handTf;
			objectInHand = true; // Object is now in the player's hand
		}
	}

	/// Drop the <Grabbable> object in the player's hand
	public void Drop ()
	{
		// If the player has an object in their hand
		if (objectInHand) 
		{
			// Enable the grabbed object's rigidbody
			grabbableObject.GetComponent<Rigidbody> ().isKinematic = false;
			grabbableObject.GetComponent<Rigidbody> ().detectCollisions = true;

			// Orphan the grabbed object
			grabbedObjectTf.parent = null;

			// Remove the object from the player's grabbable variable.
			grabbableObject = null;

			objectInHand = false; // Object is no longer in the player's hand
		}
	}
}
