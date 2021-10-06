using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedMemoryToTransform : SharedMemoryReader
{
    // output from shared memory
    public Transform[] data;

    // set as Transform
    public override void OutputData(float[] buffer)
    {
        for (int i = 0; i < data.Length && i * 7 + 6 < buffer.Length; i++)
        {
            int offset = i * 7;
            data[i].rotation = new Quaternion(buffer[offset], buffer[offset + 2], -buffer[offset + 1], buffer[offset + 3]); // (UE4.rot.x, -UE4.rot.z, UE4.rot.y, UE4.rot.w)
            data[i].position = new Vector3(buffer[offset + 4], buffer[offset + 6], -buffer[offset + 5]) / 100.0f; // (UE4.pos.x, -UE4.pos.z, UE4.pos.y) / 100
        }
    }
}
