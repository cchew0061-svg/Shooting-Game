public abstract class BaseState
{
    public StateMachine stateMachine;

    public Enemy enemy;

    //overridden functions
    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();
}
