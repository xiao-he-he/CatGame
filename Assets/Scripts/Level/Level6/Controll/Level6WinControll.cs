using System.Collections;
using UnityEngine;
using View.Select;

public class Level6WinControll : MonoBehaviour
{
    public bool Time = true;
    public GameObject WinUI;    // ʤ��ʱ��ʾ��UI����
    public GameObject Cat;      // ʧ��ʱ��ʾ��è����
    public float checkDelay = 5f; // ����ӳ�ʱ��(��)

    private void Start()
    {
        StartCoroutine(CheckDoorStatusAfterDelay());
    }
    public void Update()
    {
        if (Level6Model.Instance.IsDoor&&Time)
        {
            ShowWinUI();
        }
    }
    private IEnumerator CheckDoorStatusAfterDelay()
    {
        // �ȴ�ָ��ʱ��
        yield return new WaitForSeconds(checkDelay);

        // �����״̬

        
        if(Level6Model.Instance.IsDoor== false)
        {
            Time = false;
            ShowCat();
        }


        
    }

    private void ShowWinUI()
    {

        EndUI.WinUI(Resources.Load<Sprite>("Image/Win/Level6S"));


    }

    private void ShowCat()
    {
            Cat.SetActive(true);

        
    }
}
