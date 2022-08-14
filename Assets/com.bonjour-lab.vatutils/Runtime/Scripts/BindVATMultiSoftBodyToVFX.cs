using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace Bonjour.VAT{
    [ExecuteInEditMode]
    [RequireComponent(requiredComponent:typeof(VisualEffect))]
    public class BindVATMultiSoftBodyToVFX : BindVATSoftBodyToVFX
    {
        [Space]
        [Tooltip("Add your second VAT Mesh from Houdini")] public Mesh VATMeshReference2;
        [Tooltip("Add your second VAT Material from Houdini")] public Material VATMaterialReference2;
        protected VATData vatdata2;

        protected override void ConstructVATData(){
            base.ConstructVATData();
            vatdata2 = new VATData(VATMaterialReference2);
        }

        protected override void BindVATMesh(ref VisualEffect vfx){
            base.BindVATMesh(ref vfx);
            vfx.SetMesh("VAT Mesh 1", VATMeshReference2);
        }

        protected override void BindVATParamsToVFX(ref VisualEffect vfx){
            base.BindVATParamsToVFX(ref vfx);

            vfx.SetBool("Auto Playback 1", vatdata2.autoPlayback);
            vfx.SetFloat("Game Time at First Frame 1", vatdata2.gameStartAtFirstFrame);
            vfx.SetFloat("Playback Speed 1", vatdata2.playbackSpeed);
            vfx.SetFloat("Houdini FPS 1", vatdata2.houdiniFPS);
            vfx.SetFloat("Display Frame 1", vatdata2.displayFrame);
            vfx.SetBool("Support Surface Normal Map 1", vatdata2.supportSurfaceNormalMap);
            vfx.SetBool("Two Sided Normals 1", vatdata2.twoSidedNormals);
            vfx.SetBool("Load Color Texture 1", vatdata2.loadColorTexture);
            vfx.SetBool("Position Required Two Textures 1", vatdata2.positionRequiredTwoTextures);
            vfx.SetBool("Load Surface Normal 1", vatdata2.loadSurfaceNormal);
            vfx.SetBool("Interframe Interpolation 1", vatdata2.interframeInterpolations);
            vfx.SetBool("Interpolate Color 1", vatdata2.interpolateColor);
            vfx.SetBool("Interpolate Spare Color 1", vatdata2.interpolateSpareColor);
            vfx.SetBool("Use Compressed Normals 1", vatdata2.useCompressedNormals);
        }

        protected override void BindVATTextures(ref VisualEffect vfx){
            base.BindVATTextures(ref vfx);
            SetTexture(ref vfx, "Position Texture 1", vatdata2.positionTexture);
            SetTexture(ref vfx, "Position Texture 3", vatdata2.positionTexture2);
            SetTexture(ref vfx, "Color Texture 1", vatdata2.colorTexture);
            SetTexture(ref vfx, "Spare Color Texture 1", vatdata2.spareColorTexture);
            SetTexture(ref vfx, "Rotation Texture 1", vatdata2.rotationTexture);
        }

        protected override void BindVATData(ref VisualEffect vfx){
            base.BindVATData(ref vfx);
            //VAT DATA
            vfx.SetFloat("Frame Count 1", vatdata2.frameCount);
            vfx.SetFloat("Bound Max X 1", vatdata2.boundMaxX);
            vfx.SetFloat("Bound Max Y 1", vatdata2.boundMaxY);
            vfx.SetFloat("Bound Max Z 1", vatdata2.boundMaxZ);
            vfx.SetFloat("Bound Min X 1", vatdata2.boundMinX);
            vfx.SetFloat("Bound Min Y 1", vatdata2.boundMinY);
            vfx.SetFloat("Bound Min Z 1", vatdata2.boundMinZ);
        }
    }
}