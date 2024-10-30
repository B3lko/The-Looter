using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorLockedKey : MonoBehaviour{
    [SerializeField] GameObject player;
    private bool hasKey = false;
    private string name = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetName(string namee){
        this.name = namee;
    }

    public bool CanOpen(){
        if(player.GetComponent<PlayerInventory>().hasAKey(name)){
            return true;
        }
        else{
            return false;
        }
    }

    public void OpenDoor(){
        //Vector3 rotationAxis = Quaternion.Euler(0, 90, 0);
        transform.DOLocalRotateQuaternion(Quaternion.Euler(0, -90, 0), 2f).OnComplete(() => {});
        gameObject.transform.GetChild(0).tag = "Untagged";
    }
}
