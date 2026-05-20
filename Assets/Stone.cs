using UnityEngine;

public class Stone : MonoBehaviour
{
    Rigidbody rb;
    private void Awake()
    {
        rb= GetComponent<Rigidbody>(); 
    }
    
    private void Start()
    {
        rb.Sleep();
    }
}
