using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure
{
    public class HeroSpawner : MonoBehaviour
    {
        [SerializeField] private Hero _heroPrefab;
        

        public Hero SpawnHero()
        {
            Hero hero = GameObject.Instantiate(_heroPrefab);
            return hero;
        }
    }
}