using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[DisallowMultipleComponent]
public class Koma : MonoBehaviour {
    [Inject] UIBoardGridManager UIBoardGridManager;
    [Inject] KomaIconLoader IconLoader;
    [SerializeField] Image image;
    KomaType Type;

    IEnumerator Start()
    {
        Move(0, 0);
        for (int x = 0; x < 9; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                yield return new WaitForSeconds(1);
                Move(x, y);
            }
        }
    }

    public void Init(Data data)
    {
        Type = data.Type;
        image.sprite = IconLoader.Load(Type);
        Move(data.InitPosition.x, data.InitPosition.y);
    }

    public void Move(int x, int y)
    {
        var position = UIBoardGridManager.GetPosition(x, y);
        transform.position = position;
    }

    public class Data
    {
        public KomaType Type;
        public Vector2Int InitPosition;
    }

    public enum KomaType
    {
        None,
        Type001, //王
        Type002, //飛車
        Type003, //角
        Type004,
        Type005,
    }

    public class Factory : PlaceholderFactory<Koma.Data, Koma> , IKomaFactory
    {
        
    }
}
