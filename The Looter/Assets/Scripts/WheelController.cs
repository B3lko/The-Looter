using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WheelController : MonoBehaviour{
    [SerializeField] GameObject gController;
    [SerializeField] GameObject text1;
    [SerializeField] GameObject text2;
    [SerializeField] GameObject keeper;
    [SerializeField] GameObject dog;
    [SerializeField] GameObject lightCar1;
    [SerializeField] GameObject lightCar2;
    [SerializeField] GameObject player;
    [SerializeField] GameObject car;
    public Image black;
    public Image cross1;
    public Image cross2;
    public Image stamina;
    public Image page1;
    public Image page2;
    Color color;
    private bool isRotting = false;
    private bool isBack = false;

    // Start is called before the first frame update
    void Start(){
        color = black.color;
        color.a = 0;
    }


    void Update(){
        /*if(Input.GetKeyDown(KeyCode.M)){
            FinishGame();
        }  */
        if(isRotting){
            rotWheels(isBack);
        }
    }


    private void rotWheels(bool back){
        if(back){
            car.transform.GetChild(5).transform.Rotate(0, 0, 1, Space.Self);
            car.transform.GetChild(6).transform.Rotate(0, 0, 1, Space.Self);
            car.transform.GetChild(9).transform.Rotate(0, 0, 1, Space.Self);
            car.transform.GetChild(10).transform.Rotate(0, 0, 1, Space.Self);
        }
        else{
            car.transform.GetChild(5).transform.Rotate(0, 0, -1, Space.Self);
            car.transform.GetChild(6).transform.Rotate(0, 0, -1, Space.Self);
            car.transform.GetChild(9).transform.Rotate(0, 0, -1, Space.Self);
            car.transform.GetChild(10).transform.Rotate(0, 0, -1, Space.Self);
        }
    }


    public void SetTransition(){
        text1.SetActive(false);
        text2.SetActive(false);
        black.color = color;
        black.gameObject.SetActive(true);

        gController.GetComponent<GameController>().SetCinematic();

        player.GetComponent<PlayerController>().SetMove(false);
        keeper.SetActive(false);
        dog.SetActive(false);

        black.DOFade(1, 2).OnComplete(() => {
            page1.gameObject.SetActive(false);
            page2.gameObject.SetActive(false);
            stamina.gameObject.SetActive(false);
            cross1.gameObject.SetActive(false);
            cross2.gameObject.SetActive(false);
            car.transform.GetChild(4).transform.localRotation = Quaternion.Euler(-90, 0, 0);
            car.transform.GetChild(12).transform.localRotation = Quaternion.Euler(-90, 0, 0);
            lightCar1.SetActive(true);
            lightCar2.SetActive(true);
            player.transform.position = new Vector3(-6, 2, -50);
            player.transform.localRotation = Quaternion.Euler(0, -260, 0);
            player.transform.GetChild(0).transform.localRotation = Quaternion.Euler(0, 0, 0);

            black.DOFade(0, 2).OnComplete(() => {
                FinishGame();
            });
        });
    }

    public void FinishGame(){
        

        isRotting = true;
        isBack = true;

        car.transform.DOLocalRotate(new Vector3(car.transform.localEulerAngles.x, car.transform.localEulerAngles.y + 100, car.transform.localEulerAngles.z), 3, RotateMode.FastBeyond360).SetEase(Ease.InSine);
        car.transform.DOMoveZ(car.transform.position.z + 5.5f, 3).SetEase(Ease.InQuart);
        car.transform.DOMoveX(car.transform.position.x - 4, 3).OnComplete(() => {

            isBack = false;

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
                            if(GameData.Instance.collectedGreat){
                                GameData.Instance.SetEnding("Money");
                            }
                            else{
                                GameData.Instance.SetEnding("failed escape");
                            }
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
