using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GraspableObject : MonoBehaviour{
    [SerializeField] string name;
    private GameObject player;
    private bool isPicked = false;
    [SerializeField] private AudioSource pickSFX;



    void Start(){
        player = GameObject.FindWithTag("Player");
    }


    public void GetPicked(){
        if(!isPicked){
            isPicked = true;
            pickSFX.Play();
            player.GetComponent<PlayerInventory>().AddString(name);
            DOVirtual.DelayedCall(pickSFX.clip.length, () => {
                gameObject.SetActive(false);
            });

        }
    }

}
