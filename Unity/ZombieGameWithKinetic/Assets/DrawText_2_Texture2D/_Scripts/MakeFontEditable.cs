using UnityEngine;
using UnityEditor;
using System.IO;

public class MakeFontEditable :  MonoBehaviour
{
//	[MenuItem ("Assets/Import Editable Font")]
//	static void FontUtility_Import_Editable_Font()
//	{
//		string path = EditorUtility.OpenFilePanel( "Choose a Font file", "", "");
//		if( path == "" )
//			Debug.Log( "Canceled Font Import");
//		else
//		{
//			string sFontFilename = System.IO.Path.GetFileName( path );
//			AssetDatabase.ImportAsset( path );
//			//UnityEngine.Object f = AssetDatabase.LoadMainAssetAtPath( "Assets/_Fonts/" + sFontFilename );
//			//string path = AssetDatabase.GetAssetPath( f );
//			TrueTypeFontImporter fontImporter = AssetImporter.GetAtPath( "Assets/_Fonts/" + sFontFilename ) as TrueTypeFontImporter;
//			fontImporter.GenerateEditableFont( "Assets/_Fonts/" + sFontFilename );
//		}
//	}

	[MenuItem( "Assets/Make Font Editable" )]
	static void func_MakeFontEditable()
	{
		if( Selection.objects.Length == 0 )
		{
			Debug.LogError( "Sorry, but you have to select the Font (left click it once in the Project Panel) 1st! Abort!" );
			return;
		}

		string sFilePath = AssetDatabase.GetAssetPath( Selection.objects[0] );
		string sFilename = Path.GetFileNameWithoutExtension( sFilePath );
		string sFileExt = Path.GetExtension( sFilePath );

		if( sFileExt.ToLower() != ".ttf" )	// add more extension when Unity adds others font types
		{
			Debug.LogError( "Sorry, but you have Not selected a Font! Abort!" );
			return;
		}

		UnityEngine.Object f = AssetDatabase.LoadMainAssetAtPath( sFilePath );
		string path = AssetDatabase.GetAssetPath( f );

		TrueTypeFontImporter fontImporter = AssetImporter.GetAtPath(path) as TrueTypeFontImporter;

		string sFilePath_Import = path.Replace( sFilename + sFileExt, sFilename + "-Edit-Me" + sFileExt );
		fontImporter.GenerateEditableFont( sFilePath_Import );

		Debug.Log( "Editable Font created at: " + sFilePath_Import );
	}

}
