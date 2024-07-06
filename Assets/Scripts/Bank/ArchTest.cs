using Playerok;
using UnityEngine;

namespace Bank
{
    public class ArchTest : MonoBehaviour
    {
        private Player player;
        private void Start()
        {
            Game.Run();
            Game.OnGameInitializedEvent += OnGameInitialized;
        }

        private void OnGameInitialized()
        {
            Game.OnGameInitializedEvent -= OnGameInitialized;
            var playerInteractor = Game.GetInteractor<PlayerInteractor>();
            player = playerInteractor.player;
        }

        private void Update()
        {
            if (!Bank.IsInitialized)
                return;
            
            if (player == null)
                return;
            
            Debug.Log($"Player position{player.transform.position}");
            
            if (Input.GetKeyDown(KeyCode.A))
            {
                Bank.AddCoins(this, 5);
                Debug.Log($"Add coins 5. Coins in Bank: {Bank.Coins}");
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Bank.SpendCoins(this, 6);
                Debug.Log($"Spend coins 6. Coins in Bank: {Bank.Coins}");
            }
        }
    }
}