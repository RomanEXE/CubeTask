using System;
using Config;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Cube
{
    public class CubesSpawner : MonoBehaviour
    {
        [SerializeField] private AssetReference _cubeReference;

        private void OnEnable()
        {
            Actions.OnCubeEndMoving += Despawn;
        }

        private void OnDisable()
        {
            Actions.OnCubeEndMoving -= Despawn;
        }

        private void Start()
        {
            Spawn();
        }

        private async void Spawn()
        {
            while (true)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(GameConfig.Time));
                await Addressables.InstantiateAsync(_cubeReference);
            }
        }

        private void Despawn(Cube cube)
        {
            cube.transform.DOKill(cube);
            Addressables.Release(cube.gameObject);
        }
    }
}