using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start(){
        transform.position = new Vector3(Player.transform.position.x, 1.5f, -10);
    }

    // Update is called once per frame
    void Update(){
        transform.position = new Vector3(Player.transform.position.x, 1.5f, transform.position.z);
        if(transform.position.x < -0.5f){
            transform.position = new Vector3(-0.5f, transform.position.y, transform.position.z);
        }
        if(transform.position.x > 7.5f){
            transform.position = new Vector3(7.5f, transform.position.y, transform.position.z);
        }
        /*if(Player.transform.position.z > -2.5f){
            transform.position = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z - 7.5f);
        }*/
        if(Player.transform.position.z > -2.5f){
            transform.position = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z - 7.5f);
        }
    }
}
