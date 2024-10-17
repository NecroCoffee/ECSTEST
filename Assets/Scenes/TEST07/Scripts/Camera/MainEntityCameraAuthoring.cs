using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Burst;

public struct MainEntityCamera : IComponentData
{
    public float Offset;
}

//GameObject��2�ȏ㓯���R���|�[�l���g���A�^�b�`�ł��Ȃ��悤�ɂ���
[DisallowMultipleComponent]
public class MainEntityCameraAuthoring : MonoBehaviour
{
    public class Baker : Baker<MainEntityCameraAuthoring>
    {
        public override void Bake(MainEntityCameraAuthoring authoring)
        {
            var data=new MainEntityCamera();
            AddComponent(GetEntity(TransformUsageFlags.Dynamic), data);
        }
    }
}