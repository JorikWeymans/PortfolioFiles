//Created by Jorik Weymans 2021

using TMPro;
using UnityEngine;
using Utilities;
public sealed class GodInformationVisualizer : MonoBehaviour
{
#pragma warning disable 414
    [SerializeField] [Tooltip("Only used in editor")] private GodInfo _Info = null;
#pragma warning restore 414

    [SerializeField] private TMP_Text _TxtGodName = null;
    [SerializeField] private TMP_Text _TxtGodNameRune = null;
    [SerializeField] private TMP_Text _TxtGodDescription = null;
    [SerializeField] private TMP_Text _TxtGodFavorAmount = null;

    public void SetText(GodInfo info)
    {
        if(_TxtGodName != null)
            _TxtGodName.text = info.Name;

        if(_TxtGodNameRune != null)
            _TxtGodNameRune.text = info.Name;

        if (_TxtGodDescription != null)
            _TxtGodDescription.text = info.Description;

        if (_TxtGodFavorAmount != null)
            _TxtGodFavorAmount.text = info.Cost.ToString();
    }

}