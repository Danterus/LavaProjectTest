using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private List<Level> _levels;
        private int _currentLevelIndex;
        private Level _currentLevel;
        
        public void SetLevel(int index)
        {
            _currentLevelIndex = index >= _levels.Count ? index % _levels.Count:index;
            SpawnCurrentLevel();
        }

        public Level GetCurrentLevel() => _currentLevel;

        private void SpawnCurrentLevel()
        {
            if (_currentLevel != null)
            {
                Destroy(_currentLevel.gameObject);
            }

            _currentLevel = Instantiate(_levels[_currentLevelIndex]);
            
        }
    }
}