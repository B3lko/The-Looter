using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Raycast : MonoBehaviour{
    float maxDistance = 4f; //Distancia maxima del rayo
    public TextMeshProUGUI text;
    public GameObject dialogo;
    private Dictionary<string, string> textsString = new Dictionary<string, string>();
    private Camera playerCamera;


    void Start(){
        playerCamera = Camera.main;
        textsString.Add("Door1", "Press 'E' to open");
        textsString.Add("Door2", "Press 'E' to close");
        textsString.Add("Graspable", "Press 'E' to Pick");
        textsString.Add("Key3", "Unity");
    }

    void Update(){
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.red);

        if(Physics.Raycast(ray, out hit, maxDistance)){
            //Debug.Log("Distancia: " + hit.distance); 
            //Debug.Log("Punto de impacto: " + hit.point); 
           // hit.pos

            //hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            /*if(hit.transform.gameObject.tag == "Respawn"){
                text.transform.position = hit.point;
               // text.transform.rotation = transform.rotation;
                text.transform.rotation = hit.transform.rotation;
                //text.SetActive(true);
                hit.transform.gameObject.GetComponent<Light_Interruptor>().UseInterruptor();
            }*/
            if(hit.transform.gameObject.tag == "Door"){
                PositionText(hit.point, hit.transform);
               // text.gameObject.transform.position = hit.point;
               // text.transform.rotation = transform.rotation;
                ///text.gameObject.transform.rotation = hit.transform.rotation;
                if(hit.transform.gameObject.GetComponent<DoorController>().GetIsOpen()){
                    text.text = textsString["Door2"];
                }
                else{
                    text.text = textsString["Door1"];
                }
                text.gameObject.SetActive(true);
                hit.transform.gameObject.GetComponent<DoorController>().ToggleDoor();
            }
            /*else if(hit.transform.gameObject.tag == "NPC"){
                dialogo.SetActive(true);
            }*/
            else if(hit.transform.gameObject.tag == "Graspable"){
                PositionText(hit.point, hit.transform);
                //dialogo.SetActive(true);
                //player.GetComponent<PlayerInventory>().
                hit.transform.gameObject.GetComponent<GraspableObject>().GetPicked();
            }
            else{
                text.gameObject.SetActive(false);
            }
            
        }
    }


    void PositionText(Vector3 hitPoint, Transform hitTransform)
    {
        // Posicionamos el texto ligeramente por encima del punto de impacto
        Vector3 offset = new Vector3(0, 0.5f, 0); // Ajusta este valor para que se vea bien
        text.transform.position = hitPoint + offset;

        // Hacemos que el texto siempre apunte hacia la cámara (efecto billboard)
        text.transform.LookAt(playerCamera.transform);
        text.transform.rotation = Quaternion.LookRotation(playerCamera.transform.forward);
    }
}
