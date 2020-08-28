using System.Collections;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    public float Damage = 5.0f;
    public float ShotDistance = 50.0f;
    public float DebugLaserDuration = 0.1f;
    
    private ParticleSystem LaserBeam = null;


    private void Awake()
    {
        LaserBeam = GetComponentInChildren<ParticleSystem>();
    }

    public void Shoot()
    {
        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, ShotDistance);
        hits = SortRayhitsBasedOnDistance(hits);
        float shotDamage = Damage;
        Vector3 lastWallHit = transform.position;
        foreach (RaycastHit r in hits)
        {
            r.transform.gameObject.GetComponent<Wall>().TakeDamage(ref shotDamage);
            if (shotDamage < 0)
            {
                lastWallHit = r.transform.position;
                break;
            }
        }
        StartCoroutine(LaserBeamParticlePlay());
        DebugDrawLaser(lastWallHit);
    }

    IEnumerator LaserBeamParticlePlay()
    {
        yield return new WaitForSeconds(0.1f);
        LaserBeam.Play(true);
        yield return new WaitForSeconds(0.5f);
        LaserBeam.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        yield return null;
    }

    private void DebugDrawLaser(Vector3 pDestination)
    {
        Debug.DrawLine(transform.position, pDestination, Color.red, DebugLaserDuration);
    }

    private RaycastHit[] SortRayhitsBasedOnDistance(RaycastHit[] pHits)
    {
        Vector3 currentPosition = transform.position;

        for(int i = 0; i < pHits.Length - 1; i++)
        {
            for (int j = i + 1; j > 0; j--)
            {
                float distanceToCurrentHit = Vector3.Distance(currentPosition, pHits[j].transform.position);
                float distanceToNextHit = Vector3.Distance(currentPosition, pHits[j - 1].transform.position);
                if (distanceToCurrentHit < distanceToNextHit)
                {
                    RaycastHit temp = pHits[j - 1];
                    pHits[j - 1] = pHits[j];
                    pHits[j] = temp;
                }
            }
        }
        return pHits;
    }
}
