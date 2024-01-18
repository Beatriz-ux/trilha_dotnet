CREATE TABLE trasicao (
    idtransacao INT AUTO_INCREMENT PRIMARY KEY,
    valorTransacao DECIMAL(10, 2),
    dataTransacao DATE,
    tipoTransacao VARCHAR(50),
    idConta INT,
    idCategoria INT
);
