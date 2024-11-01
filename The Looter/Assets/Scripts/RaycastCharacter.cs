using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Raycast : MonoBehaviour{
    public GameObject gController;
    float maxDistance = 4f;
    public TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI textDown;

    private Dictionary<string, string> textsString = new Dictionary<string, string>();


    void Start(){
        textsString.Add("Door1", "Press 'E' to open");
        textsString.Add("Door2", "Press 'E' to close");
        textsString.Add("Door3", "First I must loot the tombs");
        textsString.Add("Door4", "First I have to grab the tools in the trunk of the car");
        textsString.Add("Grasp", "Press 'E' to pick");
        textsString.Add("Dig", "Press 'E' to dig");
        textsString.Add("Tomb", "Press 'E' to read");
        textsString.Add("Coffin", "Press 'E' to open the coffin");
        textsString.Add("Jewel", "Press 'E' to pick the jewel");
        textsString.Add("Wall", "I'm not leaving without looting first");
        textsString.Add("Wheel1", "I'm not leaving without looting first");
        textsString.Add("Wheel2", "Leave");
        textsString.Add("DoorKey1", "You need a key to open this door");
        textsString.Add("DoorKey2", "Press 'E' to open the door");
        textsString.Add("TombDoorWall", "Press 'E' to open the tomb door");
        textsString.Add("puzzle", "Press 'E' to open the padlock");
        //textsString.Add("Tomb", "I'm not leaving without looting first");
    }

    void Update(){
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.red);

        if(Physics.Raycast(ray, out hit, maxDistance)){
            if(hit.transform.gameObject.tag == "Door"){
                if(hit.transform.gameObject.GetComponent<DoorController>().GetIsOpen()){text.text = textsString["Door2"];}
                else{text.text = textsString["Door1"];}
                //text.text
                text.text = hit.transform.gameObject.GetComponent<DoorController>().GetTextState();
                text.gameObject.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E)){
                    hit.transform.gameObject.GetComponent<DoorController>().ToggleDoor();
                }
            }
            else if(hit.transform.gameObject.tag == "Graspable"){
                text.text = textsString["Grasp"];
                text.gameObject.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E)){
                    hit.transform.gameObject.GetComponent<GraspableObject>().GetPicked();
                }
            }
            else if(hit.transform.gameObject.tag == "Grave"){
                text.text = textsString["Dig"];
                text.gameObject.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E)){
                    hit.transform.gameObject.GetComponent<GraveController>().DoPalada();
                }
            }
            else if(hit.transform.gameObject.tag == "Coffin"){
                if(hit.transform.gameObject.GetComponent<CoffinController>().GetReady()){
                    text.text = textsString["Coffin"];
                    text.gameObject.SetActive(true);
                }
                if(Input.GetKeyDown(KeyCode.E)){
                    hit.transform.gameObject.GetComponent<CoffinController>().DoRotate();
                }
            }
            else if(hit.transform.gameObject.tag == "Wall"){
                text.text = textsString["Wall"];
                text.gameObject.SetActive(true);
            }
            else if(hit.transform.gameObject.tag == "Tomb"){
                text.text = textsString["Tomb"];
                text.gameObject.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E)){
                    textDown.text = hit.transform.gameObject.GetComponent<TombController>().GetName();
                    textDown.gameObject.SetActive(true);
                    DOVirtual.DelayedCall(3, () => {
                        textDown.gameObject.SetActive(false);
                    });
                }
            }
            else if(hit.transform.gameObject.tag == "Jewel"){
                text.text = textsString["Jewel"];
                text.gameObject.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E)){
                    hit.transform.gameObject.GetComponent<JewelController>().SetJewel();
                }
            }
            else if(hit.transform.gameObject.tag == "CloseDoor"){
                text.gameObject.SetActive(true);
                if(hit.transform.parent.gameObject.GetComponent<DoorLockedKey>().CanOpen()){
                    text.text = textsString["DoorKey2"];
                    if(Input.GetKeyDown(KeyCode.E)){
                        hit.transform.parent.gameObject.GetComponent<DoorLockedKey>().OpenDoor();
                    }
                }
                else{
                    text.text = textsString["DoorKey1"];
                }
               
            }
            else if(hit.transform.gameObject.tag == "Wheel"){
                text.gameObject.SetActive(true);
                if(gController.GetComponent<GameController>().GetWinner()){
                    text.text = textsString["Wheel2"];
                    if(Input.GetKeyDown(KeyCode.E)){
                        hit.transform.gameObject.GetComponent<WheelController>().SetTransition();
                    }
                }
                else{
                    text.text = textsString["Wheel1"];
                }
            }
            else if(hit.transform.gameObject.tag == "TombWallDoor"){
                text.text = textsString["TombDoorWall"];
                text.gameObject.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E)){
                    hit.transform.gameObject.GetComponent<WallTombController>().Open();
                }
            }
            else if(hit.transform.gameObject.tag == "Coffin2"){
                if( hit.transform.gameObject.GetComponent<WallCoffinController>().GetIndex() == 0){
                    text.text = textsString["TombDoorWall"];
                }
                else{
                    text.text = textsString["Coffin"];
                }
                if(!hit.transform.gameObject.GetComponent<WallCoffinController>().isInAction()){
                    text.gameObject.SetActive(true);
                }
                if(Input.GetKeyDown(KeyCode.E)){
                    hit.transform.gameObject.GetComponent<WallCoffinController>().DoAction();
                }
            }
            else if(hit.transform.gameObject.tag == "PuzzleDoor"){
                text.text = textsString["puzzle"];
                if(!hit.transform.gameObject.GetComponent<LockPuzzleController>().isActive){
                    text.gameObject.SetActive(true);
                }
                else{
                    text.gameObject.SetActive(false);
                }
                if(Input.GetKeyDown(KeyCode.E)){
                    hit.transform.gameObject.GetComponent<LockPuzzleController>().ActivatePuzzleMode();
                }
            }
            else{
                text.gameObject.SetActive(false);
            }
        }
        else{
            text.gameObject.SetActive(false);
        }
    }
}
