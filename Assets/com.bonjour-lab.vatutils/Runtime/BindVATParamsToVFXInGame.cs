using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace Bonjour.VAT{
    [ExecuteInEditMode]
    [RequireComponent(requiredComponent:typeof(VisualEffect))]
    public class BindVATParamsToVFXInGame : MonoBehaviour
    {
        public VATDescriptor vatDescriptor;

        public void LoadAndApplyParams(){
            VisualEffect vfx = this.GetComponent<VisualEffect>();
            vatDescriptor.LoadAndSetToVFX(ref vfx);
        }
    }
}
