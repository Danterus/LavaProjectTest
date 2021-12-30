using Infrastructure;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private HeroSettings _heroSettings;
    [SerializeField] private HeroAnimator _heroAnimator;

    private HeroMovement _heroMovement;
    private HeroShooter _heroShooter;
    
    private HeroInput _heroInput;

    private Rigidbody _rb;
    

    private void Awake()
    {
        _heroMovement = GetComponent<HeroMovement>();
        _heroShooter = GetComponent<HeroShooter>(); 
        _heroInput = GetComponent<HeroInput>();

        _rb = GetComponent<Rigidbody>();
    }

    public void InitHero(BulletController bulletController, Vector3 position)
    {
        _rb.isKinematic = false;
        
        _heroMovement.Init(_heroAnimator,_heroSettings.GetMovementSpeed());
        _heroShooter.Init(bulletController, _heroAnimator,_heroSettings.GetReloadSpeed());
        
        _heroMovement.enabled = true;
        _heroShooter.enabled = false;

        _heroMovement.SetPosition(position);
        
        _heroInput.TapOnScreenEvent -= _heroShooter.ShootTowards;
        _heroInput.ReleaseScreenEvent -= _heroShooter.StopShooting;
        
        _heroInput.TapOnScreenEvent += _heroMovement.MoveTowards;
    }
    
    public void SwitchToShooting(Vector3 setPosition)
    {
        _rb.isKinematic = true;
        
        _heroMovement.SetPosition(setPosition);
        _heroMovement.StopMovement();
        _heroMovement.enabled = false;
        _heroShooter.enabled = true;

        _heroInput.TapOnScreenEvent -= _heroMovement.MoveTowards;
        
        _heroInput.TapOnScreenEvent += _heroShooter.ShootTowards;
        _heroInput.ReleaseScreenEvent += _heroShooter.StopShooting;
    }
}