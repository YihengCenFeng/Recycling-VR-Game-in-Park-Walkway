using UnityEngine;

public class TrashBinSwitching : MonoBehaviour
{
    public int selectedTrashBin = 0;

    void Start()
    {
        SelectTrashBin();
    }

    void Update()
    {
        int previousSelectedTrashBin = selectedTrashBin;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (selectedTrashBin >= transform.childCount - 1)
                selectedTrashBin = 0;
            else
                selectedTrashBin++;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (selectedTrashBin >= transform.childCount - 1)
                selectedTrashBin = 0;
            else
                selectedTrashBin++;
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (selectedTrashBin >= transform.childCount - 1)
        //        selectedTrashBin = 0;
        //    else
        //        selectedTrashBin++;
        //}

        if (previousSelectedTrashBin != selectedTrashBin)
            SelectTrashBin();
    }

    void SelectTrashBin()
    {
        int i = 0;
        foreach(Transform trashBin in transform)
        {
            if (i == selectedTrashBin)
                trashBin.gameObject.SetActive(true);
            else
                trashBin.gameObject.SetActive(false);
            i++;
        }
    }
}


