// See https://aka.ms/new-console-template for more information
using Exercicio1.models;

Console.WriteLine("Hello, World!");
Lampada lampada = new Lampada(true);
int resp = 0;

lampada.Imprimir();
do{
    Console.WriteLine("Digite 1 para ligar, 2 para desligar e 0 para sair");
    resp = int.Parse(Console.ReadLine());
    switch(resp){
        case 1:
            lampada.Ligar();
            lampada.Imprimir();
            break;
        case 2:
            lampada.Desligar();
            lampada.Imprimir();
            break;
        case 0:
            Console.WriteLine("Saindo...");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }

}while(resp != 0);

