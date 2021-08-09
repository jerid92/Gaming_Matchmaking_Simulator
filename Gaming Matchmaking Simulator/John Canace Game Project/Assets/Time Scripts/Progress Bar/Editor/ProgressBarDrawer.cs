using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ProgressBar))]
public class ProgressBarDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        ProgressBar progressBar = (ProgressBar)attribute;


       //Are we a float?
        if (property.propertyType == SerializedPropertyType.Float)
        {
           
            
            label.tooltip = "Current Value of the Progress Bar";//if property is hidden this is not seen or used> try override show anyways
            
            //This is the default 0-1 bar
            if ((int) progressBar.max == 1 && (int) progressBar.min == 0)
            {
                float percent = property.floatValue * 100;
                EditorGUI.ProgressBar(position, (percent / 100), progressBar.label+ percent.ToString("f02"));
                //EditorGUI.LabelField(position, progressBar.label,EditorStyles.centeredGreyMiniLabel);
                //i love deana
            }
            else
            {
                //normalize the custom min mix  
                float fillamount = progressBar.NormalizedMinMax(property.floatValue,progressBar.min,progressBar.max);
                
                //Custom label
                string text = progressBar.label + property.floatValue.ToString("f02");
                
                //show bar and text
                EditorGUI.ProgressBar(position, fillamount, text);
            }
        }
        //Are we an Integer?
        else if (property.propertyType == SerializedPropertyType.Integer)
        {
            float fillamount = progressBar.NormalizedMinMax(property.intValue, progressBar.min, progressBar.max);
            EditorGUI.ProgressBar(position, fillamount, progressBar.label + property.intValue);
            //Idea > put a clear button on top of ProgressBar.

        }
        else
        {
            EditorGUI.LabelField(position, label.text, "Use ProgressBar with float or int.");
        }
       
    }


    /** if we want to hide the progress bar logics**/

    //public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    //{
    //    ProgressBarAttribute progressBarAttribute = attribute as ProgressBarAttribute;

    //    //if (progressBarAttribute != null && (progressBarAttribute.hideWhenZero && property.floatValue <= 0)) return 0;
    //    if (progressBarAttribute != null  &&  property.floatValue <= 0) return 0;
    //    return base.GetPropertyHeight(property, label);
    //}
}