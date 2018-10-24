using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace PlaceData.Edit
{
    public class PlaceDataEditorWindow : EditorWindow
    {
        [MenuItem("将棋/PlaceDataEditor")]
        public static void Open()
        {
            GetWindow<PlaceDataEditorWindow>();
            PlaceDataEditor.OpenEditSceneIfNeed();
        }

        static PlaceDataEditor editor = new PlaceDataEditor();

        void OnEnable()
        {
            editor.DispachInitState();
        }

        void OnGUI()
        {
            editor.OnGUI();
        }
    }


}
