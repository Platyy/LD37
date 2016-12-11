using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleAnim : MonoBehaviour {


	void Update ()
    {
        transform.DOScale(2, 0.5f).SmoothRewind();
	}
}
