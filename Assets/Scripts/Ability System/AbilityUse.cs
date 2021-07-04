using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.Globalization;

[RequireComponent(typeof(AudioSource))]
public class AbilityUse : MonoBehaviour
{
    public Ability ability;

    public GameObject self;
    public GameObject target;

    public Button buttonCastSkill;
    public Text cooldownText;
    public Image cooldownBackground;
    public Button coverCooldownBackground;

    [HideInInspector] public AudioSource audioSource;
    public AudioClip soundEffect;
    public ParticleSystem particleEffect;

    private Stopwatch cooldownTimer = new Stopwatch();



    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        ability = new Ability();

        SetActiveCooldownUI(false);
    }


    public void OnAbilityUse()
    {
        ability.UseAbility(self, target);

        buttonCastSkill.interactable = false;

        SetActiveCooldownUI(true);

        cooldownText.text = string.Format("{0:N1}", ability.cooldown);

        PlaySoundEffect();
        PlayParticleEffect();

        StartCoroutine(Cooldowning());

        if (ability.effectDuration > 0)
        {
            Ball selfBall = self.GetComponent<Ball>();
            selfBall.EffectDurationCooldown(ability.effectDuration);
        }
    }

    public IEnumerator Cooldowning()
    {
        cooldownTimer.Start();

        while (cooldownTimer.IsRunning && cooldownTimer.Elapsed.TotalSeconds < ability.cooldown)
        {
            float cooldownedPercentage = (float)(1 - cooldownTimer.Elapsed.TotalSeconds / ability.cooldown);
            HandleAnimationCooldownUI(cooldownedPercentage);

            yield return null;
        }

        buttonCastSkill.interactable = true;
        SetActiveCooldownUI(false);

        cooldownTimer.Stop();
        cooldownTimer.Reset();

        yield return null;
    }


    private void SetActiveCooldownUI(bool isActive)
    {
        cooldownText.gameObject.SetActive(isActive);
        cooldownBackground.gameObject.SetActive(isActive);
        coverCooldownBackground.gameObject.SetActive(isActive);
    }


    private void PlaySoundEffect()
    {
        audioSource.PlayOneShot(soundEffect);
    }

    private void PlayParticleEffect()
    {
        particleEffect.gameObject.transform.position = self.transform.position;
        particleEffect.Play();
    }

    private void HandleAnimationCooldownUI(float cooldownedPercentage)
    {
        float cooldowned = ability.cooldown * cooldownedPercentage;

        if (cooldowned > 1f)
        {
            cooldownText.text = string.Format("{0:N0}", cooldowned);
        }
        else
        {
            cooldownText.text = string.Format(new CultureInfo("en-US"), "{0:N1}", cooldowned);
        }
    }
}
