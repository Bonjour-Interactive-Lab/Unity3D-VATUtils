using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace Bonjour.VAT{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(Bonjour.VAT.BindVATParamsToVFXInGame))]
    public class BindVATParamsToVFXInGameEditor : Editor
    {
        public override void OnInspectorGUI(){
            DrawDefaultInspector();

            EditorGUILayout.Space();

            BindVATParamsToVFXInGame script = (BindVATParamsToVFXInGame)target;
            if(GUILayout.Button("Bind VATParams to VFX")){
                script.LoadAndApplyParams();
            }
        }
    }
}
