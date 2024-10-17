using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorController : MonoBehaviour {
    [SerializeField] private AudioSource openSFX;
    [SerializeField] private AudioSource closeSFX;
    [SerializeField] private bool hasSound;
    [SerializeField] private bool isOpen = false; // Estado inicial: abierta o cerrada
    [SerializeField] private float openAngle = 90f; // Ángulo de apertura (eje Z probablemente)
    [SerializeField] private float duration = 1f; // Duración de la animación de apertura/cierre
    [SerializeField] private Vector3 rotationAxis = new Vector3(0, 0, 1); // Eje de rotación, Z para puertas de auto

    private bool isMoving = false; // Para evitar múltiples interacciones simultáneas
    private Quaternion initialRotation; // Rotación inicial de la puerta
    private Quaternion openRotation;   // Rotación abierta

    void Start() {
        // Guardamos la rotación inicial de la puerta (respetando su rotación actual)
        initialRotation = transform.localRotation;

        // Definimos la rotación abierta relativa a la rotación inicial
        openRotation = initialRotation * Quaternion.Euler(rotationAxis * openAngle);

        // Si la puerta empieza abierta, actualizamos su rotación inicial
        if (isOpen) {
            transform.localRotation = openRotation;
        }
    }

    
    public bool GetIsOpen(){
        return isOpen;
    }


    public void ToggleDoor() {
        if (Input.GetKeyDown(KeyCode.E) && !isMoving) {
            isMoving = true;

            // Alternamos entre la rotación abierta y cerrada
            if (isOpen) {
                if(hasSound){
                    closeSFX.Play();
                }
                // Cerrar la puerta
                transform.DOLocalRotateQuaternion(initialRotation, duration).OnComplete(() => {
                    isMoving = false;
                    isOpen = false;
                });
            } else {
                if(hasSound){
                    openSFX.Play();
                }
                // Abrir la puerta
                transform.DOLocalRotateQuaternion(openRotation, duration).OnComplete(() => {
                    isMoving = false;
                    isOpen = true;
                });
            }
        }
    }
}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorController : MonoBehaviour{
    [SerializeField] bool isLeft;
    [SerializeField] bool isOpen;
    public float openAngle = 90f;
    public float duration = 1f;
    //private float scale = 0.8f;
    private bool isMoving = false;
    public void Open(){
        if(Input.GetKeyDown(KeyCode.E) && !isMoving){
            isMoving = true;
            if(isOpen){
                isOpen = false;
                if(isLeft){
                    transform.DORotate(new Vector3(0, transform.rotation.y - openAngle, 0), duration, RotateMode.LocalAxisAdd).OnComplete(() => {
                        isMoving = false;
                    });                 
                }
                else{
                    transform.DORotate(new Vector3(0, transform.rotation.y + openAngle, 0), duration, RotateMode.LocalAxisAdd).OnComplete(() => {
                        isMoving = false;
                    });
                }
            }
            else{
                isOpen = true;
                if(isLeft){
                    transform.DORotate(new Vector3(0, transform.rotation.y + openAngle, 0), duration, RotateMode.LocalAxisAdd).OnComplete(() => {
                        isMoving = false;
                    });
                }
                else{
                    transform.DORotate(new Vector3(0, transform.rotation.y - openAngle, 0), duration, RotateMode.LocalAxisAdd).OnComplete(() => {
                        isMoving = false;
                    });
                }
            }
        }
    }
}
*/