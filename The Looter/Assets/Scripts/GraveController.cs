using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class GraveController : MonoBehaviour{
    [SerializeField] AudioSource paladaSFX;
    [SerializeField] GameObject pala;
    private bool isPalading = false;
    private float scale = 1.5f;


    public void DoPalada(){
        if(!isPalading){
            isPalading = true;
            pala.transform.position = new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z);
            pala.transform.rotation = Quaternion.Euler(90,0,0);
            pala.SetActive(true);
            pala.transform.DORotate(new Vector3(45, 0, 0), 1f);
            pala.transform.DOMove(new Vector3(transform.position.x + 1,transform.position.y - 0.3f, transform.position.z),1.0f).OnComplete(() => {
                paladaSFX.Play();
                pala.transform.DOMove(new Vector3(transform.position.x - 1,transform.position.y + 0.3f, transform.position.z),0.5f);
                transform.DOScaleY(scale, 0.5f).OnComplete(() => {
                    scale -= 0.5f;
                    if(scale == 0){
                        gameObject.SetActive(false);
                    }
                    else{
                        isPalading = false;
                    }
                });
            });
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
