using UnityEngine;

public class CoinCollector : MonoBehaviour
{   
    [SerializeField] private CoinManager _coinManager;

    void Start()
    {
        if (_coinManager == null)
        {
            _coinManager = FindObjectOfType<CoinManager>();
            if (_coinManager == null)
            {
                Debug.LogError("CoinManager not found in the scene!");
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Moneta raccolta!");
            _coinManager.CollectCoin();
            Destroy(gameObject);
        }
    }
}
