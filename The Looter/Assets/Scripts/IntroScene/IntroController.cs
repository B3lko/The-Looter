using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class IntroController : MonoBehaviour{
    [SerializeField] Image black;
    // Start is called before the first frame update
    void Start(){
        black.gameObject.SetActive(true);
        //music.DOFade(0, 3);
        black.DOFade(0, 3).OnComplete(() => {
            black.gameObject.SetActive(false);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetGame(){
        black.gameObject.SetActive(true);
        //music.DOFade(0, 3);
        black.DOFade(1, 3).OnComplete(() => {
            SceneManager.LoadScene("GameScene_G01");
        });
    }
}
