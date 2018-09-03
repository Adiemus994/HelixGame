using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Helixplatform : MonoBehaviour {

    public Rigidbody ball;
    private IList<GameObject> platforms;
    private float points = 0;
   // private bool gameover = false;

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
                if (ball.transform.position.y  < platforms.Last().transform.position.y)
                {
                    platforms.Last().SetActive(false);
                    platforms.Remove(platforms.Last());
                    points++;
                    Debug.Log(string.Format("Usunieto:{0} ", points));
                     Debug.Log(string.Format("Ball{0}\t Platfroms: {1}\t localposition ball{2}\t localposition{3}",ball.transform.position.y, platforms.Last().transform.position.y, ball.transform.localPosition.y, platforms.Last().transform.localPosition.y));

                }
            //}
        }
    }

    
}
