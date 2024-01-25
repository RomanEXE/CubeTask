using Config;
using DG.Tweening;
using UnityEngine;

namespace Cube
{
    public class Cube : MonoBehaviour
    {
        private void Start()
        {
            transform.DOMove(new Vector3(0, 0, GameConfig.Distance), GameConfig.Speed)
                .SetSpeedBased(true)
                .OnComplete(() => Actions.OnCubeEndMoving.Invoke(this));
        }
    }
}