using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP_Bar : MonoBehaviour
{
    public Image hpImage;
    public Image shieldImage;
    public HealthController HealthController;

    private float maxHp;
    private float maxShield;
    // Start is called before the first frame update
    void Start()
    {
        maxHp = HealthController.MaxHP;
        maxShield = HealthController.MaxShield;
    }

    // Update is called once per frame
    void Update()
    {
        hpImage.fillAmount = HealthController.MHp / maxHp;
        shieldImage.fillAmount = HealthController.MShield / maxShield;
    }
    public void Resume()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
