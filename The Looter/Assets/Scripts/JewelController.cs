using UnityEngine;
using DG.Tweening;

public class JewelController : MonoBehaviour{
    private GameObject bk;
    private GameObject GameCont;
    private bool isReady = false;
    public bool isWall;
    [SerializeField] private AudioSource pickSFX;



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
        //if(transform.parent.transform.parent.GetChild(1).GetComponent<TombController>().isWall){
        //if(transform.parent.GetChild(6).GetComponent<TombController>().isWall){
            //bk.SetActive(true);
            pickSFX.Play();

            
            if(isWall){
                //string name = gameObject.transform.parent.transform.parent.GetChild(1).GetComponent<TombController>().GetName();
                bk.GetComponent<BookController>().fede(gameObject.transform.parent.transform.parent.GetChild(1).GetComponent<TombController>().GetName());
            }
            else{
                //string name = gameObject.transform.parent.GetChild(1).GetComponent<TombController>().GetName();
                bk.GetComponent<BookController>().fede(gameObject.transform.parent.GetChild(1).GetComponent<TombController>().GetName());
            }
            //Debug.Log("El nombre es: " + name);
            //bk.GetComponent<BookController>().fede(name);
            GameCont.GetComponent<GameController>().AddJewel();
            GameData.Instance.CollectJewel();
            //bk.SetActive(false);
            DOVirtual.DelayedCall(pickSFX.clip.length, () => {
                Destroy(gameObject);
            });
            
       /* }
        if(isReady){
            GameData.Instance.CollectJewel();
            bk.GetComponent<BookController>().fede(gameObject.transform.parent.GetChild(6).GetComponent<TombController>().GetName());
            GameCont.GetComponent<GameController>().AddJewel();
            Destroy(gameObject);
        }*/
    }
}
