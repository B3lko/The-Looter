using UnityEngine;
using DG.Tweening;

public class SpinObject : MonoBehaviour{
    [SerializeField] bool isKey;

    void Update(){
        if(isKey){
            transform.Rotate(0,1 * Time.deltaTime * 100,0);
        }
        else{
            transform.Rotate(0,0,1 * Time.deltaTime * 100);
        }
    }

}
