using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace Bonjour.VAT{
    [ExecuteInEditMode]
    [RequireComponent(requiredComponent:typeof(VisualEffect))]
    public class BindVATDynamicRemeshingToVFX : BindVATToVFX
    {

        protected override void BindVATParamsToVFX(ref VisualEffect vfx){
            base.BindVATParamsToVFX(ref vfx);

            vfx.SetBool("Surface UVs from Color RG", vatdata.surfaceUVsFromColorRG);
            vfx.SetBool("Use Compressed Normals", vatdata.useCompressedNormals);
        }

        protected override void BindVATTextures(ref VisualEffect vfx){
            base.BindVATTextures(ref vfx);
            SetTexture(ref vfx, "Rotation Texture", vatdata.rotationTexture);
            SetTexture(ref vfx, "Lookup Table", vatdata.lookupTable);
        }
    }
}