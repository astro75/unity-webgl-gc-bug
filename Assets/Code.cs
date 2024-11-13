using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

public class Code : MonoBehaviour
{
    public Button allocate, clear, gc;
    public TextMeshProUGUI text;

    List<byte[]> memory = new();

    StringBuilder sb = new();
    
    void Start()
    {
        allocate.onClick.AddListener(() => memory.Add(new byte[30 * 1024 * 1024 - 40]));
        
        clear.onClick.AddListener(() => memory.Clear());
        
        gc.onClick.AddListener(() => GC.Collect());
    }

    void Update()
    {
        sb.AppendLine($"systemMemorySize: {SystemInfo.systemMemorySize}");
        sb.AppendLine($"graphicsMemorySize: {SystemInfo.graphicsMemorySize}");
        sb.AppendLine($"GetTotalMemory: {GC.GetTotalMemory(false) / 1024 / 1024}");
        
        sb.AppendLine($"totalAllocatedMemory: {Profiler.GetTotalAllocatedMemoryLong() / 1024 / 1024}");
        sb.AppendLine($"totalReservedMemory: {Profiler.GetTotalReservedMemoryLong() / 1024 / 1024}");
        sb.AppendLine($"totalUnusedReservedMemory: {Profiler.GetTotalUnusedReservedMemoryLong() / 1024 / 1024}");
        sb.AppendLine($"monoUsedSize: {Profiler.GetMonoUsedSizeLong() / 1024 / 1024}");
        sb.AppendLine($"monoHeapSize: {Profiler.GetMonoHeapSizeLong() / 1024 / 1024}");
        sb.AppendLine($"tempAllocator: {Profiler.GetTempAllocatorSize() / 1024 / 1024}");
        sb.AppendLine($"graphicsDriver: {Profiler.GetAllocatedMemoryForGraphicsDriver() / 1024 / 1024}");

        text.SetText(sb);

        sb.Clear();
    }
}
