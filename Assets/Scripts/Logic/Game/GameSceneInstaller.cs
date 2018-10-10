using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller<GameSceneInstaller>
{
    [SerializeField] UIBoardGridManager GridManager;
    [SerializeField] UIBoard UIBoard;
    public override void InstallBindings()
    {
        Container.Bind<UIBoard>().FromInstance(UIBoard);
        Container.Bind<UIBoardGridManager>().FromInstance(GridManager);
        Container.Bind<KomaIconLoader>().ToSelf().AsSingle();
        Container.BindFactoryCustomInterface<Koma.Data, Koma, Koma.Factory, IKomaFactory>().FromFactory<KomaFactory>();
    }
}
