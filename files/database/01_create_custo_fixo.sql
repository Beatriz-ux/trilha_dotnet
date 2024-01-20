CREATE TABLE Custo_Fixo (
    idGastoFixo INT AUTO_INCREMENT PRIMARY KEY,
    valorParcelaFixo DOUBLE NOT NULL,
    dataProximaParcelaFixo DATE NOT NULL,
    parcelasRestanresFixo INT NOT NULL,
    idConta INT NOT NULL,
    idCategoria INT NOT NULL
);
