﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallControler : MonoBehaviour
{
    public float speed = 33;
    public static float GlobalGravity = -9.8f;
    public float GravityScale = 1.0f;

    private Rigidbody ball;
    private bool isForce = false;
    

    private void Start()
    {
        ball = GetComponent<Rigidbody>();
      
    }

    private void FixedUpdate()
    {
         Vector3 gravity = GlobalGravity * GravityScale * Vector3.up;
         ball.AddForce(gravity, ForceMode.Acceleration);

    }

     void force()
    {
        isForce = false;
        ball.velocity = new Vector3(0f, 0f, 0f);
        ball.AddForce(Vector3.up * speed, ForceMode.Impulse);
    }

    private void Update()
    {
        if (isForce == true)
        {
            force();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isForce = true;
        if (collision.gameObject.tag == "Bad")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (collision.gameObject.tag == "Theend")
        {
            if (SceneManager.sceneCountInBuildSettings - 1 > SceneManager.GetActiveScene().buildIndex)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                Helixplatform.gameover = true;
            }
        }
    }
}
