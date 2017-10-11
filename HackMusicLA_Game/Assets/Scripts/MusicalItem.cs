using UnityEngine;
using System.Collections.Generic;

public enum Note 
{
	A,
	Bflat,B,
	C, Csharp,
	D, 
	Eflat, E,
	F, Fsharp,
	G, Gsharp
};

public enum Instrument
{
	Piano,
	Frog
};

[CreateAssetMenu(menuName = "Item")]
public class MusicalItem : ScriptableObject
{
	// Note that this musical item represents.
	[SerializeField]
	private Note note;
	public Note GetNote() { return note; }

	// Instrument that is playing the notes.
	[SerializeField]
	private Instrument instrument;
	public Instrument GetInstrument() { return instrument; }

	// Name of the item (used for GUI).
	[SerializeField]
    new private string itemName = "New Item";
	public string GetName() { return itemName; }

	// Sprite of item to be displayed in world.
	public Sprite icon = null;
	public Sprite GetIcon() { return icon; }

	// Prefab that this musical item belongs to.
	[SerializeField]
	private GameObject itemPrefab;

	// Audio clip with loaded data for picking this item up.
	[SerializeField]
	private AudioClip pickupClip;
	public void PlayPickupSound(Vector3 point) 
	{ 
		PlayClipAtPoint (pickupClip, point, false, 1, 0, 0, 0);
	}
	public void PlayJumpSound(Vector3 point)
	{
		PlayClipAtPoint (pickupClip, point, false, 1, 1, 1.5f, 5);
	}

	// Audio clip with loaded data for emanating about an object.
	[SerializeField]
	private AudioClip emanatingClip;
	public GameObject PlayEmanatingSound(Vector3 point)
	{
		return PlayClipAtPoint (emanatingClip, point, true, 0.5f, 1, 1.5f, 3);
	}

	// Play weak hit
	[SerializeField]
	private AudioClip weakClip;
	public void PlayWeakSound(Vector3 point)
	{
		PlayClipAtPoint (weakClip, point, false, 1, 0, 0, 0);
	}

	// Plays a sound at a specified location.
	public GameObject PlayClipAtPoint(AudioClip clip, Vector3 point, bool looping, float volume,
									  float spatialBlend, float minDistance, float maxDistance)
	{
		// Create an empty GameObject and attach an AudioSource to it.
		GameObject soundHolder = new GameObject("TempAudio");
		AudioSource audio = soundHolder.AddComponent<AudioSource> ();
		audio.clip = clip;

		// Set the location of the sound.
		soundHolder.transform.position = point;

		// Destroy the empty gameobject after clip time if not looping.
		if (looping) 
		{
			audio.loop = true;
		} 
		else 
		{
			Destroy(soundHolder, clip.length);
		}

		// Set other miscellaneous audiosource properties.
		audio.rolloffMode = AudioRolloffMode.Linear;
		audio.dopplerLevel = 0; // holy fuck if this was 1 everything would sound HORRIBLE.
		audio.volume = volume;
		audio.spatialBlend = spatialBlend;
		if (minDistance != 0) audio.minDistance = minDistance;
		if (maxDistance != 0) audio.maxDistance = maxDistance;

		// Play the sound
		audio.Play();

		return soundHolder;
	}

	public void SpawnGem(Vector3 position)
	{
		Instantiate (itemPrefab, position, Quaternion.identity);
	}

    public virtual void Use()
    {
        //Debug.Log("Using " + name);
        Inventory.instance.currentSelected = this;
		PlayPickupSound (Vector3.zero);
    }
}