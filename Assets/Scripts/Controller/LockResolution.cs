using UnityEngine;
using System.Collections;

public class LockResolution : MonoBehaviour
{
    public static void _LockResolution(){
        //Use this to lock resolution
        int width = 480; // or something else
        int height = 800; // or something else
        bool isFullScreen = false; // should be windowed to run in arbitrary resolution
        int desiredFPS = 60; // or something else

        Screen.SetResolution(width, height, isFullScreen, desiredFPS);
    }
}
