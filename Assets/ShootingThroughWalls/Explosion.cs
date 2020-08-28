using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float ExplosionForce = 200.0f;
    public float ExplosionRadius = 5.0f;
    private void OnEnable()
    {
        Rigidbody[] cellBodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody r in cellBodies)
        {
            r.AddExplosionForce(ExplosionForce, transform.position, ExplosionRadius);
        }
    }
}
