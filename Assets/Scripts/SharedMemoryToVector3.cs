using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedMemoryToVector3 : SharedMemoryReader
{
    // output from shared memory
    public Transform[] data;

    // set as Vector3
    public override void OutputData(float[] buffer)
    {
        for (int i = 0; i < data.Length && i * 3 + 2 < buffer.Length; i++)
        {
            data[i].position = new Vector3(buffer[i * 3], -buffer[i * 3 + 1], buffer[i * 3 + 2]) / 100.0f; // (ImagePixel.x, -ImagePixel.y, ImagePixel.z) / 100
        }
    }
}
