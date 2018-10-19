using System.Linq;
using System.Collections;
using System.Collections.Generic;
using MasterData;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;


public class PlaceDataEditor : EditorWindow {
    [MenuItem("将棋/PlaceDataEditor")]
    public static void Open()
    {
        GetWindow<PlaceDataEditor>();
        if (!IsEditScene())
        {
            if(EditorUtility.DisplayDialog("PlaceDataEdit", "編集シーンを開きますか？", "はい", "いいえ"))
            {
                EditorSceneManager.OpenScene(EditrScenePath);
            }
        }
    }

    const string EditrScenePath = "Assets/Scripts/PlaceData/Editor/PlaceDataEditScene.unity";
    const string EditSceneName = "PlaceDataEditScene";

    PlaceData edit;
    PlaceDataEditController controller;
    List<Koma> komaList = new List<Koma>();
    KomaType komaType;

    void OnGUI()
    {
        if(!IsEditScene())
        {
            EditorGUILayout.LabelField("編集シーンでのみ操作可能です");
            if(GUILayout.Button("編集シーンを開く"))
            {
                EditorSceneManager.OpenScene(EditrScenePath);
            }
            return;
        }

        if(!EditorApplication.isPlaying)
        {
            EditorGUILayout.LabelField("シーンを再生してください");
            if(GUILayout.Button("シーン再生する"))
            {
                EditorApplication.isPlaying = true;
            }
            return;
        }

        if (controller == null && EditorApplication.isPlaying)
        {
            Init();
        }

        using(var check = new EditorGUI.ChangeCheckScope())
        {
            edit = (PlaceData)EditorGUILayout.ObjectField("PlaceData", edit, typeof(PlaceData), false);
            if(check.changed)
            {
                if(edit != null)
                {
                    Place(edit);
                }
            }
        }

        komaType = (KomaType) EditorGUILayout.EnumPopup("駒タイプ", komaType);

        if(GUILayout.Button("セーブする"))
        {
            Save(komaList, edit);
        }
    }

    void Reset()
    {
        foreach (var koma in komaList)
        {
            GameObject.Destroy(koma);
        }
        komaList.Clear();
    }

    void Place(PlaceData data)
    {
        foreach (var place in data.placeList)
        {
            var initData = new Koma.InitData();
            initData.Type = place.KomaType;
            initData.Lv = place.Lv;
            initData.InitPosition = place.Position;
            var newKoma = controller.KomaFactory.Create(initData);
            komaList.Add(newKoma);
        }
    }

    void Save(List<Koma> komaList, PlaceData data)
    {
        Undo.RegisterUndo(data, "PlaceData - Save");
        data.placeList.Clear();
        foreach (var koma in komaList)
        {
            var place = new Place();
            place.KomaType = koma.Type;
            place.Lv = koma.Lv;
            place.Position = koma.Position;
            data.placeList.Add(place);
        }
    }

    void Init()
    {
        controller = GameObject.FindObjectOfType<PlaceDataEditController>();
        if(controller == null)
        {
            return;
        }

        controller.UIBoard.OnSelect = OnSelect;
        komaList.Clear();
    }

    void OnSelect(Vector2Int position)
    {
        var koma = komaList.FirstOrDefault(k => k.Position == position);
        var initData = new Koma.InitData();
        if(koma == null)
        {
            initData.Type = komaType;
            initData.Lv = 1;
            initData.InitPosition = position;
            var newKoma = controller.KomaFactory.Create(initData);
            komaList.Add(newKoma);
        } else {
            if(controller.FixedDataManager.KomaDataProvider.GetMaxLv(koma.Type) == koma.Lv)
            {
                komaList.Remove(koma);
                GameObject.Destroy(koma.gameObject);
            } else {
                initData.Type = koma.Type;
                initData.Lv = koma.Lv + 1;
                initData.InitPosition = koma.Position;
                koma.Init(initData);
            }
        }
        
    }

    static bool IsEditScene()
    {
        return EditorSceneManager.GetActiveScene().name == EditSceneName;
    }
}
