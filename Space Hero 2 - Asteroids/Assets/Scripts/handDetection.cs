using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
internal static class OpenCVHand
{
    [DllImport("unityHandDet")]
    internal static extern int Init(ref int outCameraWidth, ref int outCameraHeight);

    [DllImport("unityHandDet")]
    internal static extern int Close();

    [DllImport("unityHandDet")]
    internal static extern int SetScale(int scale);

    [DllImport("unityHandDet")]
    internal unsafe static extern void Detect(ref int X, ref int Y, ref int fingerNum);

    [DllImport("unityHandDet")]
    internal static extern int SetFilters(ref bool init);
}


public class handDetection : MonoBehaviour
{
    public static Vector2 calculatedHandPosition { get; private set; }
    public static int calculatedFingerNumber { get; private set; }
    public static Vector2 CameraResolution { get; private set; }

    private int fingerNum = 0;


    private const int DetectionDownScale = 1;

    private bool _ready;

    private bool _initialize;

    private int counts;

    void Start()
    {
        int camWidth = 0, camHeight = 0;
        int result = OpenCVHand.Init(ref camWidth, ref camHeight);
        fingerNum = 0;
        counts = 0;
        calculatedFingerNumber = 0;
        if (result == -1)
        {           
           Debug.LogWarningFormat("[{0}] Failed to open camera stream.", GetType());
           return;
        }

        CameraResolution = new Vector2(camWidth, camHeight);
        OpenCVHand.SetScale(DetectionDownScale);
        _ready = true;
    }

    void OnApplicationQuit()
    {
        if (_ready)
        {
            OpenCVHand.Close();
        }
    }

    void Update()
    {
        if (!_ready)
            return;
        if (!_initialize)
        {
            bool init = false;
            OpenCVHand.SetFilters(ref init);
            _initialize = init;
        }
        else
        {
            int X = 0, Y = 0;
            

            OpenCVHand.Detect(ref X, ref Y, ref fingerNum);
            counts++;
            calculatedHandPosition = new Vector2(X, Y);
            if (counts > 200)
            {
                calculatedFingerNumber = fingerNum;
                Debug.Log("finger : " + calculatedFingerNumber);
            }
            //Debug.Log("X : " + X);
            //Debug.Log("Y : " + Y);
        }
    }
}
