using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public KeyCode ShotKey = KeyCode.Space;
    public float ShotCooldown = 0.5f;
    
    private float NextAllowedShotTimeStamp = 0.0f;
    
    private LaserGun laserGun_;

    void Awake()
    {
        laserGun_ = GetComponentInChildren<LaserGun>();
    }

    void Update()
    {
        CheckShootingInput();
    }

    void CheckShootingInput()
    {
        if (Time.time < NextAllowedShotTimeStamp)
            return;
        
        if (Input.GetKeyDown(ShotKey))
        {
            laserGun_.Shoot();
            NextAllowedShotTimeStamp = Time.time + ShotCooldown;
        }
    }
}
