using System.Collections.Generic;
using Infrastructure;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Level : MonoBehaviour
{
    [Header("Spawn Lists")]
    [SerializeField] private List<Transform> _heroSpawnPositions;
    [SerializeField] private List<Transform> _enemySpawnPositions;
    [SerializeField] private List<Transform> _towerSpawnPositions;
    [Header("Level Properties")]
    [SerializeField] private int _enemiesCount = 1;
    [SerializeField] private int _towersCount = 1;

    [Header("Nav Mesh Geometry")] 
    [SerializeField] private List<NavMeshSurface> _navMeshSurfaces;

    private TowerController _towerController;

    public List<Transform> GetHeroSpawnPositions() => _heroSpawnPositions;
    public List<Transform> GetEnemySpawnPositions() => _enemySpawnPositions;
    public List<Transform> GetTowerSpawnPositions() => _towerSpawnPositions;
    public int GetEnemyCount() => _enemiesCount;

    public void InitLevel(TowerController towerController, Hero hero)
    {
        _towerController = towerController;
        for (int i = 0; i < _towersCount; i++)
        {
            _towerController.SpawnTowerAtPosition(_towerSpawnPositions[Random.Range(0, _towerSpawnPositions.Count)].position, hero);
        }
        
        List<NavMeshSurface> surfaces = _towerController.GetNavMeshSurfaces();
        if (surfaces.Count > 0)
        {
            surfaces.AddRange(_navMeshSurfaces);
        }
        else
        {
            surfaces = _navMeshSurfaces;
        }

        NavigationBaker.BuildNavMesh(surfaces);
    }
}