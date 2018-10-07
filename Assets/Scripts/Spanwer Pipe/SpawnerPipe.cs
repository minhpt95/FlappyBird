using UnityEngine;
using System.Collections;

public class SpawnerPipe : MonoBehaviour {

	[SerializeField]
	private GameObject pipeHolder;

	// Use this for initialization
	void Start () {
		StartCoroutine (Spawner ());
	}
	
	IEnumerator Spawner(){
		yield return new WaitForSeconds (1); // time spawner
		Vector3 temp = pipeHolder.transform.position;
		temp.y = Random.Range (-1.5f, 1.5f); //change range random positon of pipe holder
		Instantiate (pipeHolder, temp, Quaternion.identity);
		StartCoroutine (Spawner ());
	}
}
