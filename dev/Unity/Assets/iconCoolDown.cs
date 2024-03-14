using UnityEngine;
using UnityEngine.UI;

public class iconCoolDown : MonoBehaviour
{
    [SerializeField] private playerController player;
    [SerializeField] private Image coolDownImg;

    void Start()
    {
        coolDownImg.fillAmount = 0;
    }

    void Update()
    {
        coolDownImg.fillAmount = player.activeCoolDown + (Time.time - player.nextActive - 1.0f);
    }
}
