using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour {

	public float speed, tilt;
	public GameObject rpanel, lpanel;
	private Vector3 target;
	private Vector3 rotation;

	void Start(){
		rotation = Vector3.forward * tilt;
		target = new Vector3(lpanel.transform.position.x + 1.45f, transform.position.y, transform.position.z);
	}

	void Update () {
		/* target = new Vector3(lpanel.transform.position.x + 1.45f, -1f, -1f);
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        transform.Rotate(Vector3.forward * tilt);
        if ((transform.position == target) && (target.x != rpanel.transform.position.x))
        {
            transform.Rotate(Vector3.back * tilt);
            target.x = rpanel.transform.position.x;
        }
        else if ((transform.position == target) && (target.x != (lpanel.transform.position.x + 1.45f)))
        {
            target.x = lpanel.transform.position.x + 1.45f;
            transform.Rotate(Vector3.forward * tilt);
        }*/
		//target = new Vector3(-1.75f, transform.position.y, transform.position.z);
		transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
		//transform.Rotate(Vector3.forward * tilt);
		if (transform.position.x == (lpanel.transform.position.x + 1.45f))
		{
			rotation = Vector3.back * tilt;
			target.x = rpanel.transform.position.x - 1.45f;
			transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
		}
		else if (transform.position.x == (rpanel.transform.position.x - 1.45f))
		{
			target.x = lpanel.transform.position.x + 1.45f;
			transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
			rotation = Vector3.forward * tilt;
		}
		transform.Rotate(rotation);
	}

}
