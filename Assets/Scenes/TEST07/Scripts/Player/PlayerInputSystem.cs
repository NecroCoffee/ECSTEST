using Unity.Entities;
using UnityEngine;
using Unity.Burst;


//ECS�ł�ISystem�̋L�q���e�͂��ׂĎ����I�ɏ�������
//�܂肱�̃X�N���v�g���G�f�B�^��ŃA�^�b�`����K�v�͂Ȃ�
//����̂ɍX�V�����̒��ŏ����Ώۂ��i����e���L�q����K�v������
public partial struct PlayerInputSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<Player>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //SysAPI�̃N�G�����g����"�V�[���̒�����Player�R���|�[�l���g����������"
        //�q�b�g����Player�R���|�[�l���g�ɂ̂ݏ������s��
        //
        foreach(var PlayerInput in SystemAPI.Query<RefRW<Player>>())
        {
            PlayerInput.ValueRW.Horizontal = horizontal;
            PlayerInput.ValueRW.Vertical = vertical;
        }
    }
}