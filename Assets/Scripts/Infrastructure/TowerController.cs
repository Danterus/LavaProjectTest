using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Infrastructure
{
    public class TowerController : PoolController<Tower>
    {
        public void SpawnTowerAtPosition(Vector3 position, Hero hero)
        {
            Tower tower = Spawn();

            tower.InitTower(hero);
            
            
            var towerTransform = tower.transform;
            towerTransform.position = position;
            towerTransform.eulerAngles = Vector3.up * Random.Range(0,360);
        }
        
        public List<NavMeshSurface> GetNavMeshSurfaces()
        {
            List<NavMeshSurface> navMeshes = new List<NavMeshSurface>();
            foreach (var tower in _pool)
            {
                if (tower.gameObject.activeSelf) navMeshes.Add(tower.GetNavMeshSurface());
            }

            return navMeshes;
        }
    }
}