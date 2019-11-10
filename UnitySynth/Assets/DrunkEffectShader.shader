Shader "Other/DrunkEffectShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Strength ("Strength", Range(50,600)) = 75
        _Speed("Wave Speed", Range(10,30)) = 12
        _HueShift("Hue Shift On", int) = 1
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float _Strength;
            float _Speed;
            int _HueShift;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv + float2(0, sin(i.vertex.x/_Strength + (_Time[0]*_Speed)) / 20));
                // just invert the colors
                float r = 0.95 - col.r;
                float g = 0.05 + col.g;
                col.r = max(col.r, _HueShift * r);
                col.g = max(col.g, _HueShift * g);
                return col;
            }
            ENDCG
        }
    }
}
