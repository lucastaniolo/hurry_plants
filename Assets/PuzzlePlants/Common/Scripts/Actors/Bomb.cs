// Add timer to explode the bomb
// Countdown starts as soon as a player picks up the bomb
// Time to explode varies, designer must be able to set it via inspector
// Countdown must have a visual feedback (not defined yet)
// Bomb respawn after explosion, unless it explodes a crate
// Explosion affects nearby actors:
// - Player: kill and respawn
// - HumanNPC: kill and respawn
// - Other bomb: explode and respawn
// - Crate (objective): destroy

using System.Collections;
using TMPro;
using UnityEngine;

public class Bomb : PickUpElement<Crate>
{
    [SerializeField] private int timeToExplode;
    [SerializeField] private TextMeshPro countdownLabel;
    
    private int timer;
    private Transform label;
    private Transform cameraTransform;

    protected override KillType KillType => KillType.Bomb;
    
    private void Start()
    {
        countdownLabel.gameObject.SetActive(false);
        label = countdownLabel.transform;
        cameraTransform = FindObjectOfType<Camera>().transform;
        timer = timeToExplode;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        countdownLabel.gameObject.SetActive(false);
        timer = timeToExplode;
        countdownLabel.text = timeToExplode.ToString();
    }
    
    protected override void OnPick()
    {
        countdownLabel.gameObject.SetActive(true);
        countdownLabel.text = timeToExplode.ToString();
        
        if (timer == timeToExplode)
            StartCoroutine(Countdown());
        
        base.OnPick();
    }

    private IEnumerator Countdown()
    {
        while (timer > 0)
        {
            timer--;
            countdownLabel.text = timer.ToString();
            yield return new WaitForSeconds(1);
        }
        
        Respawner.Register();
        Instantiate(HitFx, transform.position, Quaternion.identity);
        Pickable.GetRelease();
    }

    private void Update()
    {
        if (!label.gameObject.activeInHierarchy) return;

        var heading = transform.position - cameraTransform.position;
        label.LookAt(heading);
    }
}
