//Created by Jorik Weymans 2021

using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [ExecuteAlways]
    public sealed class WheelItem : MonoBehaviour
    {

        private Image _Img;

        [SerializeField] private GodInfo _God = null;
        [SerializeField] private Sprite _Selected = null;
        [SerializeField] private Sprite _Unselected = null;
        public GodInfo God => _God;

        private void Awake()
        {
            _Img = GetComponent<Image>();
            if(_God != null)
                _Img.sprite = _God.SpriteUnselected;

        }

        private void OnEnable()
        {
            _Img = GetComponent<Image>();
            if (_God != null)
                _Img.sprite = _God.SpriteUnselected;

        }
        public void SelectItem(bool value)
        {
            if (_God == null)
            {
                _Img.sprite = value ? _Selected : _Unselected;
                return;
            }

            _Img.sprite = value ? _God.Sprite : _God.SpriteUnselected;
        }
        public void DisableItem(bool value)
        {
            if (_God == null) return;

            _Img.sprite = value ? _God.SpriteDisabled : _God.Sprite;
        }
    }

}
