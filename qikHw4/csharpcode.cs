// Name: Kunting Qi
// This is the C# implementation of hw4 
//C# code
// Console.WriteLine()
// Console.Write()

using System;

namespace ReadFilePrintInfo {
	class ReaderPrinter {
		static int NAME = 0, COURSE = 1, ID = 2, DUE = 3, SUBMITTED = 4,
						 MINUTESLATE = 5, LATEDEDUCTION = 6, P1 = 7,
						 P1COMMENTS = 8, P2 = 9, P2COMMENTS = 10, SUBTOTAL = 11,
						 TOTAL = 12;
						 
		//TODO
		public static string fillTmp(string modelString, string[] infoObjecct) {
			string result;
			result = modelString.Replace("");
		}
		
		//TODO
		public static void writeInformation(string infoString, 
			string outputFilename) {
				
		}
		
		//TODO
		public static string processTmp(string modelFilename) {
			
		}
			
		//TODO
		// This have better return the list of a collection 
		// of student's information
		// The candidate: Hashtable, ArrayList, Array
		//    Cur choose:                        *^*
		public static string[] readInfo(string studentInfoLine) {
				
		}
		
		public static void main(string[] args) {
			string fileInfoName = args[//TODO];
			string fileModelName = args[//TODO];
			string modelString = processTmp(fileModelName);
			// Spend the first line
			
			for /* string curline in file Stream */{
				string[] cur = readInfo(curLine);
				string completeInformation = fillTmp(modelString, cur);
				writeInformation(completeInformation, cur[NAME] + ".txt");
				}
			}
		}
	}
} 
