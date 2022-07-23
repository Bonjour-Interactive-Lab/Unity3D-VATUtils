using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace Bonjour.VAT{
    [ExecuteInEditMode]
    [RequireComponent(requiredComponent:typeof(VisualEffect))]
    public class BindVATRigidBodyToVFX : BindVATToVFX
    {

        protected override void BindVATParamsToVFX(ref VisualEffect vfx){
            base.BindVATParamsToVFX(ref vfx);

            vfx.SetBool("Interframe Interpolation", vatdata.interframeInterpolations);
            vfx.SetBool("Interpolate Color", vatdata.interpolateColor);
            vfx.SetBool("Interpolate Spare Color", vatdata.interpolateSpareColor);

            vfx.SetBool("Smoothly Interpolated Trajectories", vatdata.smoothlyInterpolatedTrajectory);
            vfx.SetBool("Piece Scales Are in Position Alpha", vatdata.pieceScaleAreInPositionAlpha);
            vfx.SetFloat("Global Piece Scale Multiplier", vatdata.globalPieceScaleMultiplier);
            vfx.SetBool("Stretch by Velocity", vatdata.stretchByVelocity);
            vfx.SetFloat("Stretch by Velocity Amount", vatdata.stretchByVelocityAmount);
            vfx.SetBool("Animate First Frame", vatdata.animateFirstFrame);
        }

        protected override void BindVATTextures(ref VisualEffect vfx){
            base.BindVATTextures(ref vfx);
            SetTexture(ref vfx, "Rotation Texture", vatdata.rotationTexture);
        }
    }
}