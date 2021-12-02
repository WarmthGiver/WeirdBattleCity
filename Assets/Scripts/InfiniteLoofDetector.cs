
using System;

public static class InfiniteLoopDetector
{
    private static string previousPoint = "";

    private static int detectionCount = 0;

    private const int detectionThreshold = 100000;

    [System.Diagnostics.Conditional("UNITY_EDITOR")]

    public static void Check([System.Runtime.CompilerServices.CallerMemberName] string mn = "", [System.Runtime.CompilerServices.CallerFilePath] string fp = "", [System.Runtime.CompilerServices.CallerLineNumber] int ln = 0)
    {
        string currentPoint = $"{fp}:{ln}, {mn}()";

        if (previousPoint == currentPoint)
        {
            ++detectionCount;
        }

        else
        {
            detectionCount = 0;
        }

        if (detectionCount > detectionThreshold)
        {
            throw new Exception($"Infinite Loop Detected: \n{currentPoint}\n\n");
        }

        previousPoint = currentPoint;
    }

#if UNITY_EDITOR

    [UnityEditor.InitializeOnLoadMethod]

    private static void Init()
    {
        UnityEditor.EditorApplication.update += () => { detectionCount = 0; };
    }

#endif
}