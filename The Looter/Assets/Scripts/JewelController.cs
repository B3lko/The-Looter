using UnityEngine;

public class JewelController : MonoBehaviour{
    private GameObject bk;
    private GameObject GameCont;
    private bool isReady = false;



    public void SetReady(){
        isReady = true;
    }


    public bool GetReady(){
        return isReady;
    }


    void Awake(){
        bk = GameObject.FindWithTag("Book");
        GameCont = GameObject.FindWithTag("GameController");
    }


    void Start(){
        bk.SetActive(false);
    }


    public void SetJewel(){
        if(isReady){
            bk.GetComponent<BookController>().fede(gameObject.transform.parent.GetChild(6).GetComponent<TombController>().GetName());
            GameCont.GetComponent<GameController>().AddJewel();
            Destroy(gameObject);
        }
    }
}
