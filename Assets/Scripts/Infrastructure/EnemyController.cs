using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure
{
    public class EnemyController : PoolController<Enemy>
    {
        public void SpawnEnemiesAtLevelStart(int number, List<Transform> spawnPositions)
        {
            for (int i = 0; i < number; i++)
            {
                SpawnEnemy(spawnPositions[Random.Range(0, spawnPositions.Count)].position + Vector3.up);
            }
            
        }

        public Enemy GetEnemyByRagdollPartCollider(Collider col)
        {
            return _pool.Find(x => x.gameObject.activeSelf &&
                                   x.FindRagdollPart(col));
        }
        
        private void SpawnEnemy(Vector3 spawnPosition)
        {
            Enemy enemy = Spawn();
            enemy.Init(spawnPosition);
        }
        
        
    }
}