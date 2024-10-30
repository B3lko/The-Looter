using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WallTombController : MonoBehaviour
{
    public void Open(){
       // transform.DORotate(new Vector3(0, 0, 180), 0.5f, RotateMode.FastBeyond360).SetRelative().OnComplete(() => {
       transform.DOMoveY(transform.position.y - 3, 2).OnComplete(() => {
                gameObject.SetActive(false);
        });
    }
}
