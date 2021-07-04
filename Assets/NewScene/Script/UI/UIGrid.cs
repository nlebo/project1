using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GridType
{
    Vertical = 0,
    Horizontal = 1,

}

public enum Pivot
{
    Center = 0,
    Left = 1,
    Right = 2,
    Top = 3,
    Bottom = 4,
}

public class UIGrid : MonoBehaviour
{

    [Tooltip("'0' is infinite")]public int Line;
    public Vector2 Size;

    public GridType type;
    public Pivot pivot;

    public ScrollRect scrollrect;

    public Vector2 NowPos;
    Vector2 PivotPos;

	private void Start()
	{
        NowPos = Vector2.zero;
        PivotPos = Vector2.zero;

        EventManager.Instance.AddUpdateManager(ResetPosition);
    }

    void UpdateGrid()
    {
        EventManager.Instance.AddUpdateManager(ResetPosition);
    }

    void ResetPosition()
    {
        int ChildCount = transform.childCount;
        int cnt = 0;
        NowPos = Vector2.zero;

        for (int i = 0; i < ChildCount; i++)
		{
			RectTransform T = transform.GetChild(i).GetComponent<RectTransform>();

			if (T == null || T.gameObject.activeInHierarchy == false)
				continue;

			PivotPos = GetPivotPos(T.sizeDelta);

			Vector2 InstantPos = NowPos + PivotPos;

			T.localPosition = InstantPos;

			cnt = Line == cnt ? 1 : cnt + 1;
			if (i + 1 < ChildCount)
				NowPos = GetNextPos(cnt);

		}

		if (scrollrect != null)
			scrollrect.content.sizeDelta = NowPos;
		EventManager.Instance.DeleteUpdateManager(ResetPosition);

    }

    Vector2 GetPivotPos(Vector2 pos)
    {
        Vector2 piv = Vector2.zero;
        switch (pivot)
        {
            case Pivot.Center:
                {
                    piv = Vector2.zero;
                }
                break;
            case Pivot.Left:
                {
                    piv.x = (pos.x / 2);
                }
                break;
            case Pivot.Right:
                {
                    piv.x = -(pos.x / 2);
                }
                break;
            case Pivot.Top:
                {
                    piv.y = -(pos.y / 2);
                }
                break;
            case Pivot.Bottom:
                {
                    piv.y = (pos.y / 2);
                }
                break;
        }

        return piv;
    }
    Vector2 GetNextPos(int cnt)
	{
		Vector2 normal = Vector2.zero, change = Vector2.zero;
        Vector2 result = Vector2.zero;
        Vector2 Now = NowPos;

		switch (type)
		{
            case GridType.Vertical:
                normal.y = -1;
                change.x = 1;
                break;
            case GridType.Horizontal:
                normal.x = 1;
                change.y = -1;
                break;
        }

        if (Line != 0 && Line == cnt)
        {
            result = change * Size;
            Now = Now * -change;

        }
        else
        {
            result = normal * Size;
        }

        result += Now;

        return result;

    }
}
