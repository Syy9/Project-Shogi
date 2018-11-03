using MasterData;
using StateMachine;
using Zenject;

public class GameStateManager : StateOwner
{
    [Inject] public CoroutineService CoroutineService { get; private set; }
    [Inject] public IFixedDataManager FixedDataManager { get; private set; }
    [Inject] public IKomaFactory KomaFactory { get; private set; }
    [Inject] public IUIBoard UIBoard { get; private set; }
    [Inject] public PlaceData.Edit.PlaceData PlaceData { get; private set; }

    public override void DispachInitState()
    {
        ChangeState<GameStateinit>();
    }

    protected override void SetupState()
    {
        Register<GameStateinit>();
        Register<GameStateSelect>();
    }


}
