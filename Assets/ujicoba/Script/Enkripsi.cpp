/*
  enkripsi berkas text dengan algoritma XOR sederhana
  berkas plaintext : plaintext.txt
  berkas chipertext : chipertext.txt
*/
#include <stdio.h>
main(){
       FILE *Fin, *Fout;
       char P, C, K[20];
       int n, i;

       Fin = fopen("plaintext.txt", "r");
       Fout = fopen("chipertext.txt", "w");
       printf("kata kunci : ");
       gets(K);
       n = strlen(K); /*panjang kunci*/
       i = 0;
       while ((P = getc(Fin)) != EOF){
         C = P ^ K[i];
         putc(C, Fout);
         i++;
         if(i>n-1) i = 0;
       }
      fclose(Fin);
      fclose(Fout);
}