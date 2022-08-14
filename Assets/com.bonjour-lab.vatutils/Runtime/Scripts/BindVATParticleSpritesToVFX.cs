using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace Bonjour.VAT{
    [ExecuteInEditMode]
    [RequireComponent(requiredComponent:typeof(VisualEffect))]
    public class BindVATParticleSpritesToVFX : BindVATToVFX
    {

        protected override void BindVATParamsToVFX(ref VisualEffect vfx){
            base.BindVATParamsToVFX(ref vfx);

            vfx.SetBool("Interframe Interpolation", vatdata.interframeInterpolations);
            vfx.SetBool("Interpolate Color", vatdata.interpolateColor);
            vfx.SetBool("Interpolate Spare Color", vatdata.interpolateSpareColor);

            vfx.SetBool("Particles Can Spin", vatdata.particleCanSpin);

            vfx.SetBool("Particle Scales Are in Position Alpha", vatdata.particleScalesAreInPositionAlpha);
            vfx.SetFloat("Global Particle Scale Multiplier", vatdata.globalParticleScaleMultiplier);
            vfx.SetFloat("Particle Width Base Scale", vatdata.particleWidthBaseScale);
            vfx.SetFloat("Particle Height Base Scale", vatdata.particleHeigtBaseScale);
            vfx.SetFloat("Particle Texture U Scale", vatdata.particlesTextureUScale);
            vfx.SetFloat("Particle Texture V Scale", vatdata.particlesTextureVScale);
            vfx.SetBool("Compute Spin from Heading Vector", vatdata.computeSpinFromHeadingVector);
            vfx.SetFloat("Scale by Velocity Amount", vatdata.scaleByVelocityAmount);
            vfx.SetFloat("Particle Spin Phase", vatdata.particleSpinPhase);
            vfx.SetBool("Hide Particles Overlapping Object Origin", vatdata.hideParticlesOverlappingObjectOrigin);
            vfx.SetFloat("Origin Effective Radius", vatdata.originEffectiveRadius);
        }

        protected override void BindVATTextures(ref VisualEffect vfx){
            base.BindVATTextures(ref vfx);
        }
    }
}