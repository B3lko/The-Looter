using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class GraveController : MonoBehaviour{
    [SerializeField] AudioSource paladaSFX;
    [SerializeField] GameObject pala;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPalada(){
        pala.transform.position = new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z);
        pala.transform.rotation = Quaternion.Euler(90,0,0);
        pala.SetActive(true);
        pala.transform.DORotate(new Vector3(45, 0, 0), 1f);
        pala.transform.DOMove(new Vector3(transform.position.x + 1,transform.position.y - 0.3f, transform.position.z),1.0f).OnComplete(() => {
            paladaSFX.Play();
        });
        //pala
    }
}
