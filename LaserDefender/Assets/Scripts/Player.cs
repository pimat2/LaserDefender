using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float paddinRight;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    Shooter shooterScript;
    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;
    
    void Awake() {
        shooterScript = GetComponent<Shooter>();    
    }
    void Start() {
        InitBound();    
    }
    void Update()
    {
        MovePlayer();
    }
    void OnMove(InputValue value){
        rawInput = value.Get<Vector2>();
        
    }
    void OnFire(InputValue value){
        if(shooterScript != null){
            shooterScript.isFiring = value.isPressed;
        }
    }
    void MovePlayer(){
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddinRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPos;

    }
    void InitBound(){
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }
}
