using UnityEngine;

[CreateAssetMenu(fileName = "WallData", menuName = "Wall", order = 1)]
public class WallData : ScriptableObject
{
    public float MaxHealth = 1.0f;
    public AudioClip HitSound;
}
