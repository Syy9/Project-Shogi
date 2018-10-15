using MasterData;
using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller<GameSceneInstaller>
{
    [SerializeField] UIBoardGridManager GridManager;
    [SerializeField] UIBoard UIBoard;
    public override void InstallBindings()
    {
        Container.Bind<IFixedDataManager>().To<FixedDataManager>().AsSingle();
        Container.Bind<UIBoard>().FromInstance(UIBoard);
        Container.Bind<UIBoardGridManager>().FromInstance(GridManager);
        Container.Bind<KomaIconLoader>().ToSelf().AsSingle();
        Container.BindFactoryCustomInterface<Koma.InitData, Koma, Koma.Factory, IKomaFactory>().FromFactory<KomaFactory>();

        //State
        Container.Bind<GameStateManager>().ToSelf().AsSingle();
    }
}
