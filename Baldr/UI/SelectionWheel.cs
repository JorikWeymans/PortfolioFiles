//Created by Jorik Weymans 2021

using UnityEditor;
using UnityEngine;
namespace UI
{
    public sealed class SelectionWheel : MonoBehaviour
    {
        [SerializeField] private GameObject _GOPointer = null;
        [SerializeField] private float _ThreshHold = 20.0f;

        [Header("wheel Items")]
        [SerializeField] private WheelItem _ItemTop = null;
        [SerializeField] private WheelItem _ItemRight = null;
        [SerializeField] private WheelItem _ItemBot = null;
        [SerializeField] private WheelItem _ItemLeft = null;

        [Space(5.0f)] 
        [SerializeField] private GodInformationVisualizer _Visualizer = null;

        private GodInfo _CurrentGod = null;
        public GodInfo CurrentGod => _CurrentGod == null ? _ItemLeft.God : _CurrentGod;
        public void UpdatePos(Vector2 mouseValue)
        {
            if (mouseValue.y > _ThreshHold)
            {
                SelectItem(_ItemTop);
                _GOPointer.transform.right = new Vector2(0, 1);
            }
            else if (mouseValue.y < -_ThreshHold)
            {
                SelectItem(_ItemBot);
                _GOPointer.transform.right = new Vector2(0, -1);

            }
            else if (mouseValue.x > _ThreshHold)
            {
                SelectItem(_ItemRight);
                _GOPointer.transform.right = new Vector2(1, 0);

            }
            else if (mouseValue.x < -_ThreshHold)
            {
                SelectItem(_ItemLeft);
                _GOPointer.transform.right = new Vector2(-1, 0);

            }
        }

        private void SelectItem(WheelItem item)
        {
            GodInfo info = item.God;
            if(info != null)
            {
                _Visualizer.SetText(info);
            }
            _CurrentGod = info;

            _ItemTop.SelectItem(_ItemTop == item);
            _ItemRight.SelectItem(_ItemRight == item);
            _ItemBot.SelectItem(_ItemBot == item);
            _ItemLeft.SelectItem(_ItemLeft == item);
        }
    }
}