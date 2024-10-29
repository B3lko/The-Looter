using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class GraveController : MonoBehaviour{
    [SerializeField] AudioSource paladaSFX;
    [SerializeField] GameObject pala;
    private bool isPalading = false;
    private float scale = 1.5f;
    private float time = 1.5f;


    public void DoPalada(){
        if(!isPalading){
            isPalading = true;
            /*pala.transform.position = new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z);
            pala.transform.rotation = Quaternion.Euler(90,0,0);
            pala.SetActive(true);
            pala.transform.DORotate(new Vector3(45, 0, 0), 1f);
            pala.transform.DOMove(new Vector3(transform.position.x + 1,transform.position.y - 0.3f, transform.position.z),1.0f).OnComplete(() => {*/
                paladaSFX.Play();
                /*pala.transform.DOMove(new Vector3(transform.position.x - 1,transform.position.y + 0.3f, transform.position.z),0.5f).OnComplete(() => {
                    pala.SetActive(false);
                });*/

                if(transform.localScale.y == 0.5f){
                    transform.DOMoveY(transform.position.y - 0.25f, time).OnComplete(() => {
                        gameObject.tag = "Untagged";
                        transform.parent.GetChild(0).GetChild(0).GetComponent<CoffinController>().SetReady();
                        if(transform.parent.GetChild(7) != null){
                            transform.parent.GetChild(7).GetComponent<JewelController>().SetReady();
                        }
                    });
                }
                else{
                    transform.DOMoveY(transform.position.y - 0.05f, time);
                    transform.DOScaleY(scale, time).OnComplete(() => {
                        scale -= 0.5f;
                        isPalading = false;
                    });
                }
            //});
        }
    }

    public void StartPalada(){
        pala.transform.position = new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z);
        pala.transform.rotation = Quaternion.Euler(90,0,0);
        pala.SetActive(true);
        pala.transform.DORotate(new Vector3(45, 0, 0), 1f);
        pala.transform.DOMove(new Vector3(transform.position.x + 1,transform.position.y - 0.3f, transform.position.z),1.0f).OnComplete(() => {
            paladaSFX.Play();
            pala.transform.DOMove(new Vector3(transform.position.x - 1,transform.position.y + 0.3f, transform.position.z),0.5f);
            transform.DOScaleY(1.5f,0.5f).OnComplete(() => {
                pala.transform.DOMove(new Vector3(transform.position.x + 1,transform.position.y - 0.3f, transform.position.z),1.0f).OnComplete(() => {
                    paladaSFX.Play();
                    transform.DOScaleY(1f,0.5f).OnComplete(() => {
                        paladaSFX.Play();
                        pala.transform.DOMove(new Vector3(transform.position.x - 1,transform.position.y + 0.3f, transform.position.z),0.5f);
                        transform.DOScaleY(0.5f,0.5f).OnComplete(() => {
                            paladaSFX.Play();
                            pala.transform.DOMove(new Vector3(transform.position.x - 1,transform.position.y + 0.3f, transform.position.z),0.5f);
                            transform.DOScaleY(0f,0.5f);
                        });
                    });
                });
            });
            paladaSFX.Play();
        });
        //pala
    }
}
