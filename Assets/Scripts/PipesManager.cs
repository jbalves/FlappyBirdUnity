using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesManager : MonoBehaviour {

	[Header("References")]
	public PipeScroll pipePrefab;

	[Header("Pipes")]
	public int maxPipes;
	public float pipesOffset;

	private Transform[] pipes;
	private int firstPipeIndex;

	// Use this for initialization
	void Start () {
		
		pipes = new Transform[maxPipes];
		Vector3 pipePosition;

		for (int i = 0; i < maxPipes ; i++) {
			//Encontra a posição de cada pipe
			pipePosition = Camera.main.ViewportToWorldPoint (
				new Vector3 (1f + pipesOffset * i, 
					Random.Range(-0.4f,0.4f))
			);

			pipePosition.z = 0f;

			//Criar cada pipe
			pipes [i] = Instantiate(pipePrefab.transform) as Transform;
			pipes [i].parent = transform;
			pipes [i].localPosition = pipePosition;
		}
		firstPipeIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
