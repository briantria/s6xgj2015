/*
 * developer     : brian g. tria
 * creation date : 2015.11.04
 * 
 */

using UnityEngine;
using UnityEditor;
using System.Collections;

public class DesignGrid : EditorWindow 
{
	private Vector2 m_v2GridSize = Vector2.one;
	string m_strGridX = "15";
	string m_strGridY = "10";

	void OnGUI ()
	{
		GUILayout.Label ("Column Count:");
		m_strGridX = GUILayout.TextField (m_strGridX);
		
		GUILayout.Label ("Row Count:");
		m_strGridY = GUILayout.TextField (m_strGridY);
		
		int iGridColCount, iGridRowCount;
		if (int.TryParse (m_strGridX, out iGridColCount) && int.TryParse (m_strGridY, out iGridRowCount))
		{
			m_v2GridSize.x = iGridColCount;
			m_v2GridSize.y = iGridRowCount;
			
			if (GUILayout.Button ("Create Grid"))
			{
				//Debug.Log ("Create Grid: " + Constants.SortingLayerNames [0]);
				GameObject gridContainer = GameObject.Find ("GridContainer");
				if (gridContainer == null)
				{
					gridContainer = new GameObject ("GridContainer");
				}
				
				for (int iRowIdx = 0; iRowIdx < iGridColCount; ++iRowIdx)
				{
					for (int iColIdx = 0; iColIdx < iGridRowCount; ++iColIdx)
					{
						TileData td = ScriptableObject.CreateInstance <TileData>();
						td.AddTo (gridContainer.transform, new Vector2 (iRowIdx, iColIdx));
					}
				}
			}
		}
	}
}