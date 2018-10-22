// Name: Kunting Qi
// This is the C# implementation of hw4 
//C# code
// Console.WriteLine()
// Console.Write()

using System;
using System.IO;

namespace ReadFilePrintInfo {
	class ReaderPrinter { 
						 
		// receive the string[] of a student as the student's information
		// and recevie the modelString for the model out outputfile
		// receive the model's field with actual information 
		// of the student 
		public static string FillTmp(string modelString, string[] infoObject, string[] dataField) {
			string result = modelString;
			Random rnd = new Random();
			int randomNumber = rnd.Next(0, 100000000);
			for(int i = 0; i < infoObject.Length; i++) {
				result = result.Replace("<<" + dataField[i] + ">>", randomNumber + infoObject[i]);
			}
			result = result.Replace("" + randomNumber, "");

			return result;
		}
		
		// write the whole infostring of a student 
		// into the file with the filename <studentName.txt> specified in 
		// the method parameter outputFilename
		public static void WriteInformation(string infoString, 
			string outputFilename) {
			File.WriteAllText(outputFilename, infoString);
		}
		
		// read the tmp file
		// and add all them together
		public static string ProcessTmp(string modelFilename) {
			// use the file stream to read the line
			// make the whole file as a string
			var lines = File.ReadAllLines(modelFilename);
			string result = "";
			
			for(int i = 0; i < lines.Length; i++) {
				result = result + lines[i] + "\n";
			}

			return result;
		}
			
		// split a line of student information
		// into a array of string
		// each element in the arrat means a specific field of inforamtion 
		// of a student
		public static string[] ReadInfo(string studentInfoLine) {
			string[] words = studentInfoLine.Split('\t');
			return words;
		}
		

		// this is the Main method
		// read the whole info file
		// with each infofile line call differnet method 
		// to split the information, can fill it with tmp file
		public static void Main(string[] args) {
			string fileInfoName = args[0];
			string fileModelName = args[1];
			string modelString = ProcessTmp(fileModelName);
			// Spend the first line
			var lines = File.ReadAllLines(fileInfoName);

			// because the first line doesn't container 
			// concrete inforamtion of stuednt 
			// so the loop start from the second line
			string[] dataField = lines[0].Split('\t');
			int whereIsID = -1;
			for(int i = 0; i < dataField.Length; i++) {
				if(dataField[i] == "ID") {
					whereIsID = i;
					break;
				}
			}

			for (int i = 1; i < lines.Length; i++) {
				string[] cur = ReadInfo(lines[i]);
				string completeInformation = FillTmp(modelString, cur, dataField);
				WriteInformation(completeInformation, cur[whereIsID] + ".txt");
			}
		}
	}
}

