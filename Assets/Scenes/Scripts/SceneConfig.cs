﻿using System;
using System.Collections.Generic;
using Architecture;

namespace Scenes.Scripts
{
    public abstract class SceneConfig
    {
        public abstract string sceneName{ get;}
        public abstract Dictionary<Type, Repository> CreateAllRepositories();
        public abstract Dictionary<Type, Interactor> CreateAllInterators();

        public void CreateRepository<T>(Dictionary<Type, Repository> repositoriesMap) where T : Repository, new()
        {
            var repository = new T();
            var type = typeof(T);
            repositoriesMap[type] = repository;
        }
        
        public void CreateInteractor<T>(Dictionary<Type, Interactor> interactorsMap) where T : Interactor, new()
        {
            var interactor = new T();
            var type = typeof(T);
            interactorsMap[type] = interactor;
        }
    }
}