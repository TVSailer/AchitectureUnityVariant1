using System;
using System.Collections.Generic;
using Architecture;
using Bank;
using Playerok;

namespace Scenes.Scripts
{
    public class SceneConfigExample : SceneConfig
    {
        public const string SCENE_NAME = "TestScene";
        public override string sceneName => SCENE_NAME;

        public override Dictionary<Type, Repository> CreateAllRepositories()
        {
            var repositoryMap = new Dictionary<Type, Repository>();
            CreateRepository<BankRepository>(repositoryMap);
            return repositoryMap;
        }

        public override Dictionary<Type, Interactor> CreateAllInterators()
        {
            var interactorMap = new Dictionary<Type, Interactor>();
            
            CreateInteractor<BankInteractor>(interactorMap);
            CreateInteractor<PlayerInteractor>(interactorMap);

            return interactorMap;
        }
    }
}