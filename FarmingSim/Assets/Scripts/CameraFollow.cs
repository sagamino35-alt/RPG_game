using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    [SerializeField] Vector3 offset;
   

    
    void Start()
    {
        offset = transform.position - playerPos.position;
        
    }


    private void FixedUpdate()
    {
        transform.position = playerPos.position + offset;

        
    }
}
