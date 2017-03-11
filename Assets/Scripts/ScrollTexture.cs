﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour {

	[Header("Scene References")]
	//public Material material;
	MeshRenderer meshRenderer;
	Material material;

	[Header("Velocity")]
	public Vector2 scrollVelocity;
	public Vector2 scrollOffset;

	private bool isStopped = false;


	// Use this for initialization
	void Start () {	
		scrollOffset = Vector2.zero;

		meshRenderer = GetComponent<MeshRenderer> ();
		material = meshRenderer.materials[0];

		material.mainTextureOffset = scrollOffset;
		//material.SetTextureOffset ("_MainTex",scrollOffset);


		
	}
	
	// Update is called once per frame
	void Update () {
		if (isStopped)
			return;

		//Atualiza o offset
		scrollOffset += scrollVelocity * Time.deltaTime;

		material.mainTextureOffset = scrollOffset;

	}

	void StopScroll() {
		isStopped = true;
	}
}
