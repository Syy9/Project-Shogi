using System.Collections;
using UnityEngine;

public class CoroutineService
{
    private static CoroutineUpdater Updater;
    public void Start(IEnumerator coroutine)
    {
        if(Updater == null)
        {
            var obj = new GameObject("CoroutineUpdater");
            GameObject.DontDestroyOnLoad(obj);
            Updater = obj.AddComponent<CoroutineUpdater>();
        }
        Updater.Push(coroutine);
    }

    public class CoroutineUpdater : MonoBehaviour
    {
        public void Push(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
        }
    }
}
