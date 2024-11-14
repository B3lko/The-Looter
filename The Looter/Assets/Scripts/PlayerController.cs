using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour{
    [SerializeField] GameObject flashLigth;
    [SerializeField] GameObject book;
    [SerializeField] GameObject bookBtn;
    [SerializeField] GameObject next;
    [SerializeField] GameObject previous;
    [SerializeField] bool hasALigthFlash = false;
    [SerializeField] bool hasABook = false;
    [SerializeField] AudioSource flashLigthOn;
    [SerializeField] AudioSource flashLigthOff;
    public AudioClip[] earthSounds; // Array para sonidos de tierra
    public AudioClip[] stoneSounds;  // Array para sonidos de piedra
    public AudioClip[] stoneRunSounds;  // Array para sonidos de piedra correr
    public AudioSource audioSource;   // Componente AudioSource
    private bool isFlashOn = false; 
    private bool isBookOn = true; 
    private CharacterController _player;
    [SerializeField] private float _gravity, _fallVelocity, _jumpForce;
    private Vector3 _axis, _movePlayer;
    public float mouseSensitivity;// = 200f;
    public Transform playerBody;
    private float walkSpeed = 2.0f;
    private float runSpeed = 3.0f;
    private float _moveSpeed = 0;
    private float verticalRotation = 0;
    Vector3 moveDirection;
    private bool canMove = false;
    ///
    public float energy = 100f; // Energía inicial
    public float depletionRate = 20f; // Velocidad a la que disminuye la energía mientras corre
    public float recoveryRate = 10f; // Velocidad a la que se recupera la energía mientras no corre
    public AudioSource outOfEnergySound; // Asigna el sonido en el Inspector
    private bool isRunning = false;
    private bool canMove2 = true;
    private bool isOutOfEnergy = false;
    private float rechargeTimer = 0f;
    public float rechargeDelay = 2f; // Tiempo de espera antes de comenzar a recargar
    private bool isPause = false;
    public Image stamina;
    public Image staminaBG;

    void Awake() {
        _player = GetComponent<CharacterController>(); 
    } 
    void Start(){
        LoadSensitivity();
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
        if(isBookOn){
            Debug.Log("ASD0000000000000000000000000");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if(!isPause){
            BookUpdate();
            FlashLightUpdate();
            if(canMove){
                Movement();
            }
        }
    }

    public void SetPause(){
        isPause = !isPause;
    }

    private void BookUpdate(){
        if(Input.GetKeyDown(KeyCode.B)){
           ToggleBook();
        }
    }

    public void ToggleBook(){
        isBookOn = !isBookOn; 
        bookBtn.SetActive(isBookOn);
        canMove = !isBookOn;
        book.SetActive(isBookOn);
        next.SetActive(isBookOn);
        previous.SetActive(isBookOn);
        if(isBookOn){
            flashLigthOn.Play();
        }
        else{
            flashLigthOff.Play();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void FlashLightUpdate(){
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
    }

    public void SetMove(bool can){
        canMove = can;
    }

    private void Movement(){
        MouseMovement();
        KeyboardMovement();
    }

    private void LoadSensitivity(){
        mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 1.0f);
        Debug.Log(mouseSensitivity);
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

        if(canMove2){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        moveDirection = transform.right * moveHorizontal + transform.forward * moveVertical;
            if(moveDirection.magnitude > 0){
                if(Input.GetKey(KeyCode.LeftShift)){
                    _moveSpeed = runSpeed;
                    isRunning = true;
                }
                else{
                    _moveSpeed = walkSpeed;
                    isRunning = false;
                }
                if(!audioSource.isPlaying){
                    PlayFootstepSound();
                }
            }
            else if (isRunning){
                isRunning = false;
            }
            moveDirection *=  _moveSpeed;
        }

        SetGravity();
        _player.Move(moveDirection * _moveSpeed * Time.deltaTime);


        if (isRunning && !isOutOfEnergy){
            staminaBG.gameObject.SetActive(true);
            energy -= depletionRate * Time.deltaTime;
            if (energy <= 0){   
                canMove2 = false;
                energy = 0;
                isRunning = false;
                isOutOfEnergy = true;
                rechargeTimer = rechargeDelay; // Iniciar el temporizador de recarga
                moveDirection = Vector3.zero;
                outOfEnergySound.Play();
                // Aquí puedes detener la velocidad de movimiento si lo necesitas
            }
        }
        else if (isOutOfEnergy)
        {
            // Contar el tiempo de espera antes de la recarga
            rechargeTimer -= Time.deltaTime;
            if (rechargeTimer <= 0)
            {
                 canMove2 = true;
                isOutOfEnergy = false;
            }
        }
        else if (energy < 100f)
        {
            // Recuperación de energía
            energy += recoveryRate * Time.deltaTime;
            if (energy > 100f){
                staminaBG.gameObject.SetActive(false);
                energy = 100f;
            }
        }
        stamina.fillAmount = energy / 100;
    
    }


    void PlayFootstepSound(){
        // Aquí puedes determinar el tipo de superficie
        string surfaceType = CheckSurface(); // Implementa esta función
        //AudioClip[] selectedSounds = surfaceType == "dirt" ? earthSounds : stoneSounds;
        AudioClip[] selectedSounds;
        if (surfaceType == "dirt") {
            selectedSounds = earthSounds;
        }
        else{
            if(_moveSpeed == runSpeed){
                selectedSounds = stoneRunSounds;
            }
            else{
                selectedSounds = stoneSounds;
            }
        }
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
