using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class ArrayExtensions{
	public static T GetRandom<T>(this T[] array) {
		return array [Random.Range (0, array.Length)];
	}
}

public class ChunkSelection : MonoBehaviour {

	[Header("Prefab Reference")]
	public NestedPrefab[] chunks;

	//Componentes do mesmo objeto (Escolhido aleatoriamente)
	public NestedPrefab lastSelectedChunk;
	public ScrollingObject currentScrollObject;

	public void SelectChunk() {
		if (currentScrollObject == null) 
			currentScrollObject = GetComponent<ScrollingObject> ();
			
		lastSelectedChunk = chunks.GetRandom ();
		//Pega o tamanho do chunck atual
		currentScrollObject.size = lastSelectedChunk.GetComponent<ScrollingObject> ().size;
	}

	public Transform GenerateChunck() {
		return Instantiate (lastSelectedChunk.transform) as Transform;
	}
}
