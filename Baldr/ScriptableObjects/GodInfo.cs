//Created by Jorik Weymans 2021

using UnityEngine;

[CreateAssetMenu(fileName = "new GodInfo", menuName = "GodInfo")]
public sealed class GodInfo : ScriptableObject
{
    [SerializeField] private string _Name = "New God";
    [SerializeField] [TextArea(3, 4)] private string _Description = "God Description";
    [SerializeField] private float _Cost = 200.0f;
    [SerializeField] private float _CharacterSpacing = 300.0f;
    [Space(5)] 
    [SerializeField] private GameObject _StatuePrefab = null;

    [Header("Sprites")]
    [SerializeField] private Sprite _Sprite = null;
    [SerializeField] private Sprite _SpriteUnselected = null;
    [SerializeField] private Sprite _SpriteDisabled = null;
    public string Name => _Name;
    public string Description => _Description;
    public float Cost => _Cost;
    public float CharacterSpacing => _CharacterSpacing;

    public GameObject StatuePrefab => _StatuePrefab;
    public Sprite Sprite => _Sprite;
    public Sprite SpriteUnselected => _SpriteUnselected;
    public Sprite SpriteDisabled=> _SpriteDisabled;


}