using UnityEngine;
using Bonjour;

namespace Bonjour.VAT{
    public struct VATData
    {
        public VATData(Material mat){
            autoPlayback                = MaterialGetter.GetBoolValue(mat, "_B_autoPlayback");
            gameStartAtFirstFrame       = MaterialGetter.GetFloatValue(mat, "_gameTimeAtFirstFrame");
            playbackSpeed               = MaterialGetter.GetFloatValue(mat, "_playbackSpeed");
            houdiniFPS                  = MaterialGetter.GetFloatValue(mat, "_houdiniFPS");
            displayFrame                = MaterialGetter.GetFloatValue(mat, "_displayFrame");
            supportSurfaceNormalMap     = MaterialGetter.GetBoolValue(mat, "_B_surfaceNormals");
            twoSidedNormals             = MaterialGetter.GetBoolValue(mat, "_B_twoSidedNorms");
            loadColorTexture            = MaterialGetter.GetBoolValue(mat, "_Load_Color_Texture");
            positionRequiredTwoTextures = MaterialGetter.GetBoolValue(mat, "_Positions_Require_Two_Textures");
            loadSurfaceNormal           = MaterialGetter.GetBoolValue(mat, "_Load_Surface_Normal_Map");

            positionTexture             = MaterialGetter.GetTexture(mat, "_posTexture");
            positionTexture2            = MaterialGetter.GetTexture(mat, "_posTexture2");
            colorTexture                = MaterialGetter.GetTexture(mat, "_colTexture");
            spareColorTexture           = MaterialGetter.GetTexture(mat, "_spareColTexture");

            //Soft Body
            rotationTexture             = MaterialGetter.GetTexture(mat, "_rotTexture");
            interframeInterpolations    = MaterialGetter.GetBoolValue(mat, "_B_interpolate");
            interpolateColor            = MaterialGetter.GetBoolValue(mat, "_B_interpolateCol");
            interpolateSpareColor       = MaterialGetter.GetBoolValue(mat, "_B_interpolateSpareCol");
            useCompressedNormals        = MaterialGetter.GetBoolValue(mat, "_Use_Compressed_Normals");

            //Rigid Body

            //Particles

            //Dynamic

            //Data
            frameCount = MaterialGetter.GetFloatValue(mat, "_frameCount");
            boundMaxX  = MaterialGetter.GetFloatValue(mat, "_boundMaxX");
            boundMaxY  = MaterialGetter.GetFloatValue(mat, "_boundMaxY");
            boundMaxZ  = MaterialGetter.GetFloatValue(mat, "_boundMaxZ");
            boundMinX  = MaterialGetter.GetFloatValue(mat, "_boundMinX");
            boundMinY  = MaterialGetter.GetFloatValue(mat, "_boundMinY");
            boundMinZ  = MaterialGetter.GetFloatValue(mat, "_boundMinZ");
        }

        //shared Params
        public readonly bool autoPlayback;
        public readonly float gameStartAtFirstFrame;
        public readonly float displayFrame;
        public readonly float playbackSpeed;
        public readonly float houdiniFPS;
        public readonly bool supportSurfaceNormalMap;
        public readonly bool twoSidedNormals;
        public readonly bool loadColorTexture;
        public readonly bool positionRequiredTwoTextures;
        public readonly bool loadSurfaceNormal;
        public readonly Texture positionTexture;
        public readonly Texture positionTexture2;
        public readonly Texture colorTexture;
        public readonly Texture spareColorTexture;

        //Soft body
        public readonly Texture rotationTexture;
        public readonly bool interframeInterpolations;
        public readonly bool interpolateColor;
        public readonly bool interpolateSpareColor;
        public readonly bool useCompressedNormals;

        // //Rigid Body
        // public readonly bool pieceScaleAreInPositionAlpha;
        // public readonly float globalPieceScaleMultiplier;
        // public readonly bool stretchByVelocity;
        // public readonly float stretchByVelocityAmount;
        // public readonly bool animateFirstFrame;
        // public readonly bool smoothlyInterpolatedTrajectory;
        
        // //Particles Sprites
        // public readonly bool particleScalesAreInPositionAlpha;
        // public readonly float globalParticleScaleMultiplier;
        // public readonly float particleWidthBaseScale;
        // public readonly float particleHeigtBaseScale;
        // public readonly float particlesTextureUScale;
        // public readonly float particlesTextureVScale;
        // public readonly bool computeSpinFromHeadingVector;
        // public readonly float scaleByVelocityAmount;
        // public readonly float particleSpinPhase;
        // public readonly bool hideParticlesOverlappingObjectOrigin;
        // public readonly float originEffectiveRadius;
        // public readonly bool particleCanSpin;

        // //Dynamic Remeshing
        // public readonly bool surfaceUVsFromColorRG;
        // public readonly Texture lookupTable;

        //Data
        public readonly float frameCount;
        public readonly float boundMaxX;
        public readonly float boundMaxY;
        public readonly float boundMaxZ;
        public readonly float boundMinX;
        public readonly float boundMinY;
        public readonly float boundMinZ;
    }
}