using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WallCoffinController : MonoBehaviour
{
    private int indexAction = 0;
    private bool inAction = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetIndex(){
        return indexAction;
    }

    public bool isInAction(){
        return inAction;
    }
     public void DoAction(){
        if(!inAction){
            if(indexAction == 0){
                indexAction = 1;
                inAction = true;
                transform.DOMoveX(transform.position.x + 2, 2).OnComplete(() => {
                    inAction = false;
                });
            }
            else{
                inAction = true;
                transform.GetChild(0).transform.DORotate(new Vector3(0, 0, 180), 0.5f, RotateMode.FastBeyond360).SetRelative().OnComplete(() => {
                    gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    //gameObject.GetComponent<BoxCollider>()(0).enabled = false;
                    BoxCollider[] colliders = gameObject.GetComponents<BoxCollider>();
                     colliders[0].enabled = false;
                    gameObject.tag = "Untagged";
                });
        }
        }
        /*if(isReady){
            isReady = false;
            transform.DORotate(new Vector3(0, 0, 180), 0.5f, RotateMode.FastBeyond360).SetRelative().OnComplete(() => {
                gameObject.SetActive(false);
            });
        }*/
    }
}
