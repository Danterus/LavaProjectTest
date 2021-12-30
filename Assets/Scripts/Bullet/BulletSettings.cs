using UnityEngine;

[CreateAssetMenu(fileName = "Bullet Setting", menuName = "Create new bullet setting")]
public class BulletSettings : ScriptableObject
{
    [SerializeField] private string _bulletName;
    [SerializeField] private float _bulletPushPower;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletSize;

    public float GetPushPower() => 
        _bulletPushPower;

    public float GetSpeed() => 
        _bulletSpeed;

    public float GetSizeScale() => 
        _bulletSize;
}