using Unity.Entities;
using UnityEngine;
using Unity.Burst;


//ECSではISystemの記述内容はすべて自動的に処理する
//つまりこのスクリプトをエディタ上でアタッチする必要はない
//それ故に更新処理の中で処理対象を絞る内容を記述する必要がある
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

        //SysAPIのクエリを使って"シーンの中からPlayerコンポーネントを検索して"
        //ヒットしたPlayerコンポーネントにのみ処理を行う
        //
        foreach(var PlayerInput in SystemAPI.Query<RefRW<Player>>())
        {
            PlayerInput.ValueRW.Horizontal = horizontal;
            PlayerInput.ValueRW.Vertical = vertical;
        }
    }
}