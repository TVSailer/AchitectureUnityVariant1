using System;
using System.Collections;
using Architecture;
using Scenes.Scripts;
using Scrips.Coroutines;

namespace Bank
{
    public  static class Game
    {
        public static event Action OnGameInitializedEvent; 
        public static SceneManagerBase sceneManager { get; private set; }

        public static void Run()
        {
            sceneManager = new SceneManagerExample();
            Coroutines.StartRoutine(InitializeGameRoutine());
        }

        private static IEnumerator InitializeGameRoutine()
        {
            sceneManager.InitScenesMap();
            yield return sceneManager.LoadCurrentSceneAsync();
            OnGameInitializedEvent?.Invoke();
        }

        public static T GetRepository<T>() where T : Repository
        {
            return sceneManager.GetRepository<T>();
        }
        public static T GetInteractor<T>() where T : Interactor
        {
            return sceneManager.GetInteractor<T>();
        }
    }
}