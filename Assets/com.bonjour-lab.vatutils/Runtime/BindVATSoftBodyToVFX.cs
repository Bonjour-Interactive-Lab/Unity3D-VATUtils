using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace Bonjour.VAT{
    [ExecuteInEditMode]
    [RequireComponent(requiredComponent:typeof(VisualEffect))]
    public class BindVATSoftBodyToVFX : BindVATToVFX
    {

        protected override void BindVATParamsToVFX(ref VisualEffect vfx){
            base.BindVATParamsToVFX(ref vfx);

            SetBool(ref vfx, "Interframe Interpolation", VATMaterialReference.GetFloat("_B_interpolate"));
            SetBool(ref vfx, "Interpolate Color", VATMaterialReference.GetFloat("_B_interpolateCol"));
            SetBool(ref vfx, "Interpolate Spare Color", VATMaterialReference.GetFloat("_B_interpolateSpareCol"));
            SetBool(ref vfx, "Use Compressed Normals", VATMaterialReference.GetFloat("_Use_Compressed_Normals"));
        }

        protected override void BindVATTextures(ref VisualEffect vfx){
            base.BindVATTextures(ref vfx);
            SetTexture(ref vfx, "Rotation Texture", VATMaterialReference.GetTexture("_rotTexture"));
        }
    }
}