// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/StarShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_NoiseTex("Noise", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
	}
	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float3 viewDir : TEXCOORD1;
				float3 normal : NORMAL;
				float2 noise : NOISE;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			sampler2D _NoiseTex;
			float4 _NoiseTex_ST;
			float4 _Color;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.uv = v.uv;
				o.vertex = UnityObjectToClipPos(v.vertex);
				
				o.noise = TRANSFORM_TEX(v.uv, _NoiseTex);
				o.normal = UnityObjectToWorldNormal(v.normal);
				o.viewDir = normalize(UnityWorldSpaceViewDir(mul(unity_ObjectToWorld, v.vertex)));
				return o;
			}
			

			fixed4 frag (v2f i) : SV_Target
			{
				fixed2 offset = (_Time.y * 0.25, _Time.x ) * 0.25f;
				float2 noiseOffset = (tex2D(_NoiseTex, i.noise + offset) - 0.25) * 2;
				float ndotv = 1 -  dot(i.normal, i.viewDir);
				fixed4 col = tex2D(_MainTex, i.uv + noiseOffset);
				

				return col * _Color * (1 + ndotv) ;
			}
			ENDCG
		}
	}
}
