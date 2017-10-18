using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMotor : MonoBehaviour {

    private Vector3 moveVector;
    private float speed = 25.0f;
    private float speedX = 25;
    private Rigidbody rbd;
    private bool grounded;
    private float tiempoVel;
    private float tiempomuert = 3f; 
    private bool muerto = false;
    int multiplicadorSalto;
	// Use this for initialization
	void Start () {
        moveVector = transform.position;
        rbd = GetComponent<Rigidbody>();
        grounded = true;
        tiempoVel = 15f;
        multiplicadorSalto = 5;
	}
	
	// Update is called once per frame
	void Update () {

        tiempoVel -= Time.deltaTime;

        if (tiempoVel <= 0)
        {
            speed += 3f;
            tiempoVel = 15f;
        }
        if (muerto == true)
        {
            tiempomuert -= Time.deltaTime;
            if (tiempomuert <= 0)
            {

                SceneManager.LoadScene("main");
            }

        }
        MoverHaciaAdelante();

        if (Input.GetKeyDown(KeyCode.D) && muerto == false)
        {
            MoverDerecha();
        }

        if (Input.GetKeyDown(KeyCode.A) && muerto == false)
        {
            MoverIzquierda();
        }

        if (Input.GetKeyDown(KeyCode.Space) && muerto == false)
        {
            Saltar();
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(moveVector.x,transform.position.y,transform.position.z), Time.deltaTime * speedX);
	}

    public void Saltar()
    {
        if (grounded) {
            rbd.AddForce(Vector3.up * multiplicadorSalto, ForceMode.Impulse);
            grounded = false;
        }
    }

    private void MoverHaciaAdelante()
    {
        transform.position += Vector3.forward * Time.deltaTime * speed;
        //moveVector += Vector3.forward * Time.deltaTime * speed;
    }

    public void MoverDerecha()
    {
        if (transform.position.x < 3f)
        {
            moveVector.x += 3;
        }
    }

    public void MoverIzquierda()
    {
        if (transform.position.x > -3f)
        {
            moveVector.x -= 3;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Suelo"))
        {
            grounded = true;
        }
        if (col.gameObject.CompareTag ("Obstaculo"))
        {
            speed = 0;
            tiempoVel = -1;
            muerto = true;
        }
    }
}
