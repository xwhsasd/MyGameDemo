using System.Collections;
using UnityEngine;
using Cinemachine;
using TMPro;

public class EntityFX : MonoBehaviour
{
    protected Player player;
    protected SpriteRenderer sr;

    [Header("Pop up Text")]
    [SerializeField] private GameObject popUpTextPrefab;

    [Header("Flash FX")]
    [SerializeField] private float flashDuration;
    [SerializeField] private Material hitMat;
    private Material originalMat;

    [Header("Ailmnet colors")]
    [SerializeField] private Color[] chillColor;
    [SerializeField] private Color[] igniteColor;
    [SerializeField] private Color[] shockColor;

    [Header("Aliment particles")]
    [SerializeField] private ParticleSystem igniteFX;
    [SerializeField] private ParticleSystem chillFX;
    [SerializeField] private ParticleSystem shockFX;

    [Header("Hit FX")]
    [SerializeField] private GameObject hitFx;
    [SerializeField] private GameObject criticalHitFx;

    private GameObject myHealthBar = null;


    protected virtual void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        player = PlayerManager.instance.player;
        originalMat = sr.material;
        if(GetComponentInChildren<UI_HealthBar>() != null)
            myHealthBar = GetComponentInChildren<UI_HealthBar>().gameObject;
        
        CancelColorBlink();

    }



    public void CreatePopUpText(string _text)
    {
        float randomX = Random.Range(-1, 1);
        float randomY = Random.Range(0, 1.5f);

        Vector3 positionOffset = new Vector3(randomX, randomY, 0);

        GameObject newText = Instantiate(popUpTextPrefab, transform.position + positionOffset, Quaternion.identity);

        newText.GetComponent<TextMeshPro>().text = _text;
    }

    public void MakeTransprent(bool _transprent)
    {
        if (_transprent)
        {
            myHealthBar.SetActive(false);
            sr.color = Color.clear;
        }
        else
        {
            myHealthBar.SetActive(true);
            sr.color = Color.white;
        }
    }

    private IEnumerator FlashFX()
    {
        sr.material = hitMat;
        Color currentColor = sr.color;
        sr.color = Color.white;

        yield return new WaitForSeconds(flashDuration);

        sr.color = currentColor;
        sr.material = originalMat;
    }

    private void RedColorBlink()
    {
        if (sr.color != Color.white)
        {
            sr.color = Color.white;
        }
        else
        {
            sr.color = Color.red;
        }
    }

    private void CancelColorBlink()
    {
        CancelInvoke();
        sr.color = Color.white;

        chillFX.Stop();
        igniteFX.Stop();
        shockFX.Stop();

    }

    public void ChillFxFor(float _seconds)
    {
        chillFX.Play();

        InvokeRepeating("ChillColorFx", 0, .3f);
        Invoke("CancelColorBlink", _seconds);
    }

    public void IgniteFxFor(float _seconds)
    {
        igniteFX.Play();

        InvokeRepeating("IgnitColorFx", 0, .3f);
        Invoke("CancelColorBlink", _seconds);
    }

    public void ShockFxFor(float _seconds)
    {
        shockFX.Play();

        InvokeRepeating("ShockColorFx", 0, .3f);
        Invoke("CancelColorBlink", _seconds);
    }

    private void IgnitColorFx()
    {
        if (sr.color != igniteColor[0])
            sr.color = igniteColor[0];
        else
            sr.color = igniteColor[1];
    }
    private void ShockColorFx()
    {
        if (sr.color != shockColor[0])
            sr.color = shockColor[0];
        else
            sr.color = shockColor[1];
    }

    private void ChillColorFx()
    {
        if (sr.color != chillColor[0])
            sr.color = chillColor[0];
        else
            sr.color = chillColor[1];
    }

    public void CreateHitFx(Transform _target, bool _critical)
    {
        float zRotation = Random.Range(-90, 90);
        float xPosition = Random.Range(-.5f, .5f);
        float yPosition = Random.Range(-.5f, .5f);

        Vector3 hitFxRotaion = new Vector3(0, 0, zRotation);

        GameObject hitPrefab = hitFx;

        if (_critical)
        {
            hitPrefab = criticalHitFx;

            float yRotation = 0;
            zRotation = Random.Range(-45, 45);

            if (GetComponent<Entity>().facingDir == -1)
                yRotation = 180;

            hitFxRotaion = new Vector3(0, yRotation, zRotation);

        }

        GameObject newHitFx = Instantiate(hitPrefab, _target.position + new Vector3(xPosition, yPosition), Quaternion.identity); // uncomment this if you want particle to follow target ,_target);
        newHitFx.transform.Rotate(hitFxRotaion);
        Destroy(newHitFx, .5f);
    }


}
