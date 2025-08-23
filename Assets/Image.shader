Shader "Custom/Billboard"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color",Color)=(1,1,1,1)
    }

    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        ZWrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            fixed4 _Color;
            float4 _MainTex_ST;

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

                // Направления камеры
                float3 camRight = UNITY_MATRIX_V[0].xyz;
                float3 camUp    = UNITY_MATRIX_V[1].xyz;
                

                // Центр объекта
                float3 worldPos = mul(unity_ObjectToWorld, float4(0,0,0,1)).xyz;

                // Локальный масштаб объекта
                float3 scale = float3(
                    length(unity_ObjectToWorld._m00_m10_m20), // X scale
                    length(unity_ObjectToWorld._m01_m11_m21), // Y scale
                    length(unity_ObjectToWorld._m02_m12_m22)  // Z scale
                );
                
                // Добавляем смещение с учётом масштаба
                worldPos += camRight * (v.vertex.x * scale.x);
                worldPos += camUp    * (v.vertex.y * scale.y);

                o.vertex = UnityWorldToClipPos(worldPos);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                
                return tex2D(_MainTex, i.uv)*_Color;
            }
            ENDCG
        }
    }
}
