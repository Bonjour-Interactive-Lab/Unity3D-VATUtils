
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Bonjour.VAT{
    public static class VATParamsParser{
        public enum SOURCETYPE{
            STREAMING_ASSET,
            RESOURCES_FOLDER,
            FROM_ASSETS_ROOT,
            CUSTOM
        }

        public static VATGlobalParams ParseVATParamsFrom(string filepath, SOURCETYPE sourcePathType = SOURCETYPE.RESOURCES_FOLDER){
            string sourcePath = GetSourcePath(sourcePathType, filepath);
             using (StreamReader stream = new StreamReader(sourcePath)) 
            {
                string    json            = stream.ReadToEnd();
                JObject   jObject         = JObject.Parse(json);
                string    vatName         = jObject.Properties().Select(x => x.Name).ToList()[0];
                string    vatParamsString = jObject[vatName][0].ToString();
                VATParams vatparams       = JsonConvert.DeserializeObject<VATParams>(vatParamsString);
                VATGlobalParams vatglobalparams = new VATGlobalParams();
                vatglobalparams.vatparams = vatparams;
                vatglobalparams.name = vatName;

                return vatglobalparams;
            }
        }

        private static string GetSourcePath(SOURCETYPE sourcePathType, string pathToFile){
            switch(sourcePathType){
                default:
                case SOURCETYPE.STREAMING_ASSET : return Path.Combine(Application.streamingAssetsPath, pathToFile);
                case SOURCETYPE.RESOURCES_FOLDER : return Path.Combine(Application.dataPath + "/Resources", pathToFile);
                case SOURCETYPE.FROM_ASSETS_ROOT : return Path.Combine(Application.dataPath, pathToFile);
                case SOURCETYPE.CUSTOM : return pathToFile;
            }
        }
    }
}