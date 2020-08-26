using System;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public WallData Data = null;

    private float CurrentHealth;
    private AudioSource Source = null;
    private MeshRenderer Mesh = null;
    private Collider Collider = null;

    private void Awake()
    {
        if (Data == null)
        {
            Debug.Log(gameObject.name + " does not have any WallData, please link the correct WallData in the inspector");
            this.enabled = false;
        }
        Mesh = GetComponent<MeshRenderer>();
        Collider = GetComponent<Collider>();
        Source = GetComponent<AudioSource>();
        CurrentHealth = Data.MaxHealth;
    }

    public void TakeDamage(ref float pDamage)
    {
        float remainingShotDamage = pDamage;
        remainingShotDamage -= CurrentHealth;
        CurrentHealth -= pDamage;
        pDamage = remainingShotDamage;
        
        Source.PlayOneShot(Data.HitSound);

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        const float DEATH_DELAY = 1.5f;
        
        Mesh.enabled = false;
        Collider.enabled = false;
        Destroy(gameObject, DEATH_DELAY);
        this.enabled = false;
    }
}
