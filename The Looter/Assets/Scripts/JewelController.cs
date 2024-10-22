using UnityEngine;

public class JewelController : MonoBehaviour{
    private GameObject bk;
    private GameObject GameCont;
    //private BookController bkc;

    void Awake() {
        
        bk = GameObject.FindWithTag("Book");
        GameCont = GameObject.FindWithTag("GameController");
    }

    void Start() {
        bk.SetActive(false);
        //bkc = bk.GetComponent<BookController>();
    }
    public void SetJewel(){
        Debug.Log("Joya agarrada");
        //BookController bkc = bk.GetComponent<BookController>();
        //bkc.fede(/*gameObject.transform.parent.GetChild(6).GetComponent<TombController>().GetName()*/"HomeloChino");
        bk.GetComponent<BookController>().fede(gameObject.transform.parent.GetChild(6).GetComponent<TombController>().GetName());
        GameCont.GetComponent<GameController>().AddJewel();
        Destroy(gameObject);
    }
}
