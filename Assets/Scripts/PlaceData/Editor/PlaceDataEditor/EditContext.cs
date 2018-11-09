using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace PlaceData.Edit
{
    public class EditContext : ScriptableSingleton<EditContext>
    {
        public PlaceData Edit;
        public PlaceDataEditController Controller;
    }
}
