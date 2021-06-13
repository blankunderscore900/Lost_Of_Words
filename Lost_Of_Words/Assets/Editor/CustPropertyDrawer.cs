using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(ArrayLayout))]
public class CustPropertyDrawer : PropertyDrawer {

	// This custom property drawer of the arrayLayout class will make the 2D Array visable and customizable in the unity inspector
	public override void OnGUI(Rect position,SerializedProperty property,GUIContent label){
		// This variable is about naming the label based on what you name it in the main scripts that use the Arraylayout class
		EditorGUI.PrefixLabel(position,label);
		Rect newposition = position;
		newposition.y += 18f;
		// This data object will represent the height of the game board-2D boolean array
		SerializedProperty data = property.FindPropertyRelative("rows");
		if (data.arraySize != 14)
            data.arraySize = 14;
		//data.rows[0][]
		for(int j=0;j<14;j++){
			// this row object will represent the width of the game board-2D boolean array
			SerializedProperty row = data.GetArrayElementAtIndex(j).FindPropertyRelative("row");
			newposition.height = 18f;
			if(row.arraySize != 9)
				row.arraySize = 9;
			// The newposition variable showcase how much space there can between each row of booleans 
			newposition.width = position.width/9;
			for(int i=0;i<9;i++){
				EditorGUI.PropertyField(newposition,row.GetArrayElementAtIndex(i),GUIContent.none);
				newposition.x += newposition.width;
			}

			newposition.x = position.x;
			newposition.y += 18f;
		}
	}
	// This override function adjust the size of the Editor2D Array based on the x & y axis  
	public override float GetPropertyHeight(SerializedProperty property,GUIContent label){
		return 18f * 15;
	}
}
