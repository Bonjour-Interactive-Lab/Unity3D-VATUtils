using UnityEngine;

namespace Bonjour{
    public static class MaterialGetter{
        public static float GetFloatValue(Material mat, string ID){
            if(mat.HasFloat(ID))
                return mat.GetFloat(ID);
            else
                return 0f;
        }

        public static int GetIntValue(Material mat, string ID){
            if(mat.HasInt(ID))
                return mat.GetInt(ID);
            else
                return 0;
        }

        public static bool GetBoolValue(Material mat, string ID){
            if(mat.HasInt(ID))
                return mat.GetFloat(ID) == 1 ? true : false;
            else
                return false;
        }

        public static Texture GetTexture(Material mat, string ID){
            if(mat.HasTexture(ID))
                return mat.GetTexture(ID);
            else
                return null;
        }
    }
}