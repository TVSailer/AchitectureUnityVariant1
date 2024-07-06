using System;
using System.Collections.Generic;
using Scenes.Scripts;

namespace Architecture
{
    public class RepositorysBase
    {
        private Dictionary<Type, Repository> repositorysMap;
        private SceneConfig _sceneConfig;

        public RepositorysBase(SceneConfig sceneConfig)
        {
            _sceneConfig = sceneConfig;
        }

        public void CreateAllRepositorys()
        {
            repositorysMap = _sceneConfig.CreateAllRepositories();
        }
        
        public void SendOnCreateAllRepository()
        {
            var allRepository = repositorysMap.Values;
            foreach (var repository in allRepository)
                repository.OnCreate();
        } 
        
        public void InitializeAllRepository()
        {
            var allRepository = repositorysMap.Values;
            foreach (var repository in allRepository)
                repository.Initialize();
        }
        
        public void SendOnStartAllRepository()
        {
            var allRepository = repositorysMap.Values;
            foreach (var repository in allRepository)
                repository.OnStart();
        }

        public T GetRepository<T>() where T : Repository
        {
            var type = typeof(T);
            return (T) repositorysMap[type]; 
        }
    }
}