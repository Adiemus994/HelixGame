using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class Helixplatform : MonoBehaviour {

    public Rigidbody ball;
    public GUIStyle mygui;
    private IList<GameObject> platforms;
    private float points = 0;
   // private Collision col;
    public static bool gameover = false;

    // Use this for initialization
    void Start () {
	    platforms = GameObject.FindGameObjectsWithTag("Helix")
	        .OrderBy(x => x.transform.position.y)
	        .ToList();
    }

    private void FixedUpdate()
    {
        if (platforms.Count > 1)
        {
            //foreach (var platform in platforms.Skip(1).ToList())
           // {
            //platforms.Skip(1);
            if (ball.transform.position.y -0.3f < platforms.Last().transform.position.y)
            {
                    platforms.Last().SetActive(false);
                    platforms.Remove(platforms.Last());
                    points++;
                    Debug.Log(string.Format("Usunieto:{0} ", points));
                     Debug.Log(string.Format("Ball{0}\t Platfroms: {1}\t localposition ball{2}\t localposition{3}",ball.transform.position.y, platforms.Last().transform.position.y, ball.transform.localPosition.y, platforms.Last().transform.localPosition.y));

            }
            //}
        }
       /* else
        {
            if (col.gameObject.tag=="Theend")
            {
                if (SceneManager.sceneCountInBuildSettings-1 > SceneManager.GetActiveScene().buildIndex)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    GameFinished();
                }
                //platforms.Last().SetActive(false);
                //platforms.Remove(platforms.Last());
                //points++;
               // Debug.Log(string.Format("Usunieto:{0} ", points));
               // Debug.Log(string.Format("Ball{0}\t Platfroms: {1}\t localposition ball{2}\t localposition{3}", ball.transform.position.y, platforms.Last().transform.position.y, ball.transform.localPosition.y, platforms.Last().transform.localPosition.y));

            }
        }*/
    }

    public static void GameFinished()
    {
        GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 300, 300), "Game finished! \n Congrats!");
        if (GUI.Button(new Rect(Screen.width / 2 - 140, Screen.height / 2 - 110, 280, 120), "Play again"))
        {
            SceneManager.LoadScene("FirstScene");
            gameover = false;
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 140, Screen.height / 2 +10, 280, 120), "QuitGame"))
        {
            Application.Quit();
        }
    }
    private void OnGUI()
    {          
           // GUIStyle mygui = new GUIStyle();
            //mygui.fontSize = 30;
            //mygui.alignment = TextAnchor.UpperCenter;
           
            //GUI.TextArea(new Rect(center, 30, 20, 20), "Score: "+points, mygui);
          
            GUI.Label(new Rect(Screen.width /2 - 25, Screen.height /9 -12.5f, 50, 25), "Score: "+points,mygui);

            if (gameover == true)
            {
                GameFinished();
            }
        /*  GUI.Box(new Rect(400, 170, 100, 100), "Game finished! \n Congrats!");
              if (GUI.Button(new Rect(410, 210, 80, 20), "Play again"))
              {
                  SceneManager.LoadScene("FristScene");
              }
              if (GUI.Button(new Rect(410, 240, 80, 20), "QuitGame"))
              {
                  Application.Quit();
              }
          }*/

    }

       /* private void OnCollisionEnter(Collision collision)
        {

        if (collision.gameObject.tag == "Theend")
        {
            if (SceneManager.sceneCountInBuildSettings - 1 > SceneManager.GetActiveScene().buildIndex)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                GameFinished();
            }
            //platforms.Last().SetActive(false);
            //platforms.Remove(platforms.Last());
            //points++;
            // Debug.Log(string.Format("Usunieto:{0} ", points));
            // Debug.Log(string.Format("Ball{0}\t Platfroms: {1}\t localposition ball{2}\t localposition{3}", ball.transform.position.y, platforms.Last().transform.position.y, ball.transform.localPosition.y, platforms.Last().transform.localPosition.y));

        }
        }*/

}
