using System;
using System.Collections.Generic;
using Scenes.Scripts;

namespace Architecture
{
    public class InteractorsBase
    {
        private Dictionary<Type, Interactor> interactorMap;
        private SceneConfig _sceneConfig;

        public InteractorsBase(SceneConfig sceneConfig)
        {
            _sceneConfig = sceneConfig;
        }

        public void CreateAllInteractors()
        {
            interactorMap = _sceneConfig.CreateAllInterators();
        }
        
        public void SendOnCreateAllInteractions()
        {
            var allInteractors = interactorMap.Values;
            foreach (var interactor in allInteractors)
                interactor.OnCreate();
        } 
        
        public void InitializeAllInteractions()
        {
            var allInteractors = interactorMap.Values;
            foreach (var interactor in allInteractors)
                interactor.Initialize();
        }
        
        public void SendOnStartAllInteractions()
        {
            var allInteractors = interactorMap.Values;
            foreach (var interactor in allInteractors)
                interactor.OnStart();
        }

        public T GetInteractor<T>() where T : Interactor
        {
            var type = typeof(T);
            return (T) interactorMap[type];
        }
    }
}