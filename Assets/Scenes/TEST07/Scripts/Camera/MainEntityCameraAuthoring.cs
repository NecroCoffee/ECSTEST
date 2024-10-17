using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Burst;

public struct MainEntityCamera : IComponentData
{
    public float Offset;
}

//GameObjectに2つ以上同じコンポーネントをアタッチできないようにする
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