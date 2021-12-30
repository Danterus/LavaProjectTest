using UnityEngine;

[CreateAssetMenu(menuName = "Create HeroSettings", fileName = "HeroSettings", order = 0)]
public class HeroSettings : ScriptableObject
{
    [SerializeField] private float _playerMovementSpeed;
    [SerializeField] private float _playerReloadSpeed;

    public float GetMovementSpeed() => _playerMovementSpeed;
    public float GetReloadSpeed() => _playerReloadSpeed;
}