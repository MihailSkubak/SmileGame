using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class GameCntr : MonoBehaviour {
	private const string banner = "ca-app-pub-2248795766535293/6320903953";
	private const string page = "ca-app-pub-2248795766535293/2928453854";
	private InterstitialAd ad;
	private bool once;

	public GameObject gameover;
	public GameObject Record;
	public GameObject SkubakMB;
	private AudioSource fon;
	public GameObject player;
	public GameObject player2;
	public GameObject player3;
	public Text score;
	public Text score2;
	private float count;
	public int icount;
	public int tcount;
	public float speed, tilt;
	private Vector3 target;
	private Vector3 rotation;
	private bool lose = false;
	private bool next = false;
	public GameObject plost;
	public GameObject bg;
	public GameObject panels;
	//[HideInInspector]
	public GameObject rpanel, lpanel,cpanel,circle2,circle3,circle4,cpanel2,circle22,circle33,circle44;
//	private GameObject [] rpanels = new GameObject[3];
//	private GameObject [] lpanels = new GameObject[3];
	public Vector3 Direction;
	public Vector3 direction1;
	public bool Mouse;
	public bool MouseA;
	public bool GoOn;

	public float Speed1;
	private GameObject [] cpanels = new GameObject[3];
	private Vector3 [] cpositions = new Vector3[3];

	private GameObject [] circletwo = new GameObject[3];
	private Vector3 [] twopositions = new Vector3[3];
	private GameObject [] circlethree = new GameObject[3];
	private Vector3 [] threepositions = new Vector3[3];
	private GameObject [] circlefour = new GameObject[3];
	private Vector3 [] fourpositions = new Vector3[3];

	private GameObject [] cpanelsec = new GameObject[3];
	private Vector3 [] cpositionsec = new Vector3[3];

	private GameObject [] circletwosec = new GameObject[3];
	private Vector3 [] twopositionsec = new Vector3[3];
	private GameObject [] circlethreesec = new GameObject[3];
	private Vector3 [] threepositionsec = new Vector3[3];
	private GameObject [] circlefoursec = new GameObject[3];
	private Vector3 [] fourpositionsec = new Vector3[3];

	public GameObject [] rpanels = new GameObject[3];
	public GameObject [] lpanels = new GameObject[3];
	private Vector3 [] rpositions = new Vector3[3];
	private Vector3 [] lpositions = new Vector3[3];
	private Vector3 position;
	private float rand;

	public bool center;

	void OnMouseDown(){
		if(!lose){
			GoOn = true;
			if (Mouse == true) {
				Mouse = false;
			} else {
				Mouse = true;
			}
			if (MouseA == false) {
				MouseA = true;
			} else {
				MouseA = false;
			}
			fon.Play ();
				if (center == false && (player.transform.position.x < (rpanel.transform.position.x - 0.49f)) && (player.transform.position.x > (lpanel.transform.position.x + 0.48f))) {
					//count++;
					if ((icount > 0) && (icount % 5 == 0)) {
						//speed += 0.3f;
						tilt++;
						bg.GetComponent <MoveBackground> ().firstBGSpeed += 0.01f;
						//panels.GetComponent <PanelsSpawn> ().speed += 0.005f;
					Speed1+=0.001f;
				}
				///score.text = count.ToString();
				next = true;
			}else{
				lose = true;
			}
		}
	}

	void PlayerMove(){
		//player.transform.position = Vector3.MoveTowards(player.transform.position, target, Time.deltaTime * speed);
		//player.transform.position=new Vector3(player.transform.position.x,-1, player.transform.position.z);
		player.transform.Translate(Direction*speed*Time.deltaTime);
		player2.transform.Rotate(rotation);
	}
	void PlayerMove2(){
		//player.transform.position = Vector3.MoveTowards(player.transform.position, target, Time.deltaTime * speed);
		//player.transform.position=new Vector3(player.transform.position.x,-1, player.transform.position.z);
			player.transform.Translate(direction1*speed*Time.deltaTime);
		player2.transform.Rotate(rotation);
	}

	void Start(){
		once = false;
		BannerView bannerV = new BannerView (banner, AdSize.Banner, AdPosition.Bottom);
		AdRequest request = new AdRequest.Builder ().Build();
		bannerV.LoadAd (request);
			fon = GetComponent<AudioSource>();
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
		for (int i = 0; i < 3; i++) {
			rpanels [i] = Instantiate (rpanel, rpositions [i], Quaternion.identity) as GameObject;
			lpanels [i] = Instantiate (lpanel, lpositions [i], Quaternion.identity) as GameObject;
		}
		lpanel = rpanels[1];
		rpanel = lpanels[1];

		center = false;
		rand = Random.Range(0.8f, 1.4f);
		cpositions[1] = new Vector3(-0.003591329f-rand, -10f, 0f);
		cpanels[1] = Instantiate(cpanel, cpositions[1], Quaternion.identity) as GameObject;
		cpanel = cpanels[1];

		rand = Random.Range(0.8f, 1.4f);
		twopositions[1] = new Vector3(-0.9f-rand, -10f, 0f);
		circletwo[1] = Instantiate(circle2, twopositions[1], Quaternion.identity) as GameObject;
		circle2 = circletwo[1];
		rand = Random.Range(0.8f, 1.4f);
		threepositions[1] = new Vector3(1.5f-rand, -10f, 0f);
		circlethree[1] = Instantiate(circle3, threepositions[1], Quaternion.identity) as GameObject;
		circle3 = circlethree[1];
		rand = Random.Range(0.8f, 1.4f);
		fourpositions[1] = new Vector3(1.7f-rand, -10f, 0f);
		circlefour[1] = Instantiate(circle4, fourpositions[1], Quaternion.identity) as GameObject;
		circle4 = circlefour[1];
		/////
		rand = Random.Range(0.8f, 1.4f);
		cpositionsec[1] = new Vector3(-0.003591329f-rand, -10f, 0f);
		cpanelsec[1] = Instantiate(cpanel2, cpositionsec[1], Quaternion.identity) as GameObject;
		cpanel2 = cpanelsec [1];
		rand = Random.Range(0.8f, 1.4f);
		twopositionsec[1] = new Vector3(-0.9f-rand, -10f, 0f);
		circletwosec[1] = Instantiate(circle22, twopositionsec[1], Quaternion.identity) as GameObject;
		circle22 = circletwosec[1];
		rand = Random.Range(0.8f, 1.4f);
		threepositionsec[1] = new Vector3(1.5f-rand, -10f, 0f);
		circlethreesec[1] = Instantiate(circle33, threepositionsec[1], Quaternion.identity) as GameObject;
		circle33 = circlethreesec[1];
		rand = Random.Range(0.8f, 1.4f);
		fourpositionsec[1] = new Vector3(1.7f-rand, -10f, 0f);
		circlefoursec[1] = Instantiate(circle44, fourpositionsec[1], Quaternion.identity) as GameObject;
		circle44 = circlefoursec[1];


		GoOn = false;
		Mouse = true;
		MouseA = false;
		rotation = Vector3.back * tilt;
		target = new Vector3(lpanel.transform.position.x + 1.2f, player.transform.position.y, player.transform.position.z);

	}
	void Update(){
		if (center == false && (player.transform.position.x < (rpanel.transform.position.x - 0.49f)) && (player.transform.position.x > (lpanel.transform.position.x + 0.48f))) {
			
		} else {
			PlayerLose ();
		}
		if (icount > tcount) {
			PlayerPrefs.SetInt ("record", icount);
			PlayerPrefs.Save ();
		}
		tcount = PlayerPrefs.GetInt ("record");
		for (int i = 0; i < 3; i++) {
			position = new Vector3 (rpanels [i].transform.position.x, rpanels [i].transform.position.y - Speed1, rpanels [i].transform.position.z);
			rpanels [i].transform.position = position;
			//if(rpanels[i].transform.position.y == 4f) player.GetComponent <GameCntr>().lpanel = rpanels[i];
			if (rpanels [i].transform.position.y < -15f) {// ChangeObjectRight(i);
				rand = Random.Range (0.1f, 0.6f);
				Vector3 position1 = new Vector3 (-4f, rpanels [i].transform.position.y + 27.99f, -0.5f);
				rpanels [i].transform.position = position1;
			}
			Vector3 lposition = new Vector3 (lpanels [i].transform.position.x, lpanels [i].transform.position.y - Speed1, lpanels [i].transform.position.z);
			lpanels [i].transform.position = lposition;
			//if(rpanels[i].transform.position.y == 4f) player.GetComponent <GameCntr>().rpanel = lpanels[i];
			if (lpanels [i].transform.position.y < -15f) { //ChangeObjectLeft(i);
				rand = Random.Range (0.1f, 0.6f);
				Vector3 position2 = new Vector3 (4f, lpanels [i].transform.position.y + 27.99f, -0.5f);
				lpanels [i].transform.position = position2;
			}

		}
		//player.transform.position=new Vector3(player.transform.position.x,-1, player.transform.position.z);
		Vector3 cposition = new Vector3(cpanels[1].transform.position.x, cpanels[1].transform.position.y-Speed1, cpanels[1].transform.position.z);
		cpanels[1].transform.position = cposition;
		rand = Random.Range (1,3);
		if(rand==1f && cpanels[1].transform.position.y < -9f) //ChangeObjectLeft(i);
		{
			rand = Random.Range (0.6f, 1.1f);
			Vector3 position2 = new Vector3(-0.003591329f+rand,55.4f, 0f);
			cpanels[1].transform.position = position2;
		}
		if(rand==2f && cpanels[1].transform.position.y < -9f) //ChangeObjectLeft(i);
		{
			rand = Random.Range (0.6f, 1.1f);
			Vector3 position2 = new Vector3(-0.003591329f-rand, 55.4f, 0f);
			cpanels[1].transform.position = position2;
		}

		Vector3 twoposition = new Vector3(circletwo[1].transform.position.x, circletwo[1].transform.position.y-Speed1, circletwo[1].transform.position.z);
		circletwo[1].transform.position = twoposition;
		rand = Random.Range (1,3);
		if(rand==1f && circletwo[1].transform.position.y < -10f) //ChangeObjectLeft(i);
		{
			rand = Random.Range (0.6f, 1.1f);
			Vector3 position2 = new Vector3 (-0.9f + rand, 47.4f, 0f);
			circletwo[1].transform.position = position2;
		}
		if(rand==2f && circletwo[1].transform.position.y < -10f) //ChangeObjectLeft(i);
		{
			rand = Random.Range (0.6f, 1.1f);
			Vector3 position2 = new Vector3(-0.9f-rand, 47.4f, 0f);
			circletwo[1].transform.position = position2;
		}
		Vector3 threeposition = new Vector3(circlethree[1].transform.position.x, circlethree[1].transform.position.y-Speed1, circlethree[1].transform.position.z);
		circlethree[1].transform.position = threeposition;
		rand = Random.Range (1,3);
		if(rand==1f && circlethree[1].transform.position.y < -13f) //ChangeObjectLeft(i);
		{
			rand = Random.Range (0.6f, 1.1f);
			Vector3 position2 = new Vector3(1.5f+rand, 37.4f, 0f);
			circlethree[1].transform.position = position2;
		}
		if(rand==2f && circlethree[1].transform.position.y < -13f) //ChangeObjectLeft(i);
		{
			rand = Random.Range (0.6f, 1.1f);
			Vector3 position2 = new Vector3(1.5f-rand, 37.4f, 0f);
			circlethree[1].transform.position = position2;
		}
		Vector3 fourposition = new Vector3(circlefour[1].transform.position.x, circlefour[1].transform.position.y-Speed1, circlefour[1].transform.position.z);
		circlefour[1].transform.position = fourposition;
		rand = Random.Range (1,3);
		if(rand==1f && circlefour[1].transform.position.y < -18f) //ChangeObjectLeft(i);
		{
			rand = Random.Range (0.6f, 1.1f);
			Vector3 position2 = new Vector3(1.7f-rand, 26f, 0f);
			circlefour[1].transform.position = position2;
		}
		if(rand==2f && circlefour[1].transform.position.y < -18f) //ChangeObjectLeft(i);
		{
			rand = Random.Range (0.6f, 1.1f);
			Vector3 position2 = new Vector3(1.7f+rand, 26f, 0f);
			circlefour[1].transform.position = position2;
		}
		////////////
		if (icount > 40f) {
			Vector3 cpositionsec = new Vector3 (cpanelsec [1].transform.position.x, cpanelsec [1].transform.position.y - Speed1, cpanelsec [1].transform.position.z);
			cpanelsec [1].transform.position = cpositionsec;
			rand = Random.Range (1, 3);
			if (rand == 1f && cpanelsec [1].transform.position.y < -18f) { //ChangeObjectLeft(i);
				rand = Random.Range (0.6f, 1.1f);
				Vector3 position2 = new Vector3 (-0.003591329f, 28.4f, 0f);
				cpanelsec [1].transform.position = position2;
			}
			if (rand == 2f && cpanelsec [1].transform.position.y < -18f) { //ChangeObjectLeft(i);
				rand = Random.Range (0.6f, 1.1f);
				Vector3 position2 = new Vector3 (-0.003591329f + rand, 28.4f, 0f);
				cpanelsec [1].transform.position = position2;
			}

			Vector3 twopositionsec = new Vector3 (circletwosec [1].transform.position.x, circletwosec [1].transform.position.y - Speed1, circletwosec [1].transform.position.z);
			circletwosec [1].transform.position = twopositionsec;
			rand = Random.Range (1, 3);
			if (rand == 1f && circletwosec [1].transform.position.y < -11f) { //ChangeObjectLeft(i);
				rand = Random.Range (0.6f, 1.1f);
				Vector3 position2 = new Vector3 (-0.9f , 20.4f, 0f);
				circletwosec [1].transform.position = position2;
			}
			if (rand == 2f && circletwosec [1].transform.position.y < -11f) { //ChangeObjectLeft(i);
				rand = Random.Range (0.6f, 1.1f);
				Vector3 position2 = new Vector3 (-0.9f - rand, 20.4f, 0f);
				circletwosec [1].transform.position = position2;
			}
			Vector3 threepositionsec = new Vector3 (circlethreesec [1].transform.position.x, circlethreesec [1].transform.position.y - Speed1, circlethreesec [1].transform.position.z);
			circlethreesec [1].transform.position = threepositionsec;
			rand = Random.Range (1, 3);
			if (rand == 1f && circlethreesec [1].transform.position.y < -11f) { //ChangeObjectLeft(i);
				rand = Random.Range (0.6f, 1.1f);
				Vector3 position2 = new Vector3 (1.5f + rand, 17.4f, 0f);
				circlethreesec [1].transform.position = position2;
			}
			if (rand == 2f && circlethreesec [1].transform.position.y < -11f) { //ChangeObjectLeft(i);
				rand = Random.Range (0.6f, 1.1f);
				Vector3 position2 = new Vector3 (1.5f - rand, 17.4f, 0f);
				circlethreesec [1].transform.position = position2;
			}
			Vector3 fourpositionsec = new Vector3 (circlefoursec [1].transform.position.x, circlefoursec [1].transform.position.y - Speed1, circlefoursec [1].transform.position.z);
			circlefoursec [1].transform.position = fourpositionsec;
			rand = Random.Range (1, 3);
			if (rand == 1f && circlefoursec [1].transform.position.y < -13f) { //ChangeObjectLeft(i);
				rand = Random.Range (0.6f, 1.1f);
				Vector3 position2 = new Vector3 (1.7f - rand, 10f, 0f);
				circlefoursec [1].transform.position = position2;
			}
			if (rand == 2f && circlefoursec [1].transform.position.y < -13f) { //ChangeObjectLeft(i);
				rand = Random.Range (0.6f, 1.1f);
				Vector3 position2 = new Vector3 (1.7f + rand, 10f, 0f);
				circlefoursec [1].transform.position = position2;
			} 
		}
		///////////

		if (GoOn==true && player.transform.position.x < (circletwo [1].transform.position.x + 0.75f) && player.transform.position.x > (circletwo [1].transform.position.x - 1.17f)&& player.transform.position.y > (circletwo[1].transform.position.y - 0.85f)&& player.transform.position.y < (circletwo [1].transform.position.y + 0.89f)) {
			center = true;
		}
		///
		if (GoOn==true && player.transform.position.x < (circlethree [1].transform.position.x + 0.57f) && player.transform.position.x > (circlethree [1].transform.position.x - 0.69f)&& player.transform.position.y > (circlethree [1].transform.position.y - 0.65f)&& player.transform.position.y < (circlethree [1].transform.position.y + 0.7f)) {
			center = true;
		}
		if (GoOn==true && player.transform.position.x < (circlefour [1].transform.position.x + 0.37f) && player.transform.position.x > (circlefour [1].transform.position.x - 0.47f)&& player.transform.position.y > (circlefour [1].transform.position.y - 0.5f)&& player.transform.position.y < (circlefour [1].transform.position.y + 0.55f)) {
			center = true;
		}
		if (GoOn==true && player.transform.position.x < (cpanels [1].transform.position.x + 1.18f) && player.transform.position.x > (cpanels [1].transform.position.x - 1.28f)&& player.transform.position.y > (cpanels [1].transform.position.y - 1.25f)&& player.transform.position.y < (cpanels [1].transform.position.y + 1.3f)) {
			center = true;
		}
		////....

		if (GoOn==true && player.transform.position.x < (circletwosec [1].transform.position.x + 0.75f) && player.transform.position.x > (circletwosec [1].transform.position.x - 1.17f)&& player.transform.position.y > (circletwosec[1].transform.position.y - 0.85f)&& player.transform.position.y < (circletwosec [1].transform.position.y + 0.89f)) {
			center = true;
		}
		///
		if (GoOn==true && player.transform.position.x < (circlethreesec [1].transform.position.x + 0.57f) && player.transform.position.x > (circlethreesec [1].transform.position.x - 0.69f)&& player.transform.position.y > (circlethreesec [1].transform.position.y - 0.65f)&& player.transform.position.y < (circlethreesec [1].transform.position.y + 0.7f)) {
			center = true;
		}
		if (GoOn==true && player.transform.position.x < (circlefoursec [1].transform.position.x + 0.37f) && player.transform.position.x > (circlefoursec [1].transform.position.x - 0.47f)&& player.transform.position.y > (circlefoursec [1].transform.position.y - 0.5f)&& player.transform.position.y < (circlefoursec [1].transform.position.y + 0.55f)) {
			center = true;
		}
		if (GoOn==true && player.transform.position.x < (cpanelsec [1].transform.position.x + 0.57f) && player.transform.position.x > (cpanelsec [1].transform.position.x - 0.69f)&& player.transform.position.y > (cpanelsec [1].transform.position.y - 0.65f)&& player.transform.position.y < (cpanelsec [1].transform.position.y + 0.7f)) {
			center = true;
		}

		///////////////
		if (lose && !once) {
			PlayerLose ();
		}
		if (!lose) {
			if (GoOn==true && player.transform.position.x < 4.1f && player.transform.position.x>-4.1f) {
					count += Time.deltaTime;
				  icount=(int)count;
					score.text = icount.ToString ();
				player3.SetActive (true);
				if (Mouse == true) {
					PlayerMove ();
				}
				if (MouseA == true) {
					PlayerMove2 ();
				}
			}
		}
	}

	void PlayerLose(){
		once = true;
		ad = new InterstitialAd (page);
		AdRequest request = new AdRequest.Builder ().Build ();
		ad.LoadAd (request);
		ad.OnAdLoaded += OnAdLoaded;
		lose = true;
		bg.GetComponent <MoveBackground>().firstBGSpeed = 0f;
		plost.SetActive(true);
			score2.text = tcount.ToString ();
		Record.SetActive (true);
		SkubakMB.SetActive (true);
		gameover.SetActive (true);
	}
	public void OnAdLoaded(object sender,System.EventArgs args){
		ad.Show ();
	}
};