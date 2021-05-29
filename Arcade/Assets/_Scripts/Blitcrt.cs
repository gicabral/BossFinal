using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Blitcrt : MonoBehaviour
{
    public Shader shader;
    public float bend = 4f;
    public float scanlineSize1 = 3000;
    public float scanlineSpeed1 = -1;
    public float scanlineSize2 = 2000;
    public float scanlineSpeed2 = -2;
    public float scanlineAmount = 0.01f;
    public float vignetteSize = 1.9f;
    public float vignetteSmoothness = 0.3f;
    public float vignetteEdgeRound = 7f;
    public float noiseSize = 0.0f;
    public float noiseAmount = 0.0f;

    // Chromatic aberration amounts
    public Vector2 redOffset = new Vector2(0, 0.0f);
    public Vector2 blueOffset = Vector2.zero;
    public Vector2 greenOffset = new Vector2(0, 0.001f);

    private Material material;

    // Use this for initialization
    void Start()
    {
        material = new Material(shader);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        material.SetFloat("u_time", Time.fixedTime);
        material.SetFloat("u_bend", bend);
        material.SetFloat("u_scanline_size_1", scanlineSize1);
        material.SetFloat("u_scanline_speed_1", scanlineSpeed1);
        material.SetFloat("u_scanline_size_2", scanlineSize2);
        material.SetFloat("u_scanline_speed_2", scanlineSpeed2);
        material.SetFloat("u_scanline_amount", scanlineAmount);
        material.SetFloat("u_vignette_size", vignetteSize);
        material.SetFloat("u_vignette_smoothness", vignetteSmoothness);
        material.SetFloat("u_vignette_edge_round", vignetteEdgeRound);
        material.SetFloat("u_noise_size", noiseSize);
        material.SetFloat("u_noise_amount", noiseAmount);
        material.SetVector("u_red_offset", redOffset);
        material.SetVector("u_blue_offset", blueOffset);
        material.SetVector("u_green_offset", greenOffset);
        Graphics.Blit(source, destination, material);
    }
}