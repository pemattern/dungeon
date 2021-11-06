using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorBand : MonoBehaviour
{
    public const int WIDTH = 240;
    public const int HEIGHT = 135;
    private float[] resolution = {WIDTH, HEIGHT};
    private int colorBands = 8;
    private float[] tintColor = {0.05f, 0.2f, 0.05f, 1.0f};

    public ComputeShader colorBandShader;
    public RenderTexture renderTextureInput;
    public RenderTexture renderTextureOutput;

    public RawImage rawImage;

    private int kernel;

    void Start()
    {
        kernel = colorBandShader.FindKernel("ColorBand");


        renderTextureInput = new RenderTexture(WIDTH, HEIGHT, 24);
        renderTextureInput.wrapMode = TextureWrapMode.Repeat;
        renderTextureInput.filterMode = FilterMode.Point;
        renderTextureInput.useMipMap = false;
        renderTextureInput.Create();

        renderTextureOutput = new RenderTexture(WIDTH, HEIGHT, 24);
        renderTextureOutput.wrapMode = TextureWrapMode.Repeat;
        renderTextureOutput.enableRandomWrite = true;
        renderTextureOutput.filterMode = FilterMode.Point;
        renderTextureOutput.useMipMap = false;
        renderTextureOutput.Create();

        Camera.main.targetTexture = renderTextureInput;
        rawImage.texture = renderTextureOutput;
        rawImage.color = Color.white;

        colorBandShader.SetFloat("Width", resolution[0]);
        colorBandShader.SetFloat("Height", resolution[1]);
        colorBandShader.SetInt("Colorbands", colorBands);
        colorBandShader.SetFloats("TintColor", tintColor);
    }

    public void Update()
    {
        colorBandShader.SetTexture(kernel, "Input", renderTextureInput);
        colorBandShader.SetTexture(kernel, "Output", renderTextureOutput);
        colorBandShader.Dispatch(kernel, WIDTH, HEIGHT, 1);
    }
}
