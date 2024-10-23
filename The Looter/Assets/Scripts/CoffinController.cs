using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoffinController : MonoBehaviour{
    private bool isReady = false;

    public void SetReady(){
        isReady = true;
    }

    public bool GetReady(){
        return isReady;
    }
    public void DoRotate(){
        if(isReady){
            isReady = false;
            transform.DORotate(new Vector3(0, 0, 180), 0.5f, RotateMode.FastBeyond360).SetRelative().OnComplete(() => {
                gameObject.SetActive(false);
            });
        }
    }
}
