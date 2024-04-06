using UnityEngine;

public class Player : MonoBehaviour
{
    // Movement
    private const float Speed = 5.0f;
    private const float RotationSpeed = 90.0f;
    private float _horizontalInput;
    private float _verticalInput;

    // Bullet
    public GameObject bulletPrefab;
    
    private const float FireRate = 5.0f;
    private float _nextFireTime;
    private readonly Vector3 _bulletPositionOffset = new(0, 1, 0.5f);

    // Update is called once per frame
    void Update()
    {
        HandleMovement();

        if (Input.GetMouseButton(0) && Time.time >= _nextFireTime) // Use GetMouseButton for continuous checking
        {
            Shoot();
            _nextFireTime = Time.time + 1f / FireRate; // Calculate the next fire time
        }
    }

    private void HandleMovement()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * (Speed * Time.deltaTime * _horizontalInput));
        
        transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime * _horizontalInput);
        transform.Translate(Vector3.forward * (Speed * Time.deltaTime * _verticalInput));
    }

    private void Shoot()
    {
        // Instantiate the bullet at the bulletSpawnPoint's position and rotation
        var playerTransform = transform;
        
        Instantiate(bulletPrefab, playerTransform.position + _bulletPositionOffset, playerTransform.rotation);
    }
}
