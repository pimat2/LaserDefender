using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Vector2 rawInput;
    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    void OnMove(InputValue value){
        rawInput = value.Get<Vector2>();
        
    }
    void MovePlayer(){
        Vector3 delta = rawInput;
        transform.position += delta * moveSpeed * Time.deltaTime;
    }
}
