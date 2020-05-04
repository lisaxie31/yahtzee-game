using System;
using static System.Console;
using System.Collections;

namespace Bme121
{
    class YahtzeeDice
    {
		int [] diceFaceValue = new int [5]; //each index value == face value of a dice
		Random rGen = new Random (); 
		
		public void Roll( ) 
		{
			for (int i = 0; i < 5; i++) 
			{
				if (diceFaceValue[i] == 0 ) // 0 == unrolled
				{
					diceFaceValue[i] = rGen.Next(1,7);
				}
			}
		}
	
		public void Unroll( string faces )
		{
			if (faces == "all") 
			{ 
				for (int i = 0; i < 5; i++) 
				{ 
					diceFaceValue[i] = 0;  //0s are reassigned face values in Roll method
				}
			}
			
			else 
			{
				for (int j = 0; j < faces.Length; j++)
				{
					int unrollValue = int.Parse(faces.Substring(j,1));
				
					for (int i = 0; i < 5; i++)
					{
						if (diceFaceValue[i] == unrollValue)
						{
							diceFaceValue[i] = 0; 
							break; // only rerolls one dice if there are multiples with the same face value
						}
					}
				}
			}
		}
		
		public int Sum( ) //of all face values
		{ 
			int sum = 0;
			for (int i = 0 ; i < 5 ; i++) 
			{ 
				sum = sum + diceFaceValue[i];
			}
			return sum;
		}
		
		public int Sum( int face ) //of the same face values
		{ 
			int faceSum = 0; 
			for (int i = 0 ; i < 5; i++) 
			{ 
				if ( diceFaceValue[i] == face)
				{ 
					faceSum = faceSum + diceFaceValue[i];
				}
			}
			return faceSum;
		}
		
		public bool IsRunOf( int length ) 
		{ 
			Array.Sort(diceFaceValue);

			int inital = diceFaceValue[0];
			int counter = 1; //starts at 1 since diceFaceValue[0] is already counted once
			
			for (int i = 1; i < 5; i++) //starts at 1 to avoid double counting diceFaceValue[0]
			{
				if (diceFaceValue[i] == inital + 1)
				{
					counter++; 
					inital++;
				}
				else inital = diceFaceValue[i]; //diceFaceValue[i] is always compared against diceFaceValue[i-1]
			}
			if (counter >= length) return true;
			else return false; 

		}
		
		public bool IsSetOf( int size ) 
		{ 
			bool setOf = false;
			for (int j = 0; j < 5; j++) 
			{
				int counter = 0; //resets counter for each test
				for (int i = 0; i < 5; i++) 
				{ 
					if (diceFaceValue[j] == diceFaceValue[i]) counter++;
				}
				if (counter >= size) setOf = true; 
			}
			return setOf;
		}
		
		public bool IsFullHouse( ) 
		{ 
			bool fullHouse = false; 
			
			int face1 = diceFaceValue[0]; //first value in fh
			int counter1 = 0; 
			
			int counter2 = 0; //placeholder
			int face2 = 0; //placeholder
			
			for ( int i = 0; i < 5 ; i++) 
			{
				if (diceFaceValue[i] != face1) //finds second value in fh
				{
					face2 = diceFaceValue[i];
					break;
				}
			}
			
			for (int i = 0; i < 5; i++) 
			{
				if (diceFaceValue[i] == face1) counter1++;
				if (diceFaceValue[i] == face2) counter2++; 
			}
			
			if (counter1 == 3 && counter2 == 2) fullHouse = true; 
			else if (counter2 == 3 && counter1 == 2) fullHouse = true;
			
			return fullHouse;
		}
	
	
		public override string ToString()
		{
			return $"The face values are {diceFaceValue[0]} {diceFaceValue[1]} {diceFaceValue[2]} {diceFaceValue[3]} {diceFaceValue[4]}";
		}
    }
}
