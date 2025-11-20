using System.Collections.Generic;
using System.Linq;
using Hero.Settings;
using UnityEngine;

namespace Hero
{
    public class HeroesManager : MonoBehaviour
    {
        public static readonly HeroSettings MaxSettings = new()
        {
            Health = 200,
            Attack = 20,
            Defense = 10,
            Speed = 10
        };

        [SerializeField] private HeroController[] _heroPrefabs;
        [SerializeField] private Transform _heroHolder;
        [SerializeField] private PrefsManager _prefsManager;


        private readonly List<HeroController> _heroControllers = new();
        private int _chosenHeroIndex;

        private void Awake()
        {
            foreach (var heroPrefab in _heroPrefabs)
            {
                InstantiateHero(heroPrefab);
            }

            var _chosenHeroIndex = GetChosenHeroIndex();
            ActivateSelectedHero(_heroPrefabs[_chosenHeroIndex]);
            
        }
        
        public IReadOnlyList<HeroController> GetHeroes()
        {
            return _heroControllers;
        }
        
        public void ActivateSelectedHero(HeroController hero)
        {
            var selectedHeroName = hero.HeroSettings.Name;
            _heroControllers.FirstOrDefault(heroController => 
                heroController.HeroSettings.Name == selectedHeroName)?.gameObject.SetActive(true);
        }

        private void InstantiateHero(HeroController heroPrefab)
        {
            var heroController = Instantiate(heroPrefab, _heroHolder);
            heroController.gameObject.SetActive(false);
            _heroControllers.Add(heroController);
        }

        private int GetChosenHeroIndex()
        {
            var heroName = _prefsManager.LoadChosenHero();
            
            for (int i = 0; i < _heroPrefabs.Length; i++)
            {
                if (_heroPrefabs[i].HeroSettings.Name == heroName)
                {
                    return i;
                }
            }

            return 0;
        }

        public void SaveHero()
        {
            var hero = FindObjectOfType<HeroController>().gameObject;

            hero.transform.SetParent(null); 
            DontDestroyOnLoad(hero);
        }
    }
}