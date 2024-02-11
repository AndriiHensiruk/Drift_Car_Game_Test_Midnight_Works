using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsManager : MonoBehaviour
{
    [SerializeField] private BodyPartData[] bodyPartDataArray;

    public enum BodyPartType{
        FrontBumper,
        Wheels,
        RearBumper,
        Skirt,
        Spoiler

    }

    [System.Serializable]
    public class BodyPartData
    {
        public BodyPartType bodyPartType;
        public Mesh[] meshArray;
        public SkinnedMeshRenderer skinnedMeshRenderer;
    }

    public void ChangeCarPart(BodyPartType bodyPartType)
    {
        BodyPartData bodyPartData = GetBodyPartData(bodyPartType);
        int meshIndex = System.Array.IndexOf(bodyPartData.meshArray, bodyPartData.skinnedMeshRenderer.sharedMesh);
        bodyPartData.skinnedMeshRenderer.sharedMesh = bodyPartData. meshArray[(meshIndex + 1) % bodyPartData.meshArray.Length];
    }

    private BodyPartData GetBodyPartData(BodyPartType bodyPartType)
    {
        foreach (BodyPartData bodyPartData in bodyPartDataArray)
        {
            if (bodyPartData.bodyPartType == bodyPartType){
                return bodyPartData;
            }
        }
        return null;
    }

   
}

