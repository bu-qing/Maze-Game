Shader "Custom/CustomLightCookieShader"
{
    Properties
    {
        _MainTex ("Cookie Texture", 2D) = "white" {} // Cookie Property
        // Add any other properties we need for lighting effects
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }

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
            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                // Sample the texture and use it as the light intensity
                half4 cookie = tex2D(_MainTex, i.uv);
                return cookie;
            }
            ENDCG
        }
    }
}
