create table Custo_Fixo{
    idGastoFixo INT AUTO_INCREMENT PRIMARY KEY,
    valorParcelaFixo double not null,
    dataProximaParcelaFixo date not null,
    parcelasRestanresFixo int not null,
    idConta int not null,
    idCategoria int not null,
}
