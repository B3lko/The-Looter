using UnityEngine;

public class DoorFrontTrigger : MonoBehaviour{
    [SerializeField] GameObject Door1;
    [SerializeField] GameObject Door2;

    void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Player"){
            if(Door1.GetComponent<DoorController>().GetIsOpen()){
                Door1.GetComponent<DoorController>().ToggleDoor();
                Door1.GetComponent<DoorController>().SetCanOpen(false);
            }
            if(Door2.GetComponent<DoorController>().GetIsOpen()){
                Door2.GetComponent<DoorController>().ToggleDoor();
                Door2.GetComponent<DoorController>().SetCanOpen(false);
            }
        }
    }
}
