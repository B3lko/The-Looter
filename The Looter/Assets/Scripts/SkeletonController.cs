using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour{
    private int boneParts;


    void Start(){
        boneParts = Random.Range(0, 4);
        if(boneParts == 0){
            return;
        }
        else if(boneParts == 3){
            gameObject.SetActive(false);
        }
        else{
            int p1 = 0;
            int p2 = 0;
            bool ok = false;
            while(!ok){
                ok = true;
                p1 = Random.Range(0, 3);
                p2 = Random.Range(0, 3);
                if(p1 == p2){ok = false;}
            }
            p1 += 1;
            p2 += 1;
            transform.GetChild(p1).gameObject.SetActive(false);
            transform.GetChild(p2).gameObject.SetActive(false);
        }
    }
}
