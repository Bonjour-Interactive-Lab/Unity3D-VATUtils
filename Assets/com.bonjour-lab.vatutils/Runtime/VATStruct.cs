namespace Bonjour.VAT{
    public struct VATParams{
        public float _doubleTex;
        public float _height;
        public float _normData;
        public float _numOfFrames;
        public float _packNorm;
        public float _packPscale;
        public float _paddedX;
        public float _paddedY;
        public float _pivMax;
        public float _pivMin;
        public float _posMax;
        public float _posMin;
        public float _scaleMax;
        public float _scaleMin;
        public float _speed;
        public float _width;
    }

    public struct VATGlobalParams{
        public string name;
        public VATParams vatparams;
    }
}