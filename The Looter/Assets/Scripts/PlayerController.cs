using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    [SerializeField] GameObject flashLigth;
    [SerializeField] AudioSource flashLigthOn;
    [SerializeField] AudioSource flashLigthOff;
    private bool isFlashOn = false; 
    private CharacterController _player;
    [SerializeField] private float _moveSpeed, _gravity, _fallVelocity, _jumpForce;
    private Vector3 _axis, _movePlayer;
    public float mouseSensitivity = 200f;
    public Transform playerBody;
    public float moveSpeed = 5.0f;
    private float verticalRotation = 0;
    Vector3 moveDirection;

    void Awake() {
        _player = GetComponent<CharacterController>(); 
    } 
    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void SetGravity(){
        if(_player.isGrounded){
            _fallVelocity = -_gravity * Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.Space)){
                _fallVelocity = _jumpForce;
            }
        }
        else{
            _fallVelocity -= _gravity * Time.deltaTime; 
        }
        moveDirection.y = _fallVelocity;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.F)){
            isFlashOn = !isFlashOn; 
            flashLigth.SetActive(isFlashOn);
            if(isFlashOn){
                flashLigthOn.Play();
            }
            else{
                flashLigthOff.Play();
            }
        }
        if(Input.GetKeyDown(KeyCode.Z)){
           // moveSpeed = 
        }

        // Movimiento del ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        transform.Rotate(Vector3.up * mouseX);
        transform.GetChild(0).localRotation = Quaternion.Euler(verticalRotation, 0, 0); // Rotar la cámara hija

        // Movimiento del teclado
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        moveDirection = transform.right * moveHorizontal + transform.forward * moveVertical;
        SetGravity();
        moveDirection *= moveSpeed;

        _player.Move(moveDirection * _moveSpeed * Time.deltaTime);
    }
}
