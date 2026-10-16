using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private Vector3 _movementInput;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        HandleInput();
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
        transform.position += movementVelocity;
    }
}
