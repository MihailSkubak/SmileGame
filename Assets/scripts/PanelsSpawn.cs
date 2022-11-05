using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsSpawn : MonoBehaviour {

	public GameObject rpanel;
	public GameObject lpanel;
	//public GameObject cpanel;
	public GameObject [] rpanels = new GameObject[3];
	public GameObject [] lpanels = new GameObject[3];
	private Vector3 [] rpositions = new Vector3[3];
	private Vector3 [] lpositions = new Vector3[3];

	//private GameObject [] cpanels = new GameObject[3];
	//private Vector3 [] cpositions = new Vector3[3];

	private Vector3 position;
	private float rand;
	public GameObject player;
	public float speed;

	void Start(){
		rand = Random.Range(0.1f, 0.6f);
		rpositions[0] = new Vector3(-4f, 9.33f, -0.5f);
		rand = Random.Range(0.1f, 0.6f);
		lpositions[0] = new Vector3(4f, 9.33f, -0.5f);
		rand = Random.Range(0.1f, 0.6f);
		rpositions[1] = new Vector3(-4f, 0f, -0.5f);
		rand = Random.Range(0.1f, 0.6f);
		lpositions[1] = new Vector3(4f, 0f, -0.5f);
		rand = Random.Range(0.1f, 0.6f);
		rpositions[2] = new Vector3(-4f, -9.33f, -0.5f);
		rand = Random.Range(0.1f, 0.6f);
		lpositions[2] = new Vector3(4f, -9.33f, -0.5f);

		//rand = Random.Range(0.1f, 0.6f);
		//cpositions[1] = new Vector3(-0.003591329f, 3.1f, 0f);


		for (int i = 0; i < 3; i++) {
			rpanels [i] = Instantiate (rpanel, rpositions [i], Quaternion.identity) as GameObject;
			lpanels [i] = Instantiate (lpanel, lpositions [i], Quaternion.identity) as GameObject;
		}
			//cpanels[1] = Instantiate(cpanel, cpositions[1], Quaternion.identity) as GameObject;

		player.GetComponent <GameCntr>().lpanel = rpanels[1];
		player.GetComponent <GameCntr>().rpanel = lpanels[1];
		//player.GetComponent <GameCntr>().cpanel = cpanels[1];
	}

	void Update () {		
		for (int i = 0; i < 3; i++) {
			position = new Vector3 (rpanels [i].transform.position.x, rpanels [i].transform.position.y - speed, rpanels [i].transform.position.z);
			rpanels [i].transform.position = position;
			//if(rpanels[i].transform.position.y == 4f) player.GetComponent <GameCntr>().lpanel = rpanels[i];
			if (rpanels [i].transform.position.y < -15f) {// ChangeObjectRight(i);
				rand = Random.Range (0.1f, 0.6f);
				Vector3 position1 = new Vector3 (-4f, rpanels [i].transform.position.y + 27.99f, -0.5f);
				rpanels [i].transform.position = position1;
			}
			Vector3 lposition = new Vector3 (lpanels [i].transform.position.x, lpanels [i].transform.position.y - speed, lpanels [i].transform.position.z);
			lpanels [i].transform.position = lposition;
			//if(rpanels[i].transform.position.y == 4f) player.GetComponent <GameCntr>().rpanel = lpanels[i];
			if (lpanels [i].transform.position.y < -15f) { //ChangeObjectLeft(i);
				rand = Random.Range (0.1f, 0.6f);
				Vector3 position2 = new Vector3 (4f, lpanels [i].transform.position.y + 27.99f, -0.5f);
				lpanels [i].transform.position = position2;
			}

		}
			/*Vector3 cposition = new Vector3(cpanels[1].transform.position.x, cpanels[1].transform.position.y-speed, cpanels[1].transform.position.z);
			cpanels[1].transform.position = cposition;
			if(cpanels[1].transform.position.y < -15f) //ChangeObjectLeft(i);
			{
				rand = Random.Range(0.1f, 0.6f);
				Vector3 position2 = new Vector3(-0.003591329f, 10.1f, 0f);
				cpanels[1].transform.position = position2;
			}*/
		}
	}
