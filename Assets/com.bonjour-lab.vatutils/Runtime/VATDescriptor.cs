using UnityEngine;
using UnityEngine.VFX;

namespace Bonjour.VAT{
    [CreateAssetMenu(fileName = "VATDescriptor", menuName = "ScriptableObject/VATDescriptor", order = 1)]
    public class VATDescriptor : ScriptableObject
    {

        [Header("VAT Params")]
        public string folderPath;
        public string VATName;

        [Header("VFX Params")]
        public GameObject vfxPrefabModel;
        [HideInInspector] public GameObject vfxPrefab;
        [HideInInspector] public VisualEffect vfx;
        public int numberOfInstance = 100;
        [Range(0f, 1f)] public float globalScale = .125f;


        [Header("VFX Materials Params")]
        //put materials here
        public Texture2D AlbedoRamp;
        public Texture2D NormalMap;
        [Range(0f, 1f)] public float normalStrength = .5f;
        public Texture2D PBRMask;

        public struct VATDscp{
            public VATParams vatParams;
            public string name;
            public Mesh mesh;
            public Texture2D position;
            public Texture2D normal;
            public Texture2D color;
        }
        [HideInInspector] public VATDscp vatdscp;

        public void InitVFX(Transform parent){
            LoadVATParams();
            InstantiateAndBindVFXOnScene(parent);
            BindVATDscpToVFX(ref vfx);
            SetInstanceControlParams(ref vfx);
            SetInstanceMaterials(ref vfx);
            Debug.Log($"VAT Params loaded from Resources folder for {vatdscp.name}");
        }

        public void LoadAndSetToVFX(ref VisualEffect vfx){
            LoadVATParams();
            BindVATDscpToVFX(ref vfx);
            SetInstanceControlParams(ref vfx);
            SetInstanceMaterials(ref vfx);
            Debug.Log($"VAT Params loaded from Resources folder for {vatdscp.name}");
        }

        protected virtual void LoadVATParams(){
            vatdscp      = GetVATDscp(folderPath, VATName);
        }

        protected virtual void InstantiateAndBindVFXOnScene(Transform parent){
            vfxPrefab                  = Instantiate(vfxPrefabModel, parent);
            vfxPrefab.transform.parent = parent;
            vfxPrefab.transform.name   = VATName;
            vfx                        = vfxPrefab.GetComponent<VisualEffect>();
        }

        protected virtual void BindVATDscpToVFX(ref VisualEffect vfx){
            vfx.SetMesh("VAT Mesh"          , vatdscp.mesh);
            vfx.SetTexture("Position Map"   , vatdscp.position);
            vfx.SetTexture("Normal Map"     , vatdscp.normal);
            vfx.SetTexture("Color Map"      , vatdscp.color);
            vfx.SetFloat("Number of Frames" , vatdscp.vatParams._numOfFrames);
            vfx.SetFloat("Speed"            , vatdscp.vatParams._speed);
            vfx.SetFloat("Global Scale"     , globalScale);
            vfx.SetFloat("Pos Min"          , vatdscp.vatParams._posMin);
            vfx.SetFloat("Pos Max"          , vatdscp.vatParams._posMax);
            vfx.SetFloat("Padded X"         , vatdscp.vatParams._paddedX);
            vfx.SetFloat("Padded Y"         , vatdscp.vatParams._paddedY);
            vfx.SetBool("Pack Normal"       , (vatdscp.vatParams._packNorm == 1) ? true : false);
        }

        protected virtual void SetInstanceControlParams(ref VisualEffect vfx){
            vfx.SetInt("Number of Instances", numberOfInstance);
        }

        protected virtual void SetInstanceMaterials(ref VisualEffect vfx){
            vfx.SetTexture("Albedo"         , AlbedoRamp);
            vfx.SetTexture("Normal Map 1"   , NormalMap);
            vfx.SetFloat("Normal Scale"     , normalStrength);
            vfx.SetTexture("PBR Mask"       , PBRMask);
        }

        protected virtual VATDscp GetVATDscp(string folderPath, string assetName){
            VATDscp         dscp           = new VATDscp();
            string          filepath       = $"{folderPath}/materials/{assetName}_data.json";
            VATGlobalParams vatGP          = VATParamsParser.ParseVATParamsFrom(filepath);
                            dscp.vatParams = vatGP.vatparams;
                            dscp.name      = vatGP.name;
                            dscp.mesh      = Resources.Load<Mesh>($"{folderPath}/meshes/{assetName}_mesh");
                            dscp.position  = Resources.Load<Texture2D>($"{folderPath}/textures/{assetName}_pos");
                            dscp.normal    = Resources.Load<Texture2D>($"{folderPath}/textures/{assetName}_norm");
                            dscp.color     = Resources.Load<Texture2D>($"{folderPath}/textures/{assetName}_col");
            return dscp;
        }
    }
}