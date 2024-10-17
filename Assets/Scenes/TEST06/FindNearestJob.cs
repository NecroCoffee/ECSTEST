using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

// �W���u���o�[�X�g�R���p�C������ɂ́ABurstCompile�������܂߂܂��B
[BurstCompile]
public struct FindNearestJob : IJob
{
    // �W���u���A�N�Z�X���邷�ׂẴf�[�^�́A���̃t�B�[���h�Ɋ܂߂�ׂ��ł���B
    // ���̃t�B�[���h�Ɋ܂܂�Ȃ���΂Ȃ�Ȃ��B���̏ꍇ�A�W���u�ɂ�
    // float3��3�̔z��B
    //���̏ꍇ�A�W���u�� 
    // float3��3�̔z���K�v�Ƃ��܂��B
    //���̏ꍇ�A�W���u���A�N�Z�X����f�[�^�� 
    // �t�B�[���h�Ɋ܂߂�K�v������܂��B
    // ���̏ꍇ�A�����ɂ͕K�v�ł͂���܂��񂪁A�f�[�^  
    //���̏ꍇ�A�����ɂ͕K�v�ł͂Ȃ����A�f�[�^�� ReadOnly �Ƃ��ă}�[�N���邱�ƂŁA 
    // �W���u�X�P�W���[������葽���̃W���u�𓯎��Ɉ��S�Ɏ��s�ł���悤�ɂȂ�B
    // ��葽���̃W���u�𓯎��Ɏ��s���邱�Ƃ��ł���B

    [ReadOnly] public NativeArray<float3> TargetPositions;
    [ReadOnly] public NativeArray<float3> SeekerPositions;

    // SeekerPositions[i]�ɑ΂��āA
    // �ł��߂��^�[�Q�b�g�ʒu��NearestTargetPositions[i]�ɑ������B
    // NearestTargetPositions[i]�Ɋ��蓖�Ă�B

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