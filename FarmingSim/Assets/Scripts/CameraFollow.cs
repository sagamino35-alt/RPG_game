using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    [SerializeField] Vector3 offset;
   

    
    void Start()
    {
        offset = transform.position - playerPos.position;
        
    }


    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, playerPos.position + offset, 0.2f) ;

        
    }
}
