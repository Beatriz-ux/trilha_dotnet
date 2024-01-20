CREATE TABLE Custo_Variavel (
    idCustoVariavel INT AUTO_INCREMENT PRIMARY KEY,
    valorVariavel DOUBLE NOT NULL,
    dataPlanejada DATE NOT NULL,
    idConta INT NOT NULL,
    idCategoria INT NOT NULL
);
