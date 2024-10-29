using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour{
    public GameObject sController;
    public void OnAnimationEnd(){
        sController.GetComponent<SceneController>().camm2();
        Debug.Log("La animación ha terminado.");
    }
}
