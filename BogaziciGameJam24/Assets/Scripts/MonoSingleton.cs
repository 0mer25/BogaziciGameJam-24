using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static volatile T _instance;

    #region Static T Instance
    public static T Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType(typeof(T)) as T;

            return _instance;
        }
    }
    #endregion
}
