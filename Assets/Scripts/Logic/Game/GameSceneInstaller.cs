using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller<GameSceneInstaller>
{
    [SerializeField] UIBoardGridManager GridManager;
    public override void InstallBindings()
    {
        Container.Bind<UIBoardGridManager>().FromInstance(GridManager);
    }
}
