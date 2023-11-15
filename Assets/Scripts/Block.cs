using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject destroyVFX;
    [SerializeField] Sprite[] breakeSprites;
    [SerializeField] int pointValue = 10;
    // [SerializeField] int maxHitToDestroy;
    [SerializeField] int timesBlockHit; // serialized for debug
    Session session;

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Breakable"))
        {
            timesBlockHit++;
            int maxHitToDestroy = breakeSprites.Length + 1;
            if (timesBlockHit >= maxHitToDestroy) DestroyBlock();
            else DisplayNextBreakSprite();
        }
    }

    private void DisplayNextBreakSprite()
    {
        int spriteIndex = timesBlockHit - 1;
        if (spriteIndex < 0) return;
        // Debug.Log(gameObject.name);
        GetComponent<SpriteRenderer>().sprite = breakeSprites[spriteIndex];
    }

    private void CountBreakableBlocks()
    {
        session = FindObjectOfType<Session>();
        if (CompareTag("Breakable"))
        {
            session.CountBlocks(); // each block in the scene calls this function
        }
    }

    private void DestroyBlock()
    {
        PlayDestroyAudio();
        // Debug.Log(collision.gameObject.name);
        session.DestroyedBlock(pointValue);
        SpawnDestroyVFX();
        Destroy(gameObject);
    }

    private void PlayDestroyAudio()
    {
        // this creates a new audio source component at the location we define
        // we play audio at the cameras location
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void SpawnDestroyVFX()
    {
        // if we dont pass position and rotation it will be instantiated at the position set inside vfx prefab
        GameObject vfx = Instantiate(destroyVFX, transform.position, transform.rotation);
        Destroy(vfx, 1f);
    }
}
