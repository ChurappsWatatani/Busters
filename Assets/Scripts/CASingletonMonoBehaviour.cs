using UnityEngine;

public class CASingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T m_Instance;
	public static T instance {
		get {
			if (m_Instance == null) {
				m_Instance = (T)FindObjectOfType(typeof(T));

				if (m_Instance == null) {
					Debug.LogError (typeof(T) + "is nothing");
				}
			}

			return m_Instance;
		}
	}

	public void Awake ()
	{
		if (this != instance) {
			Destroy (this.gameObject);
			return;
		}

		DontDestroyOnLoad (this.gameObject);
	}

}