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

            vfx.SetBool("Interframe Interpolation", vatdata.interframeInterpolations);
            vfx.SetBool("Interpolate Color", vatdata.interpolateColor);
            vfx.SetBool("Interpolate Spare Color", vatdata.interpolateSpareColor);
            vfx.SetBool("Use Compressed Normals", vatdata.useCompressedNormals);
        }

        protected override void BindVATTextures(ref VisualEffect vfx){
            base.BindVATTextures(ref vfx);
            SetTexture(ref vfx, "Rotation Texture", vatdata.rotationTexture);
        }
    }
}