﻿using System;
using System.Collections;
using System.Collections.Generic;
using Architecture;
using Scrips.Coroutines;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.Scripts
{
    public abstract class SceneManagerBase
    {
        public event Action<Scene> OnSceneLoadedEvent; 
        public Scene scene { get; private set; }
        public bool isLoading { get; private set; }
        
        protected Dictionary<string, SceneConfig> sceneConfigMap;
        
        public SceneManagerBase()
        {
            sceneConfigMap = new Dictionary<string, SceneConfig>();
        }
        
        public abstract void InitScenesMap();
        
        public Coroutine LoadCurrentSceneAsync()
        {
            if (isLoading)
                throw new Exception($"Scene is loading now");
            var sceneName = SceneManager.GetActiveScene().name;
            var config = sceneConfigMap[sceneName];
            return Coroutines.StartRoutine(LoadCurrentSceneRoutine(config));
        }

        private IEnumerator LoadCurrentSceneRoutine(SceneConfig sceneConfig)
        {
            isLoading = true;
            
            yield return Coroutines.StartRoutine(InitializeSceneRotine(sceneConfig));
            
            isLoading = false;
            OnSceneLoadedEvent?.Invoke(scene);
        }

        public Coroutine LoadNewSceneAsync(string sceneName)
        {
            if (isLoading)
                throw new Exception($"Scene is loading now");
            var config = sceneConfigMap[sceneName];
            return Coroutines.StartRoutine(LoadNewSceneRoutine(config));
        }

        private IEnumerator LoadNewSceneRoutine(SceneConfig sceneConfig)
        {
            isLoading = false;
            
            yield return Coroutines.StartRoutine(LoadSceneRoutine(sceneConfig));
            yield return Coroutines.StartRoutine(InitializeSceneRotine(sceneConfig));
            
            isLoading = true;
            OnSceneLoadedEvent?.Invoke(scene);
        }

        private IEnumerator LoadSceneRoutine(SceneConfig sceneConfig)
        {
            var async = SceneManager.LoadSceneAsync(sceneConfig.sceneName);
            async.allowSceneActivation = false;

            while (async.progress < 0.9f)
                yield return null;
                
            async.allowSceneActivation = true;
        }

        private IEnumerator InitializeSceneRotine(SceneConfig sceneConfig)
        {
            scene = new Scene(sceneConfig);
            yield return scene.InitializeAsync();
        }

        public T GetRepository<T>() where T : Repository
        {
            return scene.GetRepository<T>();
        }

        public T GetInteractor<T>() where T : Interactor
        {
            return scene.GetInteractor<T>();
        }
    }
}