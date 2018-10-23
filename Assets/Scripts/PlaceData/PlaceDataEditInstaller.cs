using MasterData;
using UnityEngine;
using Zenject;
namespace PlaceData.Edit
{
    public class PlaceDataEditInstaller : MonoInstaller<PlaceDataEditInstaller>
    {
        [SerializeField] UIBoard UIBoardPrefab;
        [SerializeField] Transform UIBoardParent;
        public override void InstallBindings()
        {
            //Framework
            Container.Bind<CoroutineService>().ToSelf().AsSingle();

            //System
            Container.Bind<IFixedDataManager>().To<FixedDataManager>().AsSingle();

            //Game
            Container.Bind<IUIBoard>().FromComponentInNewPrefab(UIBoardPrefab).UnderTransform(UIBoardParent).AsSingle().NonLazy();
            Container.Bind<KomaIconLoader>().ToSelf().AsSingle();
            Container.BindFactoryCustomInterface<Koma.InitData, Koma, Koma.Factory, IKomaFactory>().FromFactory<KomaFactory>();

            //State
            Container.Bind<GameStateManager>().ToSelf().AsSingle();
        }
    }

}
