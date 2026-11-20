using System;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.XR;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rSpeed = 90;
    
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

        HandleChangeControl();

        HandleMovement();

        HandleRotation();

        HandleSize();
    }

    private void HandleMovement()
    {
        Vector3 movementVelocity = _movementInput * speed * Time.deltaTime;

        shapes[inControl].gameObject.transform.position += movementVelocity;
    }

    private void HandleRotation()
    {
        if (Input.GetKey(KeyCode.Y))
            shapes[inControl].transform.Rotate(rSpeed * Time.deltaTime, 0f, 0f);

        if (Input.GetKey(KeyCode.U))
            shapes[inControl].transform.Rotate(0f, rSpeed * Time.deltaTime, 0f);

        if (Input.GetKey(KeyCode.I))
            shapes[inControl].transform.Rotate(0f, 0f, rSpeed * Time.deltaTime);
    }

    private void HandleSize()
    {
        Vector3 _actualScale = shapes[inControl].transform.localScale;

        if (Input.GetKey(KeyCode.H))
            shapes[inControl].transform.localScale = _actualScale + new Vector3(1.0f, 1.0f, 1.0f);

        if (Input.GetKey(KeyCode.K))
            shapes[inControl].transform.localScale = _actualScale - new Vector3(1.0f, 1.0f, 1.0f);
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
