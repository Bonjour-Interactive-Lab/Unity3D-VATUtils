using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace Bonjour.VAT{
    [ExecuteInEditMode]
    [RequireComponent(requiredComponent:typeof(VisualEffect))]
    public abstract class BindVATToVFX : MonoBehaviour
    {
        public Mesh VATMeshReference;
        public Material VATMaterialReference;

        public virtual void LoadAndApplyParams(){
            VisualEffect vfx = this.GetComponent<VisualEffect>();
            
            BindVATMesh(ref vfx);
            BindVATParamsToVFX(ref vfx);
            BindVATTextures(ref vfx);
            BindVATData(ref vfx);

            BindCustomDataToVFX(ref vfx);
        }

        protected virtual void BindVATMesh(ref VisualEffect vfx){
            vfx.SetMesh("VAT Mesh", VATMeshReference);
        }

        protected virtual void BindVATParamsToVFX(ref VisualEffect vfx){
            SetBool(ref vfx, "Auto Playback", VATMaterialReference.GetFloat("_B_autoPlayback"));

            vfx.SetFloat("Game Time at First Frame", VATMaterialReference.GetFloat("_gameTimeAtFirstFrame"));
            vfx.SetFloat("Playback Speed", VATMaterialReference.GetFloat("_playbackSpeed"));
            vfx.SetFloat("Houdini FPS", VATMaterialReference.GetFloat("_houdiniFPS"));
            vfx.SetFloat("Display Frame", VATMaterialReference.GetFloat("_displayFrame"));

            SetBool(ref vfx, "Support Surface Normal Map", VATMaterialReference.GetFloat("_B_surfaceNormals"));
            SetBool(ref vfx, "Two Sided Normals", VATMaterialReference.GetFloat("_B_twoSidedNorms"));
           
            SetBool(ref vfx, "Load Color Texture", VATMaterialReference.GetFloat("_Load_Color_Texture"));
            SetBool(ref vfx, "Position Required Two Textures", VATMaterialReference.GetFloat("_Positions_Require_Two_Textures"));
            SetBool(ref vfx, "Load Surface Normal", VATMaterialReference.GetFloat("_Load_Surface_Normal_Map"));

        }

        protected virtual void BindVATTextures(ref VisualEffect vfx){
            SetTexture(ref vfx, "Position Texture", VATMaterialReference.GetTexture("_posTexture"));
            SetTexture(ref vfx, "Position Texture 2", VATMaterialReference.GetTexture("_posTexture2"));

            SetTexture(ref vfx, "Color Texture", VATMaterialReference.GetTexture("_colTexture"));
            SetTexture(ref vfx, "Spare Color Texture", VATMaterialReference.GetTexture("_spareColTexture"));
        }

        protected virtual void BindVATData(ref VisualEffect vfx){
            //VAT DATA
            vfx.SetFloat("Frame Count", VATMaterialReference.GetFloat("_frameCount"));
            vfx.SetFloat("Bound Max X", VATMaterialReference.GetFloat("_boundMaxX"));
            vfx.SetFloat("Bound Max Y", VATMaterialReference.GetFloat("_boundMaxY"));
            vfx.SetFloat("Bound Max Z", VATMaterialReference.GetFloat("_boundMaxZ"));
            vfx.SetFloat("Bound Min X", VATMaterialReference.GetFloat("_boundMinX"));
            vfx.SetFloat("Bound Min Y", VATMaterialReference.GetFloat("_boundMinY"));
            vfx.SetFloat("Bound Min Z", VATMaterialReference.GetFloat("_boundMinZ"));
        }

        protected virtual void BindCustomDataToVFX(ref VisualEffect vfx){
            //Extend this function to bind your own custom data to the VFX Graph (eg: Albedo, Roughness, Metallic...)
        }

        //utils
        protected virtual void SetBool(ref VisualEffect vfx, string ID, float value){
            vfx.SetBool(ID, value == 1 ? true : false);
        }

        protected virtual void SetTexture(ref VisualEffect vfx, string ID, Texture value){
            if(value == null) return;

            vfx.SetTexture(ID, value);
        }
    }
}