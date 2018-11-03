using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTMatrix {
	// This iterator iterates over the upper triangular matrix.
	// This is done in a row major fashion, starting with [0][0],
	// and includes all N*N elements of the matrix.
	public class UTMatrixEnumerator : IEnumerator {
		public int pointer;

		public UTMatrixEnumerator(UTMatrix matrix) {
			pointer = 0;
		}
		public void Reset() {
			pointer = 0;
		}
		public bool MoveNext() {
			return pointer != matrix.data.Length - 1;
		}
		object IEnumerator.Current {
			get {
				return Current;
			}
		}
		public int Current {
			get {
				try {
					return 0;
				}
				catch (IndexOutOfRangeException) {
					throw new InvalidOperationException();
				}
			}
		}
	}
	public class UTMatrix : IEnumerable {
		// Must use a one dimensional array, having minimum size.
		public int [] data;
		public int row;
		public int column;
		// Construct an NxN Upper Triangular Matrix, initialized to 0
		// Throws an error if N is non-sensical.
		public UTMatrix(int N) {
			row = N;
			column = N;
			data = new int[N * N];
			Random rnd = new Random();
			for(int i = 0; i < data.Length; i++) {
				data[i] = int randomNumber = rnd.Next(0, 100000000);
			}

			for(int i = 0; i < row; i++) {
				for(int a = 0; a < i; a++) {
					data[r * column + c] = 0;
				}
			}
		}
		// Returns the size of the matrix
		public int getSize() {
			return row * column;
		}
		// Returns an upper triangular matrix that is the summation of a & b.
		// Throws an error if a and b are incompatible.
		public static UTMatrix operator + (UTMatrix a, UTMatrix b) {
			if(a.row != b.row || a.column != b.column) {
				// raise Error
				// TODO
			}
			UTMatrix result = new UTMatrix(a.data.Length);
			for(int i = 0; i < a.data.Length; i++) {
				result.data[i] = a.data[i] + b.data[i];
			}
			return result;

		}
		// Set the value at index [r][c] to val.
		// Throws an error if [r][c] is an invalid index to alter.
		public void set(int r, int c, int val) {
			if(((r + 1) < 1 || (r + 1) > row) 
				|| ((r + 1) < 1 || (r + 1) > column)) {
				// raise Error
				// TODO
			}
			data[r * column + c] = val;

		}
		// Returns the value at index [r][c]
		// Throws an error if [r][c] is an invalid index
		public int get(int r, int c) {
			if(((r + 1) < 1 || (r + 1) > row) 
				|| ((r + 1) < 1 || (r + 1) > column)) {
				// raise Error
				// TODO
			}
			return data[r * column + c];
		}
		// Returns the position in the 1D array for [r][c].
		// Throws an error if [r][c] is an invalid index
		public int accessFunc(int r, int c) {
			if(((r + 1) < 1 || (r + 1) > row) 
				|| ((r + 1) < 1 || (r + 1) > column)) {
				// raise Error
				// TODO
			}
			return r * column + c;
		}	
		// Returns an enumerator for an upper triangular matrix
		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
		public UTMatrixEnumerator GetEnumerator() {
			return new UTMatrixEnumerator(this);
		}

		public static void Main(String [] args) {
			const int N = 5;
			UTMatrix ut1 = new UTMatrix(N);
			UTMatrix ut2 = new UTMatrix(N);
			for (int r=0; r<N; r++) {
				ut1.set(r, r, 1);
				for (int c=r; c<N; c++) {
					ut2.set(r, c, 1);
				}
			}
			UTMatrix ut3 = ut1 + ut2;
			UTMatrixEnumerator ie = ut3.GetEnumerator();
			while (ie.MoveNext()) {
				Console.Write(ie.Current + " ");
			}
			Console.WriteLine();
			foreach (int v in ut3) {
				Console.Write(v + " ");
			}
			Console.WriteLine();
		}
	}
}
