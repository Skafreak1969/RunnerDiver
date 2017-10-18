using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour {
    [SerializeField] Transform player;
    [SerializeField] SpawnManager spm;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.z-transform.position.z>=54)
        {
            spm.GenerarObstaculos();
            transform.position += new Vector3(0,0,150);
        }
	}
}
