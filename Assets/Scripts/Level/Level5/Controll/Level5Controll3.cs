using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Level5Controll3 : MonoBehaviour
{
    public GameObject roudian4;
    public GameObject roudian7;
    public string script;
    public GameObject UIimage;
    public GameObject sun;
    public GameObject moon;
    public GameObject blood1;
    public GameObject blood2;
    public GameObject blood3;
    public GameObject blood4;

    public void judge3()
    {
        UIimage.SetActive(false);
        if (roudian7.transform.position.x <= Level5Model.Instance.xLimitMax3 && roudian7.transform.position.x >= Level5Model.Instance.xLimitMin3)

        {
            MonoBehaviour targetScript = (MonoBehaviour)roudian4.GetComponent(script);
            targetScript.enabled = true;
            sun.SetActive(false);
            moon.SetActive(true);
            blood1.SetActive(false);
            blood2.SetActive(false);
            blood3.SetActive(false);
            blood4.SetActive(false);
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
            roudian4PosX = roudian4.transform.position.x,
            roudian4PosY = roudian4.transform.position.y,
            roudian4PosZ = roudian4.transform.position.z,

            roudian7PosX = roudian7.transform.position.x,
            roudian7PosY = roudian7.transform.position.y,
            roudian7PosZ = roudian7.transform.position.z,

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
        public float roudian4PosX;
        public float roudian4PosY;
        public float roudian4PosZ;

        public float roudian7PosX;
        public float roudian7PosY;
        public float roudian7PosZ;

        public bool moonActive;
        public bool sunActive;
        public bool[] bloodActives;
    }
}