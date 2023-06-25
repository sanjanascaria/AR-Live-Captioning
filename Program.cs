using System;
using System.Data;

namespace CaptionPosition
{
  class CaptionPosition
  {
    static void CalculateNewPositionBias(int[,] positionbias, int captionrow, int captioncol)
    {
      int i, j;
      int c = 1;

      for (j = captioncol-1; j >= 0; j--) {
               positionbias[captionrow,j] = c;  
               positionbias[captionrow+1,j] = c;
               c++;
        }

      for (j = captioncol+6, c = 1; j <= 11; j++) {
               positionbias[captionrow,j] = c; 
               positionbias[captionrow+1,j] = c;
               c++;
        }

      for (j = captioncol; j <= captioncol+5; j++ ) {
              for (i = captionrow, c = 0; i >= 2; i--) {
                positionbias[i,j] = c;
                c++;
              }
      }

      for (j = captioncol; j <= captioncol+5; j++ ) {
              for (i = captionrow+1, c = 0; i <= 9; i++) {
                positionbias[i,j] = c;
                c++;
              }
      
      }

      for (j = 1; j <= 5; j++) {
        c = positionbias[captionrow,j]+1; int initc = c;
        int row = captionrow-1;
        int col = j-1;
        while(row >= 2 && col >= 0) {
          positionbias[row,col] = c;
          c++; row--; col--;
        }
      }

      for (j = 6; j <= 10; j++) {
        c = positionbias[captionrow,j]+1;
        int row = captionrow-1;
        int col = j+1;
        while(row >= 2 && col <= 11) {
          positionbias[row,col] = c;
          c++; row--; col++;
        }
      }

      for (j = 1; j <= 5; j++) {
        c = positionbias[captionrow+1,j]+1;
        int row = captionrow+2;
        int col = j-1;
        while(row <= 9 && col >= 0) {
          positionbias[row,col] = c;
          c++; row++; col--;
        }
      }

      for (j = 6; j <= 10; j++) {
        c = positionbias[captionrow+1,j]+1;
        int row = captionrow+2;
        int col = j+1;
        while(row <= 9 && col <= 11) {
          positionbias[row,col] = c;
          c++; row++; col++;
        }
      }

      
      for (j = captioncol; j<= captioncol+5; j++) {
          int row = captionrow - 1;
          int col = j+1;
          if (col == 12) {
            break;
          }
          c = 0;
          while(row >= 2 && col <= 11) {
            positionbias[row,col] = c+1; c++;
            row--; col++;
          }
        }

        for (j = captioncol; j<= captioncol+5; j++) {
          int row = captionrow - 1;
          int col = j-1;
          if (col == -1) {
            break;
          }
          c = 0;
          while(row >= 2 && col >= 0) {
            positionbias[row,col] = c+1; c++;
            row--; col--;
          }
        }

        for (j = captioncol; j<= captioncol+5; j++) {
          int row = captionrow + 2;
          int col = j+1;
          if (col == 12) {
            break;
          }
          c = 0;
          while(row <= 9 && col <= 11) {
            positionbias[row,col] = c+1; c++;
            row++; col++;
          }
        }

        for (j = captioncol; j<= captioncol+5; j++) {
          int row = captionrow + 2;
          int col = j-1;
          if (col == -1) {
            break;
          }
          c = 0;
          while(row <= 9 && col >= 0) {
            positionbias[row,col] = c+1; c++;
            row++; col--;
          }
        }

      
      }
    
    static void CalcObjectBias(int[,] objectbias)  
    {

    }
    
    static void Main(string[] args)
    {
      int i, j;
      int[,] basebias = new int[12, 12] {{9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9}, {9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9}, {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2}, {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3}, {3, 3, 4, 5, 6, 6, 6, 6, 5, 4, 3, 3}, {3, 3, 4, 5, 6, 6, 6, 6, 5, 4, 3, 3}, {3, 3, 4, 5, 6, 6, 6, 6, 5, 4, 3, 3}, {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2}, {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, {9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9}, {9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9} };

      int captionrow = 5;
      int captioncol = 3;

      int[,] positionbias = new int[12, 12] {{9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9}, {9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9}, {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, {9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9}, {9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9} };
      CalculateNewPositionBias(positionbias, captionrow, captioncol);

      int[,] objectbias = new int[12, 12] {{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} };
      int[,] finalbias = new int[12, 12];

      for (i = 0; i < 12; i++) {
            for (j = 0; j < 12; j++) {
               finalbias[i,j] = basebias[i,j] + positionbias[i,j] + objectbias[i,j] ;
               Console.Write(finalbias[i,j] + " ");    
        }
        Console.WriteLine();
      }

      int sum = 0;
      int small = 987654321;
      int row=0, col = 0;
      bool flag = false;

      for( i = 2; i <= 8; i++) {
        for ( j = 0; j <= 6; j++) {
          for( int k = i; k <= i+1; k++) {
            for ( int l = j; l <= j+5; l++) {
              sum += finalbias[k,l];
          }
        }

        if (sum < small) {
                small = sum;
                row = i;
                col = j;
                flag = true;
            }
        sum = 0;

      }
    
   }
  
  Console.WriteLine(small);
  if(flag) {
    
    Console.WriteLine(col);
    Console.WriteLine(row);
  }

  double xcoord =  (5/6.0) * (col+3) - 5;
  double ycoord = 4+8.5/6 - (row-1)*8.5/6;

  Console.WriteLine(xcoord);
  Console.WriteLine(ycoord);

  }
}
}
