/* Camera top_down
 * 		Camera follow the car on x and z axis
 * 		Change camera height with the mouse wheel
 * 
*/
using UnityEngine;
using System.Collections;

public class CameraDriveCar : MonoBehaviour {


	public Transform target;				// The target we are following
	public float height =  20.0f;			// The height we want the camera to be above the target

	public float scrollSpeed = 20f;
	public float minY = 20f;
	public float maxY = 200f;

	public float camera_offset = 1f;

	void Start(){
		if (!target)
			return;

		// Get current position of the camera
		Vector3 pos = transform.position;
		pos.x = target.position.x + camera_offset;
		pos.z = target.position.z;

		// Zoom out and zoom with mouse wheel
		pos.y = height;

		// Set camera position
		transform.position = pos;

		transform.eulerAngles = new Vector3(90, 0, 0);
	}

	void FixedUpdate(){

		if (!target)
			return;

		// Get current position of the camera
		Vector3 pos = transform.position;
		pos.x = target.position.x + camera_offset;
		pos.z = target.position.z;

		// Zoom out and zoom with mouse wheel
		float scroll = Input.GetAxis ("Mouse ScrollWheel");
		pos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;
		pos.y = Mathf.Clamp (pos.y, minY, maxY);

		// Set camera position
		transform.position = pos;

	}
}
