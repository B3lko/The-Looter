using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    //public GameObject Player;
    private bool isPause = false;
    [SerializeField] GameObject canvas2;

    // Start is called before the first frame update
   /* void Start(){
        transform.position = new Vector3(Player.transform.position.x, 1.5f, -10);
    }*/

    // Update is called once per frame
    void Update(){
      /* Debug.Log("JAJAJ");
        transform.position = new Vector3(Player.transform.position.x, 1.5f, transform.position.z);
        if(transform.position.x < -0.5f){
            transform.position = new Vector3(-0.5f, transform.position.y, transform.position.z);
        }
        if(transform.position.x > 7.5f){
            transform.position = new Vector3(7.5f, transform.position.y, transform.position.z);
        }*/
        /*if(Player.transform.position.z > -2.5f){
            transform.position = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z - 7.5f);
        }*/
        /*if(Player.transform.position.z > -2.5f){
            transform.position = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z - 7.5f);
        }*/
    }

    /*public void SetPause(){
        isPause = !isPause; // Alterna entre pausa y reanudación
        canvas2.SetActive(isPause);
        if(isPause){SetCameraViewport(0.25f, 0.25f, 0.5f, 0.5f);}
        else{SetCameraViewport(0f, 0f, 1f, 1f);}
    }

    void SetCameraViewport(float x, float y, float width, float height) {
        GetComponent<Camera>().rect = new Rect(x, y, width, height);
    }*/

    public void SetPause() {
    isPause = !isPause; // Alterna entre pausa y reanudación
    //canvas2.SetActive(isPause);

    if (isPause) {
        TweenCameraViewport(0.25f, 0.25f, 0.5f, 0.5f);
    } else {
        TweenCameraViewport(0f, 0f, 1f, 1f);
    }
}

void TweenCameraViewport(float targetX, float targetY, float targetWidth, float targetHeight) {
    // Obtén la cámara y el rectángulo actual
    Camera camera = GetComponent<Camera>();
    Rect currentRect = camera.rect;

    // Usa DOTween para interpolar el rectángulo de la cámara en 2 segundos
    DOTween.To(
        () => currentRect,
        x => camera.rect = x,
        new Rect(targetX, targetY, targetWidth, targetHeight),
        0.5f // Duración en segundos
    );
}

}
