using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu (menuName ="Car Customize Asset")]
public class AssetCarSO : ScriptableObject
{
    
    public Material[] carColor;
    public MeshRenderer[] frontBumper;
    public MeshRenderer[] wheeles;
    public MeshRenderer[] rearBumper;
    public MeshRenderer[] skirt;
    public MeshRenderer[] spoiler;

}
