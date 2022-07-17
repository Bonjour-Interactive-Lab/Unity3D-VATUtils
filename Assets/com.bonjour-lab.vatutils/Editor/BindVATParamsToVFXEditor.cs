using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace Bonjour.VAT{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(Bonjour.VAT.BindVATToVFX), true)]
    public class BindVATParamsToVFXEditor : Editor
    {
        public override void OnInspectorGUI(){
            DrawDefaultInspector();

            EditorGUILayout.Space();

            BindVATToVFX script = (BindVATToVFX)target;
            if(GUILayout.Button("Bind VATParams to VFX")){
                script.LoadAndApplyParams();
            }
        }
    }
}
