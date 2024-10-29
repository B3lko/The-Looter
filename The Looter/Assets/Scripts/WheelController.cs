using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WheelController : MonoBehaviour{
    [SerializeField] GameObject player;
    [SerializeField] GameObject car;
    public Image black;
    Color color;

    // Start is called before the first frame update
    void Start(){
        color = black.color;
        color.a = 0;
    }


    void Update(){
        if(Input.GetKeyDown(KeyCode.M)){
            FinishGame();
        }  
    }


    public void FinishGame(){
        player.GetComponent<PlayerController>().SetMove(false);
        player.transform.position = new Vector3(-6, 2, -50);
        player.transform.localRotation = Quaternion.Euler(0, -260, 0);
        player.transform.GetChild(0).transform.localRotation = Quaternion.Euler(0, 0, 0);

        car.transform.DOLocalRotate(new Vector3(car.transform.localEulerAngles.x, car.transform.localEulerAngles.y + 100, car.transform.localEulerAngles.z), 3, RotateMode.FastBeyond360).SetEase(Ease.InSine);
        car.transform.DOMoveZ(car.transform.position.z + 5.5f, 3).SetEase(Ease.InQuart);
        car.transform.DOMoveX(car.transform.position.x - 4, 3).OnComplete(() => {
            player.transform.DOLocalRotate( new Vector3 (player.transform.localEulerAngles.x, player.transform.localEulerAngles.y + 60, player.transform.localEulerAngles.z), 5, RotateMode.FastBeyond360).SetEase(Ease.InSine);
            car.transform.DOLocalRotate(new Vector3(car.transform.localEulerAngles.x, car.transform.localEulerAngles.y + 90, car.transform.localEulerAngles.z), 5, RotateMode.FastBeyond360).SetEase(Ease.InSine);
            car.transform.DOMoveZ(car.transform.position.z - 6.5f, 5);//.SetEase(Ease.InQuart);
            car.transform.DOMoveX(car.transform.position.x - 8.5f, 5).SetEase(Ease.InQuart).OnComplete(() => {
                car.transform.DOLocalRotate(new Vector3(car.transform.localEulerAngles.x, car.transform.localEulerAngles.y - 95, car.transform.localEulerAngles.z), 2, RotateMode.FastBeyond360).SetEase(Ease.InSine);//SetEase(Ease.InSine);//.SetEase(Ease.Linear);//SetEase(Ease.OutSine);
                car.transform.DOMoveX(car.transform.position.x - 4, 3).SetEase(Ease.OutQuart);
                car.transform.DOMoveZ(car.transform.position.z - 20f, 5).SetEase(Ease.InQuart).OnComplete(() => {
                    car.transform.DOLocalRotate(new Vector3(car.transform.localEulerAngles.x, car.transform.localEulerAngles.y - 90, car.transform.localEulerAngles.z), 3, RotateMode.FastBeyond360).SetEase(Ease.OutSine);//SetEase(Ease.InSine);//.SetEase(Ease.Linear);//SetEase(Ease.OutSine);
                    car.transform.DOMoveZ(car.transform.position.z - 3f, 2).SetEase(Ease.InQuart);
                    car.transform.DOMoveX(car.transform.position.x + 10, 3).SetEase(Ease.InQuart).OnComplete(() => {
                        black.color = color;
                        black.gameObject.SetActive(true);
                        black.DOFade(1, 2).OnComplete(() => {
                            SceneManager.LoadScene("TitlesScene");
                        });
                    });
                });
            } );
        });


    //////////////////////////////////
    ///rot = + 50
    ///z + 5
    ///x - 9

    }
}
