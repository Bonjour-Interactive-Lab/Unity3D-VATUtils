using UnityEngine;
using UnityEngine.VFX;

namespace Bonjour.VAT{
    [CreateAssetMenu(fileName = "VATFlowerPistilDescriptor", menuName = "ScriptableObject/VATFlowerPistilDescriptor", order = 1)]
    public class VATFlowerPistilDescriptor : VATDescriptor
    {
        [Header("VAT Pistil Params")]
        public string pistilName;

        //Pistil
        [HideInInspector] public VATDscp pistilvatdscp;
        [Range(0f, 1f)] public float pistilglobalScale = .125f;

        
        public Gradient PistilColorRampIn;
        public Gradient PistilColorRampOut;
        public Texture2D PistilAlbedoRamp;
        public Texture2D PistilNormalMap;
        [Range(0f, 1f)] public float PistilNormalStrength = .5f;
        public Texture2D PistilPBRMask;

        protected override void LoadVATParams(){
            base.LoadVATParams();
            pistilvatdscp = GetVATDscp(folderPath, pistilName);
        }

        protected override void BindVATDscpToVFX(ref VisualEffect vfx){
            base.BindVATDscpToVFX(ref vfx);
   
            vfx.SetMesh("VAT Mesh 1"            , pistilvatdscp.mesh);
            vfx.SetTexture("Position Map 1"     , pistilvatdscp.position);
            vfx.SetTexture("Normal Map 2"       , pistilvatdscp.normal);
            vfx.SetTexture("Color Map 1"        , pistilvatdscp.color);
            vfx.SetFloat("Number of Frames 1"   , pistilvatdscp.vatParams._numOfFrames);
            vfx.SetFloat("Speed 1"              , pistilvatdscp.vatParams._speed);
            vfx.SetFloat("Global Scale 1"       , pistilglobalScale);
            vfx.SetFloat("Pos Min 1"            , pistilvatdscp.vatParams._posMin);
            vfx.SetFloat("Pos Max 1"            , pistilvatdscp.vatParams._posMax);
            vfx.SetFloat("Padded X 1"           , pistilvatdscp.vatParams._paddedX);
            vfx.SetFloat("Padded Y 1"           , pistilvatdscp.vatParams._paddedY);
            vfx.SetBool("Pack Normal 1"         , (pistilvatdscp.vatParams._packNorm == 1) ? true : false);
        }

         protected override void SetInstanceMaterials(ref VisualEffect vfx){
            base.SetInstanceMaterials(ref vfx);
            vfx.SetTexture("Albedo 1", PistilAlbedoRamp);
            vfx.SetTexture("Normal Map 3", PistilNormalMap);
            vfx.SetFloat("Normal Scale 1", PistilNormalStrength);
            vfx.SetTexture("PBR Mask 1", PistilPBRMask);
         }

    }
}