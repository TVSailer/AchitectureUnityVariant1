using System;

namespace Bank
{
    public static class Bank
    {
        private static BankInteractor _bankInteractor;
        public static event Action OnBankInitializedEvent;
        public static bool IsInitialized { get; private set; }

        public static int Coins { 
            get {
                CheckClass();
                return _bankInteractor.coins;
            }
        }


        public static void Initialize(BankInteractor bankInteractor)
        {
            _bankInteractor = bankInteractor;
            IsInitialized = true;
            
            OnBankInitializedEvent?.Invoke();
        }

        public static bool IsEnougthCoins(int value)
        {
            CheckClass();
            return _bankInteractor.IsEnougthCoins(value);
        }

        public static void AddCoins(object sender, int value)
        {
            CheckClass();
            _bankInteractor.AddCoins(sender, value);
        }

        public static void SpendCoins(object sender, int value)
        {
            CheckClass();
            _bankInteractor.SpendCoins(sender, value);
        }

        private static void CheckClass()
        {
            if (!IsInitialized)
                throw new Exception("Bank is not initialized");
        }
    }
}