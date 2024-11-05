using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour{
    public Image black;
    public GameObject btnPlay;
    public GameObject btnSettings;
    public GameObject Gamedat;
    public GameObject Screen_Menu;
    public GameObject Screen_Settings;
    [SerializeField] AudioSource music;


    void Start(){
        GameData.Instance.ResetData();
        //Gamedat.GetComponent<GameData>().ResetData();
        music.DOFade(1, 3);
        black.DOFade(0, 3).OnComplete(() => {
            black.gameObject.SetActive(false);
            btnPlay.SetActive(true);
            btnPlay.transform.DOScaleX(1, 0.5f).OnComplete(() => {
                btnSettings.SetActive(true);
            });
        });
    }


    void Update(){
        if(btnPlay.GetComponent<pressbtn>().press == true){
            black.gameObject.SetActive(true);
            btnPlay.GetComponent<pressbtn>().press = false;
            music.DOFade(0, 3);
            black.DOFade(1, 3).OnComplete(() => {
                SceneManager.LoadScene("GameScene");
            });
        }
    }

    public void SetScreenSettings(){
        Screen_Settings.SetActive(true);
        Screen_Menu.SetActive(false);
    }

    public void SetScreenMenu(){
        Screen_Settings.SetActive(false);
        Screen_Menu.SetActive(true);
    }
}
