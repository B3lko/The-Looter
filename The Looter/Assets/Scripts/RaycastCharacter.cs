using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Raycast : MonoBehaviour{
    float maxDistance = 4f;
    public TextMeshProUGUI text;
    private Dictionary<string, string> textsString = new Dictionary<string, string>();


    void Start(){
        textsString.Add("Door1", "Press 'E' to open");
        textsString.Add("Door2", "Press 'E' to close");
        textsString.Add("Grasp", "Press 'E' to pick");
        textsString.Add("Dig", "Press 'E' to dig");
    }

    void Update(){
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        //Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.red);

        if(Physics.Raycast(ray, out hit, maxDistance)){
            if(hit.transform.gameObject.tag == "Door"){
                if(hit.transform.gameObject.GetComponent<DoorController>().GetIsOpen()){text.text = textsString["Door2"];}
                else{text.text = textsString["Door1"];}
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
            else if(hit.transform.gameObject.tag == "Dig"){
                text.text = textsString["Dig"];
                text.gameObject.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E)){
                    hit.transform.gameObject.GetComponent<GraspableObject>().GetPicked();
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
