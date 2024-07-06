namespace Architecture
{
    public abstract class Interactor
    {
        public virtual void OnCreate(){ } // Когда все репо и интеракторы созданы;
        public virtual void Initialize() { } // После выполнения OnCreate;
        public virtual void OnStart(){ } // После инициализации;
    }
}
