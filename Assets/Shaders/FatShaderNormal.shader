 Shader "Custom/Fat Shader"
 {
 	Properties 
 	{
      _MainTex("Texture", 2D) = "white" {}
      _Normal("Normal Map", 2D) = "bump" {}
      _Amount("Extrusion", Range(-0.8, 0.8)) = 0.5
    }

    SubShader 
    {
      Tags
      {
      	"RenderType" = "Opaque"
      }

      CGPROGRAM
      #pragma surface surf Lambert vertex:vert

      struct Input 
      {
          float2 uv_MainTex;
          float2 uv_Normal;
      };

      float _Amount;
      void vert (inout appdata_full v) 
      {
          v.vertex.xyz += v.normal * _Amount;
      }

      sampler2D _MainTex;
      sampler2D _Normal;
      void surf (Input IN, inout SurfaceOutput o) 
      {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
          o.Normal = UnpackNormal(tex2D(_Normal, IN.uv_Normal));
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }