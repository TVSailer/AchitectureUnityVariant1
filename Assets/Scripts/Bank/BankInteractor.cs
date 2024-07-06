using Architecture;

namespace Bank
{
    public class BankInteractor : Interactor
    {
        private BankRepository _bankRepository;

        public int coins => _bankRepository.coins;

        public override void OnCreate()
        {
            _bankRepository = Game.GetRepository<BankRepository>();
        }
        
        public override void Initialize()
        {
            Bank.Initialize(this);
        }

        public bool IsEnougthCoins(int value) => coins >= value;

        public void AddCoins(object sender, int value)
        {
            _bankRepository.coins += value;
            _bankRepository.Save();
        }

        public void SpendCoins(object sender, int value)
        {
            _bankRepository.coins -= value;
            _bankRepository.Save();
        }
    }
}