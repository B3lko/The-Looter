using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorController : MonoBehaviour {
    [SerializeField] private bool NeedThings;
    [SerializeField] int index;
    [SerializeField] int state = 2;
    [SerializeField] bool canOpen = true;
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
            state = 1;
        }
    }

    
    public bool GetIsOpen(){
        return isOpen;
    }

    public void SetCanOpen(bool can){
        canOpen = can;
    }

    public string GetTextState(){
        switch(state){
            case 1: return "Press 'E' to close";
            case 2: return "Press 'E' to open";
            case 3: return "First I must loot the tombs";
            case 4: return "First I have to grab the tools in the trunk of the car";
            default: return "No deberias estar viendo esto";
        }
    }

    


    public void ToggleDoor() {
        if(state == 3 || state == 4){
            openSFX.Play();
        }
        else if (!isMoving && canOpen) {
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
                    state = 2;
                });
            } else {
                if(hasSound){
                    openSFX.Play();
                }
                // Abrir la puerta
                transform.DOLocalRotateQuaternion(openRotation, duration).OnComplete(() => {
                    isMoving = false;
                    isOpen = true;
                    state = 1;
                });
            }
        }
    }
}
