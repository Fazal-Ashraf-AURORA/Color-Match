using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [Header("GameObjects References")]
    [SerializeField] GameObject player;
    [SerializeField] Animator playerAnimator;


    public void PlayerTapped() {
        playerAnimator.SetTrigger("Tapped");
        Debug.Log("Tapped");
    }
    
}
