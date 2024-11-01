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




    // Start is called before the first frame update
    void Start(){
        black.gameObject.SetActive(true);
        music.DOFade(1, 3);
        black.DOFade(0, 3).OnComplete(() => {

        } );
    }

    public void camm2(){
        black.DOFade(1, 2).OnComplete(() => {
            cam1.SetActive(false);
            cam2.SetActive(true);
            Keeper.SetActive(true);
            black.DOFade(0, 2).OnComplete(() => {
                cam2.transform.DOLocalRotate(new Vector3(cam2.transform.localEulerAngles.x, cam2.transform.localEulerAngles.y + 140, cam2.transform.localEulerAngles.z), 2, RotateMode.FastBeyond360).SetEase(Ease.InSine);
                music.DOFade(0, 3);
                black.DOFade(1, 3).OnComplete(() => {
                    SceneManager.LoadScene("SummaryScene");
                });
            });
        }) ;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
