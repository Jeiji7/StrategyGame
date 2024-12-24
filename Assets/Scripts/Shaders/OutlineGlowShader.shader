Shader "Sprites/OutlineFixed"
{
    Properties
    {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _OutlineThickness ("Outline Thickness", Range(0.0, 0.1)) = 0.03
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        LOD 100

        Pass
        {
            Name "OUTLINE"
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            ColorMask RGBA
            Lighting Off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _OutlineColor;
            float _OutlineThickness;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : COLOR
            {
                fixed4 col = tex2D(_MainTex, i.texcoord);

                // Если пиксель прозрачный, проверяем соседние пиксели для обводки
                if (col.a == 0)
                {
                    float2 offsets[8] = {
                        float2(_OutlineThickness, 0), 
                        float2(-_OutlineThickness, 0),
                        float2(0, _OutlineThickness), 
                        float2(0, -_OutlineThickness),
                        float2(_OutlineThickness, _OutlineThickness),
                        float2(-_OutlineThickness, _OutlineThickness),
                        float2(_OutlineThickness, -_OutlineThickness),
                        float2(-_OutlineThickness, -_OutlineThickness)
                    };

                    for (int j = 0; j < 8; j++)
                    {
                        float2 offset = offsets[j];
                        fixed4 neighbor = tex2D(_MainTex, i.texcoord + offset);

                        if (neighbor.a > 0)
                        {
                            return _OutlineColor; // Возвращаем цвет обводки
                        }
                    }
                }

                // Если это основной пиксель спрайта, возвращаем его цвет
                return col;
            }
            ENDCG
        }
    }
}
