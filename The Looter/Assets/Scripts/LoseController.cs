using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LoseController : MonoBehaviour{
    [SerializeField] GameObject black;
    [SerializeField] GameObject rController;
    [SerializeField] GameObject keeper;
    [SerializeField] GameObject dog;
    [SerializeField] GameObject player;
    [SerializeField] AudioSource punch;
    public AudioClip[] punchs;
    private bool finishStarted = false;


     //void Update() {
        /*if(Input.GetKeyDown(KeyCode.K)){
            StartFinishLoser();
        }*/
    //}   
    public void StartFinishLoser(){
        //black.
        GetComponent<GameController>().SetCinematic();
        player.GetComponent<PlayerController>().SetMove(false);
        player.transform.GetChild(0).transform.localRotation = Quaternion.Euler(10, transform.localRotation.y, transform.localRotation.z);
        keeper.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        keeper.transform.SetParent(player.transform);
        keeper.transform.localPosition = new Vector3(0, 0, 1.1f); //1.3f
        keeper.transform.localRotation = Quaternion.Euler(-10, 180, 0);
        keeper.transform/*.GetChild(0).gameObject*/.GetComponent<KeeperController>().SetAnimationFinish();
    }

    public void SetAFinish(){

        gameObject.GetComponent<GameController>().StopMusic();
        if(dog){
            dog.GetComponent<DogController>().Bark0();
        }
        punch.PlayOneShot(punchs[0]);
        rController.GetComponent<RainController>().Dest();
        black.SetActive(true);
        transform.DOScale(1, 2).OnComplete(() => {
            punch.pitch = 0.6f;
            punch.PlayOneShot(punchs[1]);
            transform.DOScale(1, 2).OnComplete(() => {
                punch.pitch = 0.4f;
                punch.PlayOneShot(punchs[2]);
                transform.DOScale(1, 2).OnComplete(() => {
                    punch.pitch = 0.2f;
                    punch.PlayOneShot(punchs[0]);
                    transform.DOScale(1, 2).OnComplete(() => {
                        GameData.Instance.SetEnding("trapped");
                        SceneManager.LoadScene("SummaryScene");
                    });
                });
            });
        });

    }

}
