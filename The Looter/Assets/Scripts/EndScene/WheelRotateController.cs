using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotateController : MonoBehaviour{

    private float speed = 30f;
    void Update(){
        transform.Rotate(0, 0, -1 * Time.deltaTime * speed, Space.Self);
    }
}
