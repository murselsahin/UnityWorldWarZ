using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
# endif



public class LevelTasarimiKontrol : MonoBehaviour
{

    public GameObject zombi1, zombi2, zombi3, zombi4, zombi5, zombiler;

    void Start()
    {

    }


    void Update()
    {

    }

    public Vector2 GetPozisyon()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }

    public void SetPoziyon(float y)
    {
        transform.position = new Vector3(transform.position.x, y, 0);
    }

    public GameObject GetZombi1()
    {
        return zombi1;
    }
    public GameObject GetZombi2()
    {
        return zombi2;
    }
    public GameObject GetZombi3()
    {
        return zombi3;
    }
    public GameObject GetZombi4()
    {
        return zombi4;
    }
    public GameObject GetZombi5()
    {
        return zombi5;
    }
   

    public Transform GetTransform()
    {
        return zombiler.transform;
    }

    public void YerDegistir(float x)
    {
        transform.position = new Vector3(transform.position.x + x, transform.position.y, 0);
    }
    
}
   

#if UNITY_EDITOR
[CustomEditor(typeof(LevelTasarimiKontrol))]
[System.Serializable]

class LevelTasarimEditor : Editor
{
    public override void OnInspectorGUI()
    {
        LevelTasarimiKontrol script = (LevelTasarimiKontrol)target;
        
        if (GUILayout.Button("1.Sıraya Git", GUILayout.MinWidth(100), GUILayout.Width(100)))
        {
            script.SetPoziyon(1.47f);
        }
        if (GUILayout.Button("2.Sıraya Git", GUILayout.MinWidth(100), GUILayout.Width(100)))
        {
            script.SetPoziyon(0.48f);
        }
        if (GUILayout.Button("3.Sıraya Git", GUILayout.MinWidth(100), GUILayout.Width(100)))
        {
            script.SetPoziyon(-0.514f);
        }
        if (GUILayout.Button("4.Sıraya Git", GUILayout.MinWidth(100), GUILayout.Width(100)))
        {
            script.SetPoziyon(-1.497f);
        }
        if (GUILayout.Button("5.Sıraya Git", GUILayout.MinWidth(100), GUILayout.Width(100)))
        {
            script.SetPoziyon(-2.477f);
        }

        if (GUILayout.Button("Zombi 1 Üret", GUILayout.MinWidth(100), GUILayout.Width(100)))
        {
            GameObject yeniObjem = Instantiate(script.GetZombi1(), Vector3.zero, Quaternion.identity);
            yeniObjem.transform.position = script.GetPozisyon();
            yeniObjem.transform.parent = script.GetTransform();
            yeniObjem.name = "Zombi1";
        }
        if (GUILayout.Button("Zombi 2 Üret", GUILayout.MinWidth(100), GUILayout.Width(100)))
        {
            GameObject yeniObjem = Instantiate(script.GetZombi2(), Vector3.zero, Quaternion.identity);
            yeniObjem.transform.position = script.GetPozisyon();
            yeniObjem.transform.parent = script.GetTransform();
            yeniObjem.name = "Zombi2";
        }
        if (GUILayout.Button("Zombi 3 Üret", GUILayout.MinWidth(100), GUILayout.Width(100)))
        {
            GameObject yeniObjem = Instantiate(script.GetZombi3(), Vector3.zero, Quaternion.identity);
            yeniObjem.transform.position = script.GetPozisyon();
            yeniObjem.transform.parent = script.GetTransform();
            yeniObjem.name = "Zombi3";
        }
        if (GUILayout.Button("Zombi 4 Üret", GUILayout.MinWidth(100), GUILayout.Width(100)))
        {
            GameObject yeniObjem = Instantiate(script.GetZombi4(), Vector3.zero, Quaternion.identity);
            yeniObjem.transform.position = script.GetPozisyon();
            yeniObjem.transform.parent = script.GetTransform();
            yeniObjem.name = "Zombi4";
        }
        if (GUILayout.Button("Zombi 5 Üret", GUILayout.MinWidth(100), GUILayout.Width(100)))
        {
            GameObject yeniObjem = Instantiate(script.GetZombi5(), Vector3.zero, Quaternion.identity);
            yeniObjem.transform.position = script.GetPozisyon();
            yeniObjem.transform.parent = script.GetTransform();
            yeniObjem.name = "Zombi5";
        }
        if (GUILayout.Button("Sağ Git", GUILayout.MinWidth(100), GUILayout.Width(100)))
        {
            script.YerDegistir(1f);
        }
        if (GUILayout.Button("Sol Git", GUILayout.MinWidth(100), GUILayout.Width(100)))
        {
            script.YerDegistir(-1f);
        }



        EditorGUILayout.PropertyField(serializedObject.FindProperty("zombi1"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("zombi2"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("zombi3"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("zombi4"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("zombi5"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("zombiler"));
        serializedObject.ApplyModifiedProperties();
        serializedObject.Update();
    }

}
#endif
