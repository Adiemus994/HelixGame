using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour{

    float speed = 20f;

    private void OnMouseDrag()
    {
        float rotx = Input.GetAxis("Mouse X") * speed *0.5f ;

        transform.Rotate(Vector3.up, -rotx);
    }
    
}
