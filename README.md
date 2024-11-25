# unity-webgl-latency-issue

Test build at
https://astro75.github.io/unity-webgl-gc-bug/build/

Some C# objects never get collected by GC on Webgl.

To reproduce a bug:
1. In the built project, click the `Allocate` button 5 times
2. Click the `Clear` button
3. Click the `GC` button
4. Observe the result

Expected result: `monoUsedHeapSize` shows a value of 2 (same as the starting value)
Actual result: `monoUsedHeapSize` shows a higher value, such as 32 or 62
