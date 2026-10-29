using System;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.XR;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private Vector3 _movementInput;

    [SerializeField] private List<GameObject> shapes;

    private int inControl;

    private void Awake()
    {
        inControl = 0;
    }

    private void Update()
    {
        HandleInput();
        HandleChangeControl();
        HandleMovement();
    }
    
    
    private void HandleInput()
    {
        float yMovement = 0;
        if (Input.GetKey(KeyCode.Space))
        {
            yMovement = 1;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            yMovement = -1;
        }
        
        float zMovement = Input.GetAxisRaw("Vertical");
        float xMovement = Input.GetAxisRaw("Horizontal");
        
        _movementInput = new Vector3
        (
            xMovement,
            yMovement,
            zMovement
        ).normalized;
       
    }

    private void HandleMovement()
    {
        
        Vector3 movementVelocity = _movementInput * speed * Time.deltaTime;
        shapes[inControl].gameObject.transform.position += movementVelocity;
    }

    private void HandleChangeControl()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            inControl = (inControl + 1) % shapes.Count;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            inControl = (inControl - 1 + shapes.Count) % shapes.Count;
        }
    }
}
