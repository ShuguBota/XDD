using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float BulletSpeed = 20.0f;
    
    public void Start()
    {
        var rb = GetComponent<Rigidbody>();
        
        rb.AddForce(transform.forward * BulletSpeed, ForceMode.VelocityChange);
    }
}
