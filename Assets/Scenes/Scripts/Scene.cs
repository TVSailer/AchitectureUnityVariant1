using System.Collections;
using Architecture;
using UnityEngine;
using Scrips.Coroutines;

namespace Scenes.Scripts
{
    public class Scene
    {
        private InteractorsBase _interactorsBase;
        private RepositorysBase _repositorysBase;
        private SceneConfig _sceneConfig;

        public Scene(SceneConfig config)
        {
            _sceneConfig = config;
            _interactorsBase = new InteractorsBase(config);
            _repositorysBase = new RepositorysBase(config);
        }

        public Coroutine InitializeAsync()
        {
            return Coroutines.StartRoutine(InitializeRoutine());
        }
        
        private IEnumerator InitializeRoutine()
        {
            _interactorsBase.CreateAllInteractors();
            _repositorysBase.CreateAllRepositorys();
            yield return null;

            _interactorsBase.SendOnCreateAllInteractions();
            _repositorysBase.SendOnCreateAllRepository();
            yield return null;
            
            _interactorsBase.InitializeAllInteractions();
            _repositorysBase.InitializeAllRepository();
            yield return null;
            
            _interactorsBase.SendOnStartAllInteractions();
            _repositorysBase.SendOnStartAllRepository();
            yield return null;
        }


        public T GetRepository<T>() where T : Repository
        {
            return _repositorysBase.GetRepository<T>();
        }
        
        public T GetInteractor<T>() where T : Interactor
        {
            return _interactorsBase.GetInteractor<T>();
        }
    }
}