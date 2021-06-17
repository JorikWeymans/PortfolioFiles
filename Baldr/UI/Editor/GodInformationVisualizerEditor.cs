//Created by Jorik Weymans 2021

using TMPro;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GodInformationVisualizer))]
[CanEditMultipleObjects]
public sealed class GodInformationVisualizerEditor : Editor
{
    private SerializedProperty _GodInfoProperty = null;

    private SerializedProperty _TxtGodNameProperty = null;
    private SerializedProperty _TxtGodNameRuneProperty = null;
    private SerializedProperty _TxtGodDescriptionProperty = null;
    private SerializedProperty _TxtGodFavorAmountProperty = null;

    private void OnEnable()
    {
        _GodInfoProperty = serializedObject.FindProperty("_Info");

        _TxtGodNameProperty = serializedObject.FindProperty("_TxtGodName");
        _TxtGodNameRuneProperty = serializedObject.FindProperty("_TxtGodNameRune");
        _TxtGodDescriptionProperty = serializedObject.FindProperty("_TxtGodDescription");
        _TxtGodFavorAmountProperty = serializedObject.FindProperty("_TxtGodFavorAmount");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(_GodInfoProperty);
        EditorGUILayout.Space(5.0f);

        EditorGUILayout.PropertyField(_TxtGodNameProperty);
        EditorGUILayout.PropertyField(_TxtGodNameRuneProperty);
        EditorGUILayout.PropertyField(_TxtGodDescriptionProperty);
        EditorGUILayout.PropertyField(_TxtGodFavorAmountProperty);

        if (GUILayout.Button("Update Info"))
        {
            SetText();
            Debug.Log("[GodInfoVisualizer] Update was successful, select child to see it.");
        }

        serializedObject.ApplyModifiedProperties();
    }

    public void SetText()
    {
        GodInfo info = (GodInfo)_GodInfoProperty.objectReferenceValue;

        TMP_Text txtGodName        = (TMP_Text) _TxtGodNameProperty.objectReferenceValue;
        TMP_Text txtGodNameRune    = (TMP_Text)_TxtGodNameRuneProperty.objectReferenceValue;
        TMP_Text txtGodDescription = (TMP_Text)_TxtGodDescriptionProperty.objectReferenceValue;
        TMP_Text txtGodFavorAmount = (TMP_Text)_TxtGodFavorAmountProperty.objectReferenceValue;

        if (txtGodName != null)
            txtGodName.text = info.Name;

        if (txtGodNameRune != null)
        {
            txtGodNameRune.text = info.Name;
            txtGodNameRune.characterSpacing = info.CharacterSpacing;
        }

        if (txtGodDescription != null)
            txtGodDescription.text = info.Description;

        if (txtGodFavorAmount != null)
            txtGodFavorAmount.text = info.Cost.ToString();
    }
}