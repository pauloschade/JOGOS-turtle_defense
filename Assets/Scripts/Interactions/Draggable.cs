using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Draggable : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler {

    [SerializeField] private int index;
    private GameObject placeHolder = null;
    private Spawner _spawner;

    void Start() {
      _spawner = GameObject.Find("_Scripts").GetComponent<Spawner>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
      _spawner.SelectTower(index);
      placeHolder = Instantiate(this.gameObject, this.transform.parent);
    }

    public void OnDrag(PointerEventData eventData) {
      placeHolder.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
      Destroy(placeHolder);
      _spawner.DetectSpawnPoint();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }
}