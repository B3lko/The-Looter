using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoffinController : MonoBehaviour{

    public void DoRotate(){
        transform.DORotate(new Vector3(0, 0, 180), 0.5f, RotateMode.FastBeyond360).SetRelative().OnComplete(() => {
            gameObject.SetActive(false);
        });
    }
}
