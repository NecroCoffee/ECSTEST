using Unity.Entities;
using UnityEngine;
using Unity.Burst;

//Player�G���e�B�e�B�̃f�[�^
public struct Player : IComponentData
{
    public float Speed;
    public float Horizontal;
    public float Vertical;
    public float PosY;
}

//Player�̏���PlayerEntity�ɗ^���邽�߂̃R�[�h
public class PlayerAuthoring : MonoBehaviour
{
    public float speed;
    public float posY;

    class Baker : Baker<PlayerAuthoring>
    {
        public override void Bake(PlayerAuthoring authoring)
        {
            var data = new Player() 
            {
                Speed = authoring.speed,
                PosY = authoring.posY 
            };
            AddComponent(GetEntity(TransformUsageFlags.Dynamic), data);
        }
    }
}