using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Infrastructure
{
    public class GameController : MonoBehaviour
    {
        private HeroSpawner _heroSpawner;
        private EnemyController _enemyController;
        private LevelController _levelController;
        private PlayerProgression _playerProgression;
        private BulletController _bulletController;
        private TowerController _towerController;
        private UIController _uiController;

        private Hero _currentHero;
        private CameraFollower _cameraFollower;
        
        private void Awake()
        {
            GetReferences();
            
            _bulletController.SetEnemyController(_enemyController);

            _cameraFollower = Camera.main.GetComponent<CameraFollower>();

            StartGame();
        }

        public void StartGame()
        {
            _levelController.SetLevel(_playerProgression.LoadIndex());
            
            _uiController.Init(RestartLevel);
            
            Level currentLevel = _levelController.GetCurrentLevel();
            var pos = currentLevel.GetHeroSpawnPositions()[Random.Range(0, currentLevel.GetHeroSpawnPositions().Count)]
                .position;
            
            if (_currentHero == null)
            {
                _currentHero = _heroSpawner.SpawnHero();
            }
            _currentHero.InitHero(_bulletController, pos);
            
            currentLevel.InitLevel(_towerController,_currentHero);

            _enemyController.SpawnEnemiesAtLevelStart(currentLevel.GetEnemyCount(),currentLevel.GetEnemySpawnPositions());
            _cameraFollower.FollowTarget(_currentHero.transform);
        }

        private void RestartLevel()
        {
            _bulletController.ClearAll();
            _towerController.ClearAll();
            _enemyController.ClearAll();
            
            
            StartGame();
        }

        public void LoadNextLevel()
        {
            _playerProgression.SetNextLevel();
            StartGame();
        }
        
        private void GetReferences()
        {
            _enemyController = GetComponent<EnemyController>();
            _heroSpawner = GetComponent<HeroSpawner>();
            _levelController = GetComponent<LevelController>();
            _bulletController = GetComponent<BulletController>();
            _towerController = GetComponent<TowerController>();
            _uiController = GetComponent<UIController>();
            
            _playerProgression = new PlayerProgression();
        }
    }
}