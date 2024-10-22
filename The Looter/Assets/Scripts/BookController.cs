using UnityEngine;
using TMPro;

public class BookController : MonoBehaviour{
    private TextMeshPro[] textMeshPro;

    // Start is called before the first frame update
    void Start(){
        textMeshPro = GetComponentsInChildren<TextMeshPro>();
        // Imprimir los nombres de los componentes encontrados
        foreach (TextMeshPro text in textMeshPro){
            Debug.Log("Texto encontrado: " + text.text);
        }
    }


    public void fede(string name){
        foreach (TextMeshPro text in textMeshPro){
            if (text.text == name){
                string content = text.text;
                text.text = $"<s>{content}</s>";
            }   
        }
    }


}
