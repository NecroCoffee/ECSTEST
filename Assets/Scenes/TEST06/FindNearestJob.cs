using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

// ジョブをバーストコンパイルするには、BurstCompile属性を含めます。
[BurstCompile]
public struct FindNearestJob : IJob
{
    // ジョブがアクセスするすべてのデータは、そのフィールドに含めるべきである。
    // そのフィールドに含まれなければならない。この場合、ジョブには
    // float3の3つの配列。
    //この場合、ジョブは 
    // float3の3つの配列を必要とします。
    //この場合、ジョブがアクセスするデータを 
    // フィールドに含める必要があります。
    // この場合、厳密には必要ではありませんが、データ  
    //この場合、厳密には必要ではないが、データを ReadOnly としてマークすることで、 
    // ジョブスケジューラがより多くのジョブを同時に安全に実行できるようになる。
    // より多くのジョブを同時に実行することができる。

    [ReadOnly] public NativeArray<float3> TargetPositions;
    [ReadOnly] public NativeArray<float3> SeekerPositions;

    // SeekerPositions[i]に対して、
    // 最も近いターゲット位置をNearestTargetPositions[i]に代入する。
    // NearestTargetPositions[i]に割り当てる。

    public NativeArray<float3> NearestTargetPositions;

    public void Execute()
    {
        for(int i=0; i < SeekerPositions.Length; i++)
        {
            float3 seekerPos = SeekerPositions[i];
            float nearestDistSq = float.MaxValue;
            for(int j = 0; j < TargetPositions.Length; j++)
            {
                float3 targetPos = SeekerPositions[j];
                float distSq = math.distancesq(seekerPos, targetPos);
                if (distSq < nearestDistSq)
                {
                    nearestDistSq = distSq;
                    NearestTargetPositions[i] = targetPos;
                }
            }
        }
    }

}