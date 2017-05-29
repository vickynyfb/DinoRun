using UnityEngine;
using System.Collections.Generic;
using Vuforia;

public class VirtualNav : MonoBehaviour, IVirtualButtonEventHandler {

	// Private fields to store the models
	public GameObject anim;
	private GameObject btn_1;


	/// Called when the scene is loaded
	void Start() {
		anim = transform.FindChild ("Dino").gameObject;
		btn_1 = transform.FindChild ("CubeLeft").gameObject;
//		btn_1.GetComponentsInChildren<VirtualButtonBehaviour> ().RegisterEventHandler (this);

		// Search for all Children from this ImageTarget with type VirtualButtonBehaviour
		VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
		for (int i = 0; i < vbs.Length; ++i) {
			// Register with the virtual buttons TrackableBehaviour
			vbs[i].RegisterEventHandler(this);
		}




	}

	/// <summary>
	/// Called when the virtual button has just been pressed:
	/// </summary>
	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {
		Debug.Log("Button pressed!");
		anim.GetComponent<Animation>().Play ();
		switch (vb.VirtualButtonName) {
		case "btnLeft":
			anim.SetActive (true);
			anim.transform.Rotate (new Vector3 (0, Time.deltaTime * 1000, 0));
			break;
		default:
			Debug.Log("No Animation!");
			break;
		}

	}

	/// Called when the virtual button has just been released:
	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) { 
		Debug.Log("Button released!");
//		anim.GetComponent<Animation>().Stop ();

	}
}