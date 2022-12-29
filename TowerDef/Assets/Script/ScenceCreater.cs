using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenceCreater : MonoBehaviour
{
    [SerializeField]
    private Camera main_camera;

    [Header("map Settings")]
    [SerializeField]
    private uint length_num;
    [SerializeField]
    private uint width_num;

    [Header("unit Settings")]
    [SerializeField]
    private float unit_length;
    [SerializeField]
    private float unit_width;
    [SerializeField]
    private float unit_high;

    [Space(20)]
    [SerializeField]
    private GameObject unit_prefab;
    [SerializeField]
    private GameObject scencegroup;


    void Start()
    {
        var camera_pos = main_camera.transform.position;
        var prefab_x = -(length_num / 2 * unit_length - unit_length/2);
        var prefab_z = camera_pos.z + 5f;

        for (int i = 0, length_max = (int)length_num; i < length_max; i++)
        {
            prefab_x += unit_length * i;

            for (int j = 0, width_max = (int)width_num; j < width_max; j++)
            {
                prefab_z += unit_width * j;

                var target_prefab = Instantiate(unit_prefab);
                target_prefab.transform.localScale = new Vector3(unit_length, unit_high, unit_width);
                target_prefab.transform.position = new Vector3(prefab_x, 0, prefab_z);
                target_prefab.transform.parent = scencegroup.transform;
            }

            prefab_x = -(length_num / 2 * unit_length - unit_length / 2);
            prefab_z = camera_pos.z + 5f;
        }
    }

    void Update()
    {

    }
}
