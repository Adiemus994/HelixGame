using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Helixplatform : MonoBehaviour {

    public Rigidbody ball;
    private IList<GameObject> platforms;
    private float points = 0;

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
            foreach (var platform in platforms.Skip(1).ToList())
            {
                if (ball.transform.position.y + 7.10f < platform.transform.position.y)
                {
                    platform.SetActive(false);
                    platforms.Remove(platform);
                    points++;
                    Debug.Log(string.Format("Usunieto:{0} ", points));
                     Debug.Log(string.Format("Ball{0}\t Platfroms: {1}\t localposition ball{2}\t localposition{3}",ball.transform.position.y, platform.transform.position.y, ball.transform.localPosition.y, platform.transform.localPosition.y));

                }
            }
        }
    }
}
