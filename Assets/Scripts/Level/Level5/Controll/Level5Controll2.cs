using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Level5Controll2 : MonoBehaviour
{
    public GameObject roudian3;
    public GameObject roudian6;
    public string script;
    public GameObject UIimage;
    public GameObject sun;
    public GameObject moon;
    public GameObject blood1;
    public GameObject blood2;
    public GameObject blood3;
    public GameObject blood4;

    public void judge2()
    {
        UIimage.SetActive(false);
        if (roudian6.transform.position.x <= Level5Model.Instance.xLimitMax2 && roudian6.transform.position.x >= Level5Model.Instance.xLimitMin2)

        {
            MonoBehaviour targetScript = (MonoBehaviour)roudian3.GetComponent(script);
            targetScript.enabled = true;
            sun.SetActive(true);   
            moon.SetActive(false);
            blood1.SetActive(true);
            blood2.SetActive(true);
            blood3.SetActive(true);
            blood4.SetActive(true);
            SaveLevel5Data();
        }
        else
        {
            SceneManager.LoadScene(6);
        }
    }
    private void SaveLevel5Data()
    {
        Level5SaveData data = new Level5SaveData
        {
            roudian3PosX = roudian3.transform.position.x,
            roudian3PosY = roudian3.transform.position.y,
            roudian3PosZ = roudian3.transform.position.z,

            roudian6PosX = roudian6.transform.position.x,
            roudian6PosY = roudian6.transform.position.y,
            roudian6PosZ = roudian6.transform.position.z,

            moonActive = moon.activeSelf,
            sunActive = sun.activeSelf,
            bloodActives = new bool[]
            {
            blood1.activeSelf,
            blood2.activeSelf,
            blood3.activeSelf,
            blood4.activeSelf
            }
        };

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/level5.dat";
        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            formatter.Serialize(stream, data);
        }

        Debug.Log("Level5 数据已保存！");
    }

    [System.Serializable]
    public class Level5SaveData
    {
        public float roudian3PosX;
        public float roudian3PosY;
        public float roudian3PosZ;

        public float roudian6PosX;
        public float roudian6PosY;
        public float roudian6PosZ;

        public bool moonActive;
        public bool sunActive;
        public bool[] bloodActives;
    }

}