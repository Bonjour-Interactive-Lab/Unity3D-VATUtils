using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace Bonjour.VAT{
    [ExecuteInEditMode]
    [RequireComponent(requiredComponent:typeof(VisualEffect))]
    public abstract class BindVATToVFX : MonoBehaviour
    {
        [Tooltip("Add your VAT Mesh from Houdini")] public Mesh VATMeshReference;
        [Tooltip("Add your VAT Material from Houdini")] public Material VATMaterialReference;

        protected VATData vatdata;

        public virtual void LoadAndApplyParams(){
            VisualEffect vfx = this.GetComponent<VisualEffect>();

            ConstructVATData();
            BindVATMesh(ref vfx);
            BindVATParamsToVFX(ref vfx);
            BindVATTextures(ref vfx);
            BindVATData(ref vfx);

            BindCustomDataToVFX(ref vfx);

            //vfx.Stop();
            vfx.Reinit();
        }

        protected virtual void ConstructVATData(){
            vatdata = new VATData(VATMaterialReference);
        }

        protected virtual void BindVATMesh(ref VisualEffect vfx){
            vfx.SetMesh("VAT Mesh", VATMeshReference);
        }

        protected virtual void BindVATParamsToVFX(ref VisualEffect vfx){
            vfx.SetBool("Auto Playback", vatdata.autoPlayback);

            vfx.SetFloat("Game Time at First Frame", vatdata.gameStartAtFirstFrame);
            vfx.SetFloat("Playback Speed", vatdata.playbackSpeed);
            vfx.SetFloat("Houdini FPS", vatdata.houdiniFPS);
            vfx.SetFloat("Display Frame", vatdata.displayFrame);

            vfx.SetBool("Support Surface Normal Map", vatdata.supportSurfaceNormalMap);
            vfx.SetBool("Two Sided Normals", vatdata.twoSidedNormals);
            vfx.SetBool("Load Color Texture", vatdata.loadColorTexture);
            vfx.SetBool("Position Required Two Textures", vatdata.positionRequiredTwoTextures);
            vfx.SetBool("Load Surface Normal", vatdata.loadSurfaceNormal);
        }

        protected virtual void BindVATTextures(ref VisualEffect vfx){
            SetTexture(ref vfx, "Position Texture", vatdata.positionTexture);
            SetTexture(ref vfx, "Position Texture 2", vatdata.positionTexture2);
            SetTexture(ref vfx, "Color Texture", vatdata.colorTexture);
            SetTexture(ref vfx, "Spare Color Texture", vatdata.spareColorTexture);
        }

        protected virtual void BindVATData(ref VisualEffect vfx){
            //VAT DATA
            vfx.SetFloat("Frame Count", vatdata.frameCount);
            vfx.SetFloat("Bound Max X", vatdata.boundMaxX);
            vfx.SetFloat("Bound Max Y", vatdata.boundMaxY);
            vfx.SetFloat("Bound Max Z", vatdata.boundMaxZ);
            vfx.SetFloat("Bound Min X", vatdata.boundMinX);
            vfx.SetFloat("Bound Min Y", vatdata.boundMinY);
            vfx.SetFloat("Bound Min Z", vatdata.boundMinZ);
        }

        protected virtual void BindCustomDataToVFX(ref VisualEffect vfx){
            //Extend this function to bind your own custom data to the VFX Graph (eg: Albedo, Roughness, Metallic...)
        }

        protected void SetTexture(ref VisualEffect vfx, string ID, Texture texture){
            if(texture != null)
                vfx.SetTexture(ID, texture);
        }
    }
}