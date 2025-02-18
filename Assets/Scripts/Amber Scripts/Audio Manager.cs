using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
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
    public void Jump() // done
    {
        audioSource.PlayOneShot(JumpingSFX);
    }
    public void JumpLand() // done
    {
        audioSource.PlayOneShot(JumpLandSFX);
    }
    public void Move() // done
    {
        MoveSFX.SetActive(true);
    }
    public void MoveStop() // done
    {
        MoveSFX.SetActive(false);
    }
    public void BallRefill() // done
    {
        audioSource.PlayOneShot(BallRefillSFX);
    }
    public void Teleport() // done
    {
        audioSource.PlayOneShot(TeleportSFX);
    }
    public void BallThrow() // done
    {
        audioSource.PlayOneShot(BallThrowSFX);
    }
    public void BlockPlace() // done
    {
        audioSource.PlayOneShot(BlockPlaceSFX);
    }
    public void BobDeathMusic() // done
    {
        BobDeathMusicSFX.SetActive(true);
    }
    public void BobDeath() // done
    {
        audioSource.PlayOneShot(BobDeathSFX);
    }   
    public void Win() // done
    {
        audioSource.PlayOneShot(WinSFX);
    }
    public void PlayerSpawn() // done
    {
        audioSource.PlayOneShot(PlayerSpawnSFX);
    }
    public void Click()
    {
        audioSource.PlayOneShot(ClickSFX);
    }
    public void GameTheme() // done
    {
        GameThemeSFX.SetActive(true);
    }
    public void GameThemeEnd() // done
    {
        GameThemeSFX.SetActive(false);
    }
}
