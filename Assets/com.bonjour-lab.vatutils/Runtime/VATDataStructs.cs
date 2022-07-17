using UnityEngine;

namespace Bonjour.VAT{
    public struct VATSharedParams
    {
        //shared Params
        public bool autoPlayback;
        public float gameStartAtFirstFrame;
        public float displayFrame;
        public float playbackSpeed;
        public float houdiniFPS;
        public bool supportSurfaceNormalMap;
        public bool twoSidedNormals;
        public bool loadColorTexture;
        public bool positionRequiredTwoTextures;
        public bool loadSurfaceNormal;
        public Texture positionTexture;
        public Texture positionTexture2;
        public Texture colorTexture;
        public Texture spareColorTexture;

        //Soft body
        public Texture rotationTexture;
        public bool interframeInterpolations;
        public bool interpolateColor;
        public bool interpolateSpareColor;
        public bool useSurfaceNormal;

        //Rigid Body
        public bool pieceScaleAreInPositionAlpha;
        public float globalPieceScaleMultiplier;
        public bool stretchByVelocity;
        public float stretchByVelocityAmount;
        public bool animateFirstFrame;
        public bool smoothlyInterpolatedTrajectory;
        
        //Particles Sprites
        public bool particleScalesAreInPositionAlpha;
        public float globalParticleScaleMultiplier;
        public float particleWidthBaseScale;
        public float particleHeigtBaseScale;
        public float particlesTextureUScale;
        public float particlesTextureVScale;
        public bool computeSpinFromHeadingVector;
        public float scaleByVelocityAmount;
        public float particleSpinPhase;
        public bool hideParticlesOverlappingObjectOrigin;
        public float originEffectiveRadius;
        public bool particleCanSpin;

        //Dynamic Remeshing
        public bool surfaceUVsFromColorRG;
        public Texture lookupTable;

        //Data
        public float frameCount;
        public float boundMaxX;
        public float boundMaxY;
        public float boundMaxZ;
        public float boundMinX;
        public float boundMinY;
        public float boundMinZ;
    }
}