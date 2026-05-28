using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private float speed = 0.125f;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(offset == Vector3.zero)
        {
            offset = transform.position;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 movePosition = target.position + offset;
        transform.position = Vector3.Slerp(transform.position, movePosition, speed);
    }
}
