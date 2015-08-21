using UnityEngine;

/// <summary>
/// Creating instance of particles from code with no effort
/// </summary>
public class SpecialEffectsHelper : MonoBehaviour
{
	/// <summary>
	/// Singleton
	/// </summary>
	public static SpecialEffectsHelper Instance;

	public ParticleSystem ExplosionEffect;
	
	void Awake()
	{
		// Register the singleton
		if (Instance != null) {
			Debug.LogError ("Multiple instances of SpecialEffectsHelper!");
		}
		
		Instance = this;
	} 

	
	public void Explosion(Vector3 position)
	{
		// Fire in the sky
		instantiate(ExplosionEffect, position);
	}
	
	/// <summary>
	/// Instantiate a Particle system from prefab
	/// </summary>
	/// <param name="prefab"></param>
	/// <returns></returns>
	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
	{
		ParticleSystem newParticleSystem = Instantiate(
			prefab,
			position,
			prefab.transform.rotation
			//Quaternion.identity
			) as ParticleSystem;
		// Make sure it will be destroyed
		Destroy(
			newParticleSystem.gameObject,
			newParticleSystem.startLifetime
			);
		
		return newParticleSystem;
	}
}