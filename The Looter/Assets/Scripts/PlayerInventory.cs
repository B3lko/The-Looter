using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;


public class PlayerInventory : MonoBehaviour{
    private List<string> stringList = new List<string>();
    [SerializeField] GameObject Door1;
    [SerializeField] GameObject Door2;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject book;
    private int keyIndex = 1;


    public bool hasAKey(string keyName){
        for(int i = 0; i < stringList.Count; i++){
            if(stringList[i] == keyName){
                return true;
            }
        }
        return false;
    }

    public void AddString(string newString){
        if(newString == "Key"){
            GameData.Instance.CollectKey();
            newString += keyIndex;
            keyIndex += 1;
        }
        if(newString == "Great"){
            GameData.Instance.CollectGreat();
        }
        stringList.Add(newString);
        Debug.Log("Agregado: " + newString);
        if(stringList.Count == 3){
            Door1.GetComponent<DoorController>().SetState(2);
            Door2.GetComponent<DoorController>().SetState(2);
        }
        if(newString == "FlashLight"){
            gameObject.GetComponent<PlayerController>().SetHasLightFlash(true);
            text.text = "Press 'F' to use the flashlight";
            text.gameObject.SetActive(true);
            DOVirtual.DelayedCall(3, () => {
                text.gameObject.SetActive(false);
            });

        }

        if(newString == "NoteBook"){
            gameObject.GetComponent<PlayerController>().SetHasBook(true);
            text.text = "Press 'B' to read the book";
            text.gameObject.SetActive(true);
            DOVirtual.DelayedCall(3, () => {
                text.gameObject.SetActive(false);
            });
        }

        if(newString == "Jewel"){
            
        }
    }
    
}
