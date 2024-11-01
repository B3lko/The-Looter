using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour{
    public Image black;
    public GameObject btnPlay;
    [SerializeField] AudioSource music;


    void Start(){
        music.DOFade(1, 3);
        black.DOFade(0, 3);
    }


    void Update(){
        if(btnPlay.GetComponent<pressbtn>().press == true){
            btnPlay.GetComponent<pressbtn>().press = false;
            music.DOFade(0, 3);
            black.DOFade(1, 3).OnComplete(() => {
                SceneManager.LoadScene("GameScene");
            });
        }
    }
}
