using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour{
    public Image black;
    public GameObject btnPlay;


    void Start(){
        black.DOFade(0, 2);
    }


    void Update(){
        if(btnPlay.GetComponent<pressbtn>().press == true){
            btnPlay.GetComponent<pressbtn>().press = false;
            black.DOFade(1, 2).OnComplete(() => {
                SceneManager.LoadScene("GameScene");
            });
        }
    }
}
