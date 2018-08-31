﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallControler : MonoBehaviour
{
    public float speed = 33;
    public static float GlobalGravity = -9.8f;
    public float GravityScale = 1.0f;

    private Rigidbody ball;
    private IList<GameObject> platforms;
    private bool isForce = false;

    private void Start()
    {
        ball = GetComponent<Rigidbody>();
        //helixall = GetComponent<GameObject>();

        //ball.useGravity = false;

        // funkcje lambda / funkcje anonimowe
        platforms = GameObject.FindGameObjectsWithTag("Helix")
            .OrderBy(x => x.transform.position.y)
            .ToList();
    }

    private void FixedUpdate()
    {
         Vector3 gravity = GlobalGravity * GravityScale * Vector3.up;
         ball.AddForce(gravity, ForceMode.Acceleration);

        if (platforms.Count > 1)
        {
            foreach (var platform in platforms.Skip(1))
            {
                platform.SetActive(ball.transform.position.y >= platform.transform.position.y);
                Debug.Log(string.Format("Ball{0}\t Platfroms: {1}\tSetActive({2})",ball.transform.position.y, platform.transform.position.y, ball.transform.position.y >= platform.transform.position.y));
            }
        }
    }

     void force()
    {
        isForce = false;
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
    }

}
