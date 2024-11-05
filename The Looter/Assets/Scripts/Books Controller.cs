using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BooksController : MonoBehaviour{
    [SerializeField] GameObject[] books;

    private int bookIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B)){
            //Cursor.visible = true;
            //Cursor.lockState = CursorLockMode.None;
            books[bookIndex].SetActive(true);
        }
    }

    public void SetNextPage(){
       // books[bookIndex].transform.DOMoveY(books[bookIndex].transform.position.y - 1, 0.5f).OnComplete(() => {
            books[bookIndex].SetActive(false);
            if(bookIndex == books.Length - 1){
                bookIndex = 0;
            }
            else{
                bookIndex += 1;
            }
            books[bookIndex].SetActive(true);
            //books[bookIndex].transform.DOMoveY(books[bookIndex].transform.position.y + 1, 0.5f);//.OnComplete(() => {
        //});
    }

    public void SetPreviousPage(){
       // books[bookIndex].transform.DOMoveY(books[bookIndex].transform.position.y - 1, 0.5f).OnComplete(() => {
            books[bookIndex].SetActive(false);
            if(bookIndex == 0){
                bookIndex = books.Length - 1;
            }
            else{
                bookIndex -= 1;
            }
            books[bookIndex].SetActive(true);
            //books[bookIndex].transform.DOMoveY(books[bookIndex].transform.position.y + 1, 0.5f);//.OnComplete(() => {
        //});
    }
}
