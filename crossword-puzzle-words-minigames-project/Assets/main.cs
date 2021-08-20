using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

internal static class main 
{
    public static UnityAction YesAction = ()=> { };//
    public static void tadam(this MonoBehaviour m)
    {
        YesAction.Invoke(); 
    }

    public static UnityAction ErrorAction = () => { };//
    public static void error(this MonoBehaviour m)
    {
        ErrorAction.Invoke(); 
    }

    public static UnityAction ClickAction = () => { };//
    public static void click(this MonoBehaviour m)
    {
        ClickAction.Invoke(); 
    }

    public static UnityAction NextLevelAction = () => { };//
    public static void nextlevel(this MonoBehaviour m)
    {
        NextLevelAction.Invoke(); 
    }
}
