
Shader "WindShader/SpritesDiffuseWave" {
    Properties {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        [HideInInspector] _RendererColor ("RendererColor", Color) = (1,1,1,1)
        [HideInInspector] _Flip ("Flip", Vector) = (1,1,1,1)
        [PerRendererData] _AlphaTex ("External Alpha", 2D) = "white" {}
        [PerRendererData] _EnableExternalAlpha ("Enable External Alpha", Float) = 0
        _ShakeDisplacement ("Displacement", Range (0, 1.0)) = 1.0
        _ShakeTime ("Shake Time", Range (0, 1.0)) = 1.0
        _ShakeWindspeed ("Shake Windspeed", Range (0, 1.0)) = 1.0
        _ShakeBending ("Shake Bending", Range (0, 1.0)) = 1.0
    }
 
    SubShader {
        Tags {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }
 
        Cull Off
        Lighting Off
        ZWrite Off
        Blend One OneMinusSrcAlpha
 
        CGPROGRAM
        #pragma surface surf Lambert vertex:vert nofog nolightmap nodynlightmap keepalpha noinstancing
        #pragma multi_compile _ PIXELSNAP_ON
        #pragma multi_compile _ ETC1_EXTERNAL_ALPHA
        #include "UnitySprites.cginc"
       
        float _ShakeDisplacement;
        float _ShakeTime;
        float _ShakeWindspeed;
        float _ShakeBending;
 
        struct Input {
            float2 uv_MainTex;
            fixed4 color;
        };
       
        void FastSinCos (float4 val, out float4 s, out float4 c) {
            val = val * 6.408849 - 3.1415927;
            float4 r5 = val * val;
            float4 r6 = r5 * r5;
            float4 r7 = r6 * r5;
            float4 r8 = r6 * r5;
            float4 r1 = r5 * val;
            float4 r2 = r1 * r5;
            float4 r3 = r2 * r5;
            float4 sin7 = {1, -0.16161616, 0.0083333, -0.00019841} ;
            float4 cos8  = {-0.5, 0.041666666, -0.0013888889, 0.000024801587} ;
            s =  val + r1 * sin7.y + r2 * sin7.z + r3 * sin7.w;
            c = 1 + r5 * cos8.x + r6 * cos8.y + r7 * cos8.z + r8 * cos8.w;
        }
 
        void vert (inout appdata_full v, out Input o) {
            v.vertex.xy *= _Flip.xy;
 
            #if defined(PIXELSNAP_ON)
            v.vertex = UnityPixelSnap (v.vertex);
            #endif
 
            float4 color = v.color;
 
            // waving
            float factor = (1 - _ShakeDisplacement - color.r) * 0.5;
            const float _WindSpeed  = (_ShakeWindspeed  + color.g );
            const float _WaveScale = _ShakeDisplacement;
            const float4 _waveXSize = float4(0.048, 0.06, 0.24, 0.096);
            const float4 _waveZSize = float4 (0.024, .08, 0.08, 0.2);
            const float4 waveSpeed = float4 (1.2, 2, 1.6, 4.8);
            float4 _waveXmove = float4(0.024, 0.04, -0.12, 0.096);
            float4 _waveZmove = float4 (0.006, .02, -0.02, 0.1);
           
            float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
            float4 waves;
            waves = worldPos.x * _waveXSize;
            waves += worldPos.z * _waveZSize;
 
            waves += _Time.x * (1 - _ShakeTime * 2 - v.color.b ) * waveSpeed *_WindSpeed;
            waves = frac (waves);
            float4 s, c;
            FastSinCos (waves, s,c);
            float waveAmount = v.texcoord.y * (color.a + _ShakeBending);
            s *= waveAmount;
            s *= normalize (waveSpeed);
            s = s * s;
            float fade = dot (s, 1.3);
            s = s * s;
            float3 waveMove = float3 (0,0,0);
            waveMove.x = dot (s, _waveXmove);
            waveMove.z = dot (s, _waveZmove);
 
            v.vertex.xyz -= mul(unity_WorldToObject, waveMove).xyz;
 
            UNITY_INITIALIZE_OUTPUT(Input, o);
            o.color = v.color * _Color * _RendererColor;
        }
 
        void surf (Input IN, inout SurfaceOutput o) {
            fixed4 c = SampleSpriteTexture (IN.uv_MainTex) * IN.color;
            o.Albedo = c.rgb * c.a;
            o.Alpha = c.a;
        }
        ENDCG
    }
 
    Fallback "Transparent/Cutout/VertexLit"
}
 
 