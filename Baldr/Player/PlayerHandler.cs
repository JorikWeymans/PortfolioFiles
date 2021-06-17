//Created by Jorik Weymans 2021

using UnityEngine;

public sealed class PlayerHandler : MonoBehaviour
{
    public bool IsPressingInteract { get; private set; } = false;

    private void OnStartInteract()
    {
        IsPressingInteract = true;
    }

    private void OnStopInteract()
    {
        IsPressingInteract = false;
    }
}