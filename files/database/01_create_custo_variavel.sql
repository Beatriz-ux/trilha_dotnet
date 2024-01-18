create table Custo_Variavel{
    idCustoVariavel INT AUTO_INCREMENT PRIMARY KEY,
    valorVarivel double not null,
    dataPlanejada date not null,
    idConta int not null,
    idCategoria int not null,
}
