using UnityEngine;

public class DoorFrontTrigger : MonoBehaviour{
    [SerializeField] GameObject Door1;
    [SerializeField] GameObject Door2;
    [SerializeField] GameObject Keeper;
    [SerializeField] GameObject Dog;
    [SerializeField] GameObject posKeeper;


    void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Player"){
            if(Door1.GetComponent<DoorController>().GetIsOpen()){
                Door1.GetComponent<DoorController>().CloseDoor();
                Door1.GetComponent<DoorController>().SetState(3);
                //Door1.GetComponent<DoorController>().SetCanOpen(false);
            }
            else{
                Door1.GetComponent<DoorController>().SetState(3);
            }
            if(Door2.GetComponent<DoorController>().GetIsOpen()){
                Door2.GetComponent<DoorController>().CloseDoor();
                Door2.GetComponent<DoorController>().SetState(3);
                //Door2.GetComponent<DoorController>().SetCanOpen(false);
            }
            else{
                Door2.GetComponent<DoorController>().SetState(3);
            }

            int randomIndex = Random.Range(0, posKeeper.transform.childCount);
            Transform randomChild = posKeeper.transform.GetChild(randomIndex);
            Keeper.transform.position = randomChild.position;
            Keeper.SetActive(true);

            randomIndex = Random.Range(0, posKeeper.transform.childCount);
            randomChild = posKeeper.transform.GetChild(randomIndex);
            Dog.transform.position = randomChild.position;
            Dog.SetActive(true);


            Destroy(gameObject);
        }
    }
}
