using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DISystem : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private DamageIndicator indicatorPrefab = null;
    [SerializeField] private RectTransform holder = null;
    [SerializeField] private new Camera camera = null;
    [SerializeField] private Transform player = null;

    private Dictionary<Transform, DamageIndicator> Indicators = new Dictionary<Transform, DamageIndicator>();

    #region Delegates
    public static Action<Transform> CreateIndicator = delegate{ };
    public static Func<Transform, bool> CheckIfObjectInSight = null;
    #endregion

    private void OnEnable()
    {
        CreateIndicator += Create;
        CheckIfObjectInSight += Insight;
    }

    private void onDisable()
    {
        CreateIndicator -= Create;
        CheckIfObjectInSight -= Insight;
    }
    void Create(Transform target)
    {
        if(Indicators.ContainsKey(target))
        {
            Indicators[target].Restart();
            return;
        }
        DamageIndicator newIndicator = Instantiate(indicatorPrefab, holder);
        newIndicator.Register(target, player, new Action( () => {Indicators.Remove(target);} ));

        Indicators.Add(target, newIndicator);
    }
    bool Insight(Transform t)
    {
        Vector3 screenPoint = camera.WorldToViewportPoint(t.position);
        return screenPoint.z > 0 && screenPoint.x > 00 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
    }
}
