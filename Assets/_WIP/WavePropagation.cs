using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavePropagation : PostEffectsBase {

    public Shader Shader;
    private Material m_Material;

    [Range(0.0f, 0.3f)]
    public float RippleRadius = 0.05f;

    public Material material
    {
        get
        {
            m_Material = CheckShaderAndCreateMaterial(Shader, m_Material);
            return m_Material;
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (material)
        {
            material.SetFloat("_RippleRadius", RippleRadius);
            Graphics.Blit(source, destination, material);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }
}
