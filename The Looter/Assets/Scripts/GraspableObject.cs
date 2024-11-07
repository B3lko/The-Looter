using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GraspableObject : MonoBehaviour{
    [SerializeField] string name;
    private GameObject player;
    private bool isPicked = false;
    [SerializeField] private AudioSource pickSFX;
    [SerializeField] TextMeshProUGUI pope;



    void Start(){
        player = GameObject.FindWithTag("Player");
    }


    public void GetPicked(){
        if(name == "Great"){
            pope.text = "Pope Tomb Looted: YES";
            player.GetComponent<PlayerInventory>().AddString("Great");
            pickSFX.Play();
            gameObject.tag = "Untagged";
            DOVirtual.DelayedCall(pickSFX.clip.length, () => {
                gameObject.SetActive(false);
            });
        }
        else if(!isPicked){
            isPicked = true;
            pickSFX.Play();
            player.GetComponent<PlayerInventory>().AddString(name);
            gameObject.tag = "Untagged";
            DOVirtual.DelayedCall(pickSFX.clip.length, () => {
                gameObject.SetActive(false);
            });

        }
    }

}
