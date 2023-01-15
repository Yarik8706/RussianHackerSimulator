using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BugOnSaitController : MonoBehaviour, IPointerClickHandler
{
    public Transform onePoint;
    public Transform twoPoint;
    public HackSaitController hackSaitController;
    private Image _image;
    private Tween _activeTween;

    public void StartGame()
    {
        _activeTween = transform.DOMove(twoPoint.position, 1f).OnComplete(GotoOne);
    }

    public void GotoOne()
    {
        _activeTween = transform.DOMove(onePoint.position, 1f).OnComplete(StartGame);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _activeTween.Kill();
        HackSaitController.bugsCount += 1;
        _image.DOFade(0f, 1f).OnKill(() => Destroy(gameObject));
    }
}