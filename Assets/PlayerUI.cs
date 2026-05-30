using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] Image playerImage;

    [SerializeField] Sprite playerStandardImage;
    [SerializeField] Sprite playerDeathImage;
    [SerializeField] Sprite playerBoostImage;

    [SerializeField] GameObject boostEffect;

    [SerializeField] DOTweenAnimation shakeAnimaiton;

    private void Start()
    {
        shakeAnimaiton = GetComponent<DOTweenAnimation>();
    }

    public void PlayerDeadIcon()
    {
        playerImage.sprite = playerDeathImage;
        UITweenNotify();
        
    }
    public void PlayerBoostReady()
    {
        playerImage.sprite = playerBoostImage;
        UITweenNotify();
        boostEffect.SetActive(true);
    }
    public void PlayerBoostUnready()
    {
        playerImage.sprite = playerStandardImage;
        boostEffect.SetActive(false);
    }
    private void UITweenNotify()
    {
        shakeAnimaiton.DOPlay();
    }
}
