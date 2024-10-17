using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraspableObject : MonoBehaviour{
    [SerializeField] string name;
    private GameObject player;
    private bool isPicked = false;


    void Start(){
        player = GameObject.FindWithTag("Player");
    }


    public void GetPicked(){
        if(!isPicked){
            isPicked = true;
            player.GetComponent<PlayerInventory>().AddString(name);
            gameObject.SetActive(false);
        }
    }
}
