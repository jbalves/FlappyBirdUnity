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

	private float worldOffset;

	// Use this for initialization
	void Start () {
		pipes = new Transform[maxPipes];

		Vector3 pipePosition;

		worldOffset = (
		    Camera.main.ViewportToWorldPoint (
			    new Vector3 (pipesOffset, 0f, 0f)
		    ) -
		    (Camera.main.ViewportToWorldPoint (
			    new Vector3 (0f, 0f, 0f)
		    ))
		).x;

		for (int i = 0; i < maxPipes ; i++) {
			//Encontra a posição de cada pipe
			pipePosition = Camera.main.ViewportToWorldPoint (
				new Vector3 (1f + pipesOffset * i, 
					Random.Range(-0.2f,0.22f))
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
		Vector3 screenPos = 
			Camera.main.WorldToViewportPoint (
				pipes [firstPipeIndex].position
			);

		if (screenPos.x < -0.5f) {
			//vetor circular
			int lastPipeIndex = 
				(pipes.Length + firstPipeIndex - 1) % pipes.Length;


			pipes [firstPipeIndex].position = 
				pipes [lastPipeIndex].position +
				new Vector3 (worldOffset, 0f, 0f);

			Vector3 pipesPos = pipes [firstPipeIndex].localPosition;
			pipesPos.y = Camera.main.ViewportToWorldPoint (
				new Vector3 (0f, Random.Range (-0.2f, 0.22f), 0f)
			).y;
			pipes [firstPipeIndex].localPosition = pipesPos;

			firstPipeIndex = (firstPipeIndex + 1) % pipes.Length;
		}
	}

}
