using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CounteractGravity : MonoBehaviour
{
    private Rigidbody Body = null;
    
    private void Awake()
    {
        Body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        PreventGravity();
    }

    private void PreventGravity()
    {
        if (!Body.useGravity)
            return;
        
        Vector3 reverseGravity = Physics.gravity * (Body.mass);
        reverseGravity *= -1;
        
        Body.AddForce(reverseGravity);
    }
}
