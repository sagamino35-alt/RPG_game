using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    [SerializeField] Vector3 offset;
    [SerializeField] float lookXValue;
    [SerializeField] float smoothSpeed = 5f;

    pMovment playerMovement;
    void Start()
    {
        offset = transform.position - playerPos.position;
        playerMovement = FindAnyObjectByType<pMovment>();
    }


    void Update()
    {
        

        transform.position = Vector3.Lerp(transform.position, playerPos.position + offset + new Vector3(lookXValue, 0, 0), smoothSpeed * Time.deltaTime);
    }
}
