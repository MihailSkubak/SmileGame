using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {

	public enum ProjectMode {moveX = 0, moveY = 1};
	public ProjectMode projectMode = ProjectMode.moveX;

	public MeshRenderer firstBG;
	public float firstBGSpeed = 0.01f;

	private Vector2 savedFirst;

	void Awake()
	{
		if(firstBG) savedFirst = firstBG.sharedMaterial.GetTextureOffset("_MainTex");
	}

	void Move(MeshRenderer mesh, Vector2 savedOffset, float speed)
	{
		Vector2 offset = Vector2.zero;
		float tmp = Mathf.Repeat(Time.time * speed, 1);
		if(projectMode == ProjectMode.moveY) offset = new Vector2(savedOffset.x, tmp);
		else offset = new Vector2(tmp, savedOffset.y);
		mesh.sharedMaterial.SetTextureOffset("_MainTex", offset);
	}

	void Update()
	{
		if(firstBG) Move(firstBG, savedFirst, firstBGSpeed);
	}

	void OnDisable()
	{
		if(firstBG) firstBG.sharedMaterial.SetTextureOffset("_MainTex", savedFirst);
	}
}
