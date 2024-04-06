using UnityEngine;

public class Camera : MonoBehaviour
{
    private readonly Vector3 _offsetPosition = new (0, 3, -3);
    private readonly Vector3 _offsetRotation = new (25, 0, 0); 
    private GameObject _player;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = _player.transform.position + _offsetPosition;
        transform.rotation = _player.transform.rotation * Quaternion.Euler(_offsetRotation);
    }
}
