using UnityEngine;

public class Light_Interruptor : MonoBehaviour{
    private bool state = false;
    public GameObject ligths;
    public void UseInterruptor(){
        if(Input.GetKeyDown(KeyCode.E)){
            state = !state;
            ligths.SetActive(state);
        }
    }
}
