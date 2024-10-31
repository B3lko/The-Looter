using UnityEngine;

public class ButtonCube : MonoBehaviour{
    [SerializeField] GameObject door;
    public string name;

    private void OnMouseDown(){
        switch(name){
            case "AU": door.GetComponent<LockPuzzleController>().IncreasePositionA(); break;
            case "AD": door.GetComponent<LockPuzzleController>().DecreasePositionA(); break;
            case "BU": door.GetComponent<LockPuzzleController>().IncreasePositionB(); break;
            case "BD": door.GetComponent<LockPuzzleController>().DecreasePositionB(); break;
            case "CU": door.GetComponent<LockPuzzleController>().IncreasePositionC(); break;
            case "CD": door.GetComponent<LockPuzzleController>().DecreasePositionC(); break;
        }
    }
}
