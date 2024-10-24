using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseController : MonoBehaviour{
    [SerializeField] GameObject black;
    [SerializeField] GameObject keeper;
    [SerializeField] GameObject player;

    void Update() {
        if(Input.GetKeyDown(KeyCode.K)){
            StartFinishLoser();
        }
    }
    public void StartFinishLoser(){
        //black.
        
        player.GetComponent<PlayerController>().SetMove(false);
        player.transform.GetChild(0).transform.localRotation = Quaternion.Euler(10, transform.localRotation.y, transform.localRotation.z);
        keeper.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        keeper.transform.SetParent(player.transform);
        keeper.transform.localPosition = new Vector3(0, 0, 1.1f); //1.3f
        keeper.transform.localRotation = Quaternion.Euler(-10, 180, 0);
        keeper.transform/*.GetChild(0).gameObject*/.GetComponent<KeeperController>().SetAnimationFinish();
    }

    public void SetAFinish(){
        black.SetActive(true);
    }

}
