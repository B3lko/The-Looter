using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour{

    public Image black;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject Keeper;
    [SerializeField] AudioSource music;

    void Start(){
        black.gameObject.SetActive(true);
        music.DOFade(1, 3);
        black.DOFade(0, 3);
    }

    public void camm2(){
        music.DOFade(0, 3);
        black.DOFade(1, 3).OnComplete(() => {
            SceneManager.LoadScene("SummaryScene");
        });

        
    }
}
