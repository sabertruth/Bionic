using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video_Quality_Manager : MonoBehaviour
{
    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }


}
