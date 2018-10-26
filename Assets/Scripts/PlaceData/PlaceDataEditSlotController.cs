using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace PlaceData.Edit
{
    public class PlaceDataEditSlotController : MonoBehaviour
    {
        public Action<Koma> OnSelect { private get; set; }
        List<Slot> _slotList = new List<Slot>();
        public void Add(Koma koma)
        {
            var obj = new GameObject();
            obj.transform.SetParent(transform, false);
            var slot = obj.AddComponent<Slot>();
            slot.OnSelect = OnSelectEvent;
            slot.Add(koma);
        }

        public void RemoveAll()
        {
            foreach (var slot in _slotList)
            {
                GameObject.Destroy(slot.gameObject);
            }
            _slotList.Clear();
        }

        public void Remove(Koma koma)
        {
            var slot = _slotList.FirstOrDefault(data => data.Koma == koma);
            if(slot == null)
                return;

            slot.OnSelect = null;
            _slotList.Remove(slot);
            GameObject.Destroy(slot);
        }

        void OnSelectEvent(Koma koma)
        {
            OnSelect.Call(koma);
        }
    }

    public class Slot : MonoBehaviour
    {
        public Koma Koma { get; private set; }
        public Action<Koma> OnSelect { private get; set; }

        void Awake()
        {
            gameObject.AddComponent<Image>();
            var button = gameObject.AddComponent<Button>();
            button.onClick.AddListener(() => {
                OnSelect.Call(Koma);
            });
        }

        public void Add(Koma koma)
        {
            Koma = koma;
            koma.transform.SetParent(transform, false);
            koma.transform.position = transform.position;
        }
    }
}
