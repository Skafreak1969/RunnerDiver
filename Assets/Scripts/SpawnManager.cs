using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    Transform[] Spawns;
    [SerializeField] GameObject obstaculoAlto;
    [SerializeField] GameObject obstaculoSaltar;
    [SerializeField] GameObject Recolectable;

    GameObject[] obstaculos;
    int indiceObstaculos;
    int creacion;
	// Use this for initialization
	void Start () {
        Spawns = gameObject.GetComponentsInChildren<Transform>();
        obstaculos = new GameObject[5];
        indiceObstaculos = 0;
	}

    public void GenerarObstaculos()
    { 
        if (indiceObstaculos==0)
        {
            creacion = Random.Range(0, 2);
            if (creacion==0)
            {
                obstaculos[indiceObstaculos] = Instantiate(obstaculoAlto, Spawns[Random.Range(1, Spawns.Length)]);
            }
            else if(creacion==1)
            {
                obstaculos[indiceObstaculos] = Instantiate(obstaculoSaltar, Spawns[Random.Range(1, Spawns.Length)]);
            }
            indiceObstaculos++;
        }
        else {
            for (int i = 0; i < indiceObstaculos; i++) {
                obstaculos[i].transform.position = Spawns[Random.Range(1, Spawns.Length)].transform.position;
            }
            if (indiceObstaculos<4) {
                creacion = Random.Range(0, 2);
                if (creacion==0) {
                    obstaculos[indiceObstaculos] = Instantiate(obstaculoAlto, Spawns[Random.Range(1, Spawns.Length)]);
                }
                else if(creacion==1)
                {
                    obstaculos[indiceObstaculos] = Instantiate(obstaculoSaltar, Spawns[Random.Range(1, Spawns.Length)]);
                }
                indiceObstaculos++;
            }
        }
    }

	// Update is called once per frame
	void Update () {
      
	}
}
