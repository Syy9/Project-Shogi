using MasterData;
using StateMachine;
using Zenject;

public class GameStateManager : StateOwner
{
    [Inject] public CoroutineService CoroutineService { get; private set; }
    [Inject] public IFixedDataManager FixedDataManager { get; private set; }
    [Inject] public IKomaFactory KomaFactory { get; private set; }
    [Inject] public UIBoard UIBoard { get; private set; }
    public override void Start()
    {
        ChangeState(typeof(GameStateSelect));
    }

    protected override void SetupState()
    {
        Register<GameStateSelect>();
    }


}
