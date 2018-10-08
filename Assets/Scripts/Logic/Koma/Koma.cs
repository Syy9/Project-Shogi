using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[DisallowMultipleComponent]
public class Koma : MonoBehaviour {
    [Inject] UIBoardGridManager UIBoardGridManager;

    IEnumerator Start()
    {
        Debug.Log("hogehogeStart");
        for (int x = 0; x < 9; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                yield return new WaitForSeconds(1);
                Move(x, y);
                Debug.Log("x " + x  +"y" + y);
            }
        }
    }
    public void Move(int x, int y)
    {
        var position = UIBoardGridManager.GetPosition(x, y);
        transform.position = position;
    }
}
