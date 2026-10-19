using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector2 offset;  
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, -10f);
    }
}
