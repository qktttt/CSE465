using System;
using System.Reflection;

namespace Serializer {
	public class MySerializer {
		public static string Serialize(Object obj) {
			// stub
			// TODO: enter your code here
			Type type = obj.GetType();
			String result = "";
			// the method attribute and the value of them
			foreach (FieldInfo info in type.GetFields()) {
				if (info.MemberType == MemberTypes.Field) {
					// append the string to the result
					// and a newline character at the end
					result += (info.Name + "=" + info.GetValue(obj) + "\n");
				}
			}
			return result;
		}
		public static T Deserialize<T>(string str) {
			// stub
			// TODO: enter your code here
			// break the str into lists of parameter and values
			// [parameter1, parameter2, ....]
			// [value1    , value2    , ....]
			string[] allLines = str.Split('\n');
			string[] fieldName = new string[allLines.Length];
			string[] fieldValue = new string[allLines.Length];
			for(int i = 0; i < allLines.Length-1; i++) {
				Console.WriteLine(1);
				string[] nameAndValue = allLines[i].Split('=');
				fieldName[i] = nameAndValue[0];
				fieldValue[i] = nameAndValue[1];
				Console.WriteLine(2);
			}

			Type type = typeof(T);
			ConstructorInfo ctor = type.GetConstructor(new Type[] { });
			T obj = (T)ctor.Invoke(new Object[] { });
			/*
			* for each instance variable in class
			* find the corresponding str value
			* convert and assign the value to the 
			* instance variable 
			*/
			type = obj.GetType();
			foreach(FieldInfo info in type.GetFields()) {
				/*
				using loops to find the value string
				*/
				int whereIsContent = 0;
				for(int i = 0; i < fieldName.Length; i++) {
					if(string.Equals(fieldName[i], info.Name)) {
						whereIsContent = i;
						break;
					}
				}

				String content = fieldValue[whereIsContent];
				Object v = content;
				Console.WriteLine(info.FieldType);
				if(info.FieldType == typeof(int)) {
					Console.WriteLine("this is a integer");
					v = Convert.ToInt32(v);
				}
				else if(info.FieldType == typeof(double)) {
					Console.WriteLine("this is a double");
					v = Convert.ToDouble(v);
				}
				else if(info.FieldType == typeof(bool)) {
					Console.WriteLine("this is a boolean");
					v = Convert.ToBoolean(v);
				}

				info.SetValue(obj, v);
			}
			return obj;
		}
	}
	public class Point {
		public int x, y;
		public Point() {
			x = y = 0;
		}
		public Point(int X, int Y) {
			x = X;
			y = Y;
		}
	}
	
    public class Student {
		public String name;
		public double gpa;
		public bool is_undergrad;
		
		public Student()
		{
			name = "John Doe";
			gpa = 4.0;
			is_undergrad = true;
		}
		public Student(String n, double GPA, bool b)
		{
			name = n;
			gpa = GPA;
			is_undergrad = b;
		}
		public override string ToString()
		{
			return String.Format("{0} {1} {2}", name, gpa, is_undergrad);
		}
	}
	
	public class Test {
		public static void Main(String [] args) {	
			Point p1 = new Point(2, 3);
			String str1 = MySerializer.Serialize(p1);
			Console.WriteLine(str1);
			Point newPt = MySerializer.Deserialize<Point>(str1);
			Console.WriteLine(newPt);
			
			Student s1 = new Student("Test Student", 3.5, false);
			String str2 = MySerializer.Serialize(s1);
			Console.WriteLine(str2);
			Student newSt = MySerializer.Deserialize<Student>(str2);
			Console.WriteLine(newSt);
		}
	}
}

