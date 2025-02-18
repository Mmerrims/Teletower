using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip JumpingSFX;
    public AudioClip JumpLandSFX;
    public AudioClip BallRefillSFX;
    public AudioClip TeleportSFX;
    public AudioClip BallThrowSFX;
    public AudioClip BlockPlaceSFX;
    public GameObject MoveSFX;
    public GameObject BobDeathMusicSFX;
    public GameObject GameThemeSFX;
    public AudioClip BobDeathSFX;
    public AudioClip ClickSFX;
    public AudioClip WinSFX;
    public AudioClip PlayerSpawnSFX;
    public void Jump()
    {
        audioSource.PlayOneShot(JumpingSFX);
    }
    public void JumpLand()
    {
        audioSource.PlayOneShot(JumpLandSFX);
    }
    public void Move()
    {
        MoveSFX.SetActive(true);
    }
    public void MoveStop()
    {
        MoveSFX.SetActive(false);
    }
    public void BallRefill()
    {
        audioSource.PlayOneShot(BallRefillSFX);
    }
    public void Teleport()
    {
        audioSource.PlayOneShot(TeleportSFX);
    }
    public void BallThrow()
    {
        audioSource.PlayOneShot(BallThrowSFX);
    }
    public void BlockPlace()
    {
        audioSource.PlayOneShot(BlockPlaceSFX);
    }
    public void BobDeathMusic()
    {
        BobDeathMusicSFX.SetActive(true);
    }
    public void BobDeath()
    {
        audioSource.PlayOneShot(BobDeathSFX);
    }   
    public void Win()
    {
        audioSource.PlayOneShot(WinSFX);
    }
    public void PlayerSpawn()
    {
        audioSource.PlayOneShot(PlayerSpawnSFX);
    }
    public void Click()
    {
        audioSource.PlayOneShot(ClickSFX);
    }
    public void GameTheme()
    {
        GameThemeSFX.SetActive(true);
    }
}
