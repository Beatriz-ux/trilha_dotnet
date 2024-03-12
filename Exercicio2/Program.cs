using Exercicio2.entities;
// See https://aka.ms/new-console-template for more information
 int FORMATO_12H = 12;
int FORMATO_24H = 24;

Data data = new Data(10, 03, 2000, 10, 30, 10);

data.Imprimir(Data.FORMATO_12H);
data.Imprimir(Data.FORMATO_24H);

Data d2 = new Data(15, 06, 2000, 23, 15, 20);
d2.Imprimir(Data.FORMATO_24H);
d2.Imprimir(Data.FORMATO_12H);

Data d3 = new Data(5, 10, 2005);
d3.Imprimir(Data.FORMATO_12H);
d3.Imprimir(Data.FORMATO_24H);
