Shader "Unlit/CRT"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Distortion ("Distortion", Float) = 0.1
        _ScanlineIntensity ("Scanline Intensity", Float) = 0.1
        _NoiseIntensity ("Noise Intensity", Float) = 0.05
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            
            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
            
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
            
            sampler2D _MainTex;
            float _Distortion;
            float _ScanlineIntensity;
            float _NoiseIntensity;
            
            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            half4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;
                uv = uv * 2.0 - 1.0; // Convert to -1 to 1 space
                uv += uv * (dot(uv, uv) * _Distortion);
                uv = uv * 0.5 + 0.5; // Convert back to 0 to 1 space
                
                // Scanline effect
                float scanline = sin(uv.y * _ScreenParams.y * 2.0) * _ScanlineIntensity;
                
                // Noise effect
                float noise = (frac(sin(dot(uv * _Time, float2(12.9898, 78.233))) * 43758.5453) - 0.5) * _NoiseIntensity;

                // Sample the texture
                half4 col = tex2D(_MainTex, uv);
                
                // Apply scanline and noise
                col.rgb += scanline;
                col.rgb += noise;
                
                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
