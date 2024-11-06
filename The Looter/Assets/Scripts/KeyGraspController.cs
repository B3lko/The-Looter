using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KeyGraspController : MonoBehaviour{
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
            gameObject.tag = "Untagged";
            DOVirtual.DelayedCall(pickSFX.clip.length, () => {
                gameObject.SetActive(false);
            });

        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            GetPicked();
        }
    }
}
