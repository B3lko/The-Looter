using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    [SerializeField] GameObject flashLigth;
    [SerializeField] GameObject book;
    [SerializeField] bool hasALigthFlash = false;
    [SerializeField] bool hasABook = false;
    [SerializeField] AudioSource flashLigthOn;
    [SerializeField] AudioSource flashLigthOff;
    public AudioClip[] earthSounds; // Array para sonidos de tierra
    public AudioClip[] stoneSounds;  // Array para sonidos de piedra
    public AudioSource audioSource;   // Componente AudioSource
    private bool isFlashOn = false; 
    private bool isBookOn = false; 
    private CharacterController _player;
    [SerializeField] private float _gravity, _fallVelocity, _jumpForce;
    private Vector3 _axis, _movePlayer;
    public float mouseSensitivity = 200f;
    public Transform playerBody;
    private float walkSpeed = 2.0f;
    private float runSpeed = 3.0f;
    private float _moveSpeed = 0;
    private float verticalRotation = 0;
    Vector3 moveDirection;
    private bool canMove = true;

    void Awake() {
        _player = GetComponent<CharacterController>(); 
    } 
    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void SetGravity(){
        if(_player.isGrounded){
            _fallVelocity = -_gravity * Time.deltaTime;
            /*if(Input.GetKeyDown(KeyCode.Space)){
                _fallVelocity = _jumpForce;
            }*/
        }
        else{
            _fallVelocity -= _gravity * Time.deltaTime; 
        }
        moveDirection.y = _fallVelocity;
    }


    public void SetHasLightFlash(bool has){
        hasALigthFlash = has;
    }


    public void SetHasBook(bool has){
        hasABook = has;
    }

    public void offBookFlash(){
        isFlashOn = false;
        flashLigth.SetActive(isFlashOn);
        isBookOn = false; 
        book.SetActive(isBookOn);
    }


    void Update(){
        if(Input.GetKeyDown(KeyCode.F) && hasALigthFlash && canMove){
            isFlashOn = !isFlashOn; 
            flashLigth.SetActive(isFlashOn);
            if(isFlashOn){
                flashLigthOn.Play();
            }
            else{
                flashLigthOff.Play();
            }
        }
        if(Input.GetKeyDown(KeyCode.B) && hasABook && canMove){
           isBookOn = !isBookOn; 
            book.SetActive(isBookOn);
            if(isBookOn){
                flashLigthOn.Play();
            }
            else{
                flashLigthOff.Play();
            }
        }

        if(canMove){
            Movement();
        }
        
    }

    public void SetMove(bool can){
        canMove = can;
    }

    private void Movement(){
        MouseMovement();
        KeyboardMovement();
    }


    private void MouseMovement(){
        // Movimiento del ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        transform.Rotate(Vector3.up * mouseX);
        transform.GetChild(0).localRotation = Quaternion.Euler(verticalRotation, 0, 0); // Rotar la cámara hija
    }


    private void KeyboardMovement(){
        // Movimiento del teclado
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        moveDirection = transform.right * moveHorizontal + transform.forward * moveVertical;

        
        if(moveDirection.magnitude > 0){
            Debug.Log("Nada");
            if(Input.GetKey(KeyCode.LeftShift)){
                Debug.Log("Corre");
                _moveSpeed = runSpeed;
            }
            else{
                Debug.Log("Camina");
                _moveSpeed = walkSpeed;
            }
        }


        /*if (moveDirection.magnitude > 0){
            if(!audioSource.isPlaying){
                PlayFootstepSound();
            }
        }
        if(audioSource.isPlaying && moveDirection.magnitude < 0){
            audioSource.Stop();
        }*/
        SetGravity();
        moveDirection *=  _moveSpeed;
        _player.Move(moveDirection * _moveSpeed * Time.deltaTime);
    }


    void PlayFootstepSound(){
        // Aquí puedes determinar el tipo de superficie
        string surfaceType = CheckSurface(); // Implementa esta función
        AudioClip[] selectedSounds = surfaceType == "dirt" ? earthSounds : stoneSounds;
        AudioClip clip = selectedSounds[Random.Range(0, selectedSounds.Length)];
        audioSource.PlayOneShot(clip);
    }


    string CheckSurface(){
        RaycastHit hit;
        // Realiza un raycast hacia abajo desde la posición del personaje
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.0f)){
            // Verifica si el collider que se golpeó tiene la etiqueta "Ground"
            if (hit.collider.CompareTag("Ground")){
                return "dirt"; // Si es "Ground", considera que es tierra
            }
        }
        return "stone"; // Si no es "Ground", considera que es piedra
    }
}
