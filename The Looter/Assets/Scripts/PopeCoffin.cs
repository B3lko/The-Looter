using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PopeCoffin : MonoBehaviour{
    private int indexAction = 0;
    private bool inAction = false;

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
                transform.DOMoveZ(transform.position.z - 2.2f, 2).OnComplete(() => {
                    inAction = false;
                });
            }
            else{
                inAction = true;
                transform.GetChild(0).transform.DORotate(new Vector3(0, 0, 180), 0.5f, RotateMode.FastBeyond360).SetRelative().OnComplete(() => {
                    gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    BoxCollider[] colliders = gameObject.GetComponents<BoxCollider>();
                     colliders[0].enabled = false;
                    gameObject.tag = "Untagged";
                });
            }
        }
    }
}
