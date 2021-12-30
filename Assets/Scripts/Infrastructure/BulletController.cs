using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Infrastructure
{
    public class BulletController : PoolController<Bullet>
    {
        [SerializeField] private List<BulletSettings> _settings;
        private EnemyController _enemyController;
        
        public void SetEnemyController(EnemyController enemyController)
        {
            _enemyController = enemyController;
        }

        public void SpawnBullet(Vector3 position, Vector3 direction)
        {
            Bullet bullet = Spawn();
            bullet.InitBullet(_settings[Random.Range(0,_settings.Count)], _enemyController,position, direction);
        }
    }
}