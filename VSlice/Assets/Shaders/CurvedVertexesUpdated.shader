Shader "Custom/CurvedVertexesNew" 
{
    Properties 
    {
       _MainTex ("Base (RGB)", 2D) = "white" {}
       _QOffset ("Offset", Vector) = (0,0,0,0)
       _Dist ("Distance", Float) = 100.0

	   _Color ("Main Color", Color) = (.5,.5,.5,1)
	   _OutlineColor ("Outline Color", Color) = (1,0.5,0,1)
	   _Outline ("Outline width", Range (0.0, 0.1)) = .05

    }
 
 
    SubShader 
    {
       Tags { "RenderType"="Opaque" }
 
 		Pass 
		{
			Name "BASE"
            Tags { "LightMode" = "Always" }
			CGPROGRAM
			#pragma fragment frag
			#pragma vertex vert
			#pragma fragmentoption ARB_fog_exp2
			#pragma fragmentoption ARB_precision_hint_fastest
			#include "UnityCG.cginc"

			struct v2f 
			{
				float4		pos				: SV_POSITION;
				float2		uv				: TEXCOORD0;
				float3		viewDir			: TEXCOORD1;
				float3		normal        : TEXCOORD2;
			}; 

			v2f vert (appdata_base v)
			{
				v2f p;
				p.pos = mul (UNITY_MATRIX_MVP, v.vertex);
				//p.normal = mul(UNITY_MATRIX_MVP, v.normal);
				p.normal = v.normal;
				p.uv = v.texcoord;
				p.viewDir = ObjSpaceViewDir( v.vertex );
				return p;
			}

			uniform float4 _Color;

			sampler2D _MainTex;
			float4 frag (v2f i)  : COLOR
			{
				half4 texcol = tex2D( _MainTex, i.uv );
				half3 ambient = texcol.rgb * (UNITY_LIGHTMODEL_AMBIENT.rgb);
				return float4( ambient, texcol.a * _Color.a );
			}
         ENDCG

		 Cull Front
         ZWrite On
         ColorMask RGB
         Blend SrcAlpha OneMinusSrcAlpha
         SetTexture [_MainTex] { combine primary }
       }
	          Pass
       {
	   Name "OUTLINE"
			Tags {"LightMode" = "Always"}

			CGPROGRAM
// Upgrade NOTE: excluded shader from DX11 and Xbox360; has structs without semantics (struct appdata members vertex,normal)
#pragma exclude_renderers d3d11 xbox360
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct appdata 
			{
				float4 vertex;
				float3 normal;
			};
 
            sampler2D _MainTex;
			float4 _QOffset;
			float _Dist;
 
			struct v2f 
			{
				float4 pos : SV_POSITION;
				float4 uv : TEXCOORD0;

				float4 outlinePos : POSITION;
				float4 color : COLOR;
				float4 outLineColor : COLOR;
				float fog : FOGC;
			};

			float _Outline;
			float4 _OutlineColor;
 
			v2f vert (appdata_base v)
			{
				v2f o;
				float4 vPos = mul (UNITY_MATRIX_MV, v.vertex);
				float zOff = vPos.z/_Dist;

				float3 norm = mul ((float3x3)UNITY_MATRIX_MV, v.normal);
				norm.x *= UNITY_MATRIX_P[0][0];
				norm.y *= UNITY_MATRIX_P[1][1];

				vPos += _QOffset*zOff*zOff;
				o.outlinePos = mul (UNITY_MATRIX_P, vPos);

			 
				o.outlinePos.xy += norm.xy * _Outline;

				o.uv = v.texcoord;
				o.fog = o.pos.z;
				o.outLineColor = _OutlineColor;
				return o;
         }
 
         half4 frag (v2f i) : COLOR
         {
             half4 col = tex2D(_MainTex, i.uv.xy);
             return col;
         }
		ENDCG
		}
    }
    FallBack "Diffuse"
}