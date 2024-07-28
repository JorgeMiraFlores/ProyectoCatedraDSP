-- -----------------------------------------------------
-- Schema farmacia_don_bosco
-- -----------------------------------------------------

DROP SCHEMA IF EXISTS `farmacia_don_bosco` ;
CREATE SCHEMA IF NOT EXISTS `farmacia_don_bosco` DEFAULT CHARACTER SET utf8 ;

-- -----------------------------------------------------
-- Table `farmacia_don_bosco`.`marcas`
-- -----------------------------------------------------

DROP TABLE IF EXISTS `farmacia_don_bosco`.`marcas`;
CREATE TABLE IF NOT EXISTS `farmacia_don_bosco`.`marcas` (
	`idMarca` INT NOT NULL AUTO_INCREMENT,
    `nombre` VARCHAR(200) NOT NULL,

	PRIMARY KEY (`idMarca`)
)
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `farmacia_don_bosco`.`fabricante`
-- -----------------------------------------------------

DROP TABLE IF EXISTS `farmacia_don_bosco`.`fabricante`;
CREATE TABLE IF NOT EXISTS `farmacia_don_bosco`.`fabricante` (
	`idFabricante` INT NOT NULL AUTO_INCREMENT,
    `nombre` VARCHAR(200) NOT NULL,

	PRIMARY KEY (`idFabricante`)
)
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `farmacia_don_bosco`.`tipo`
-- -----------------------------------------------------

DROP TABLE IF EXISTS `farmacia_don_bosco`.`tipo`;
CREATE TABLE IF NOT EXISTS `farmacia_don_bosco`.`tipo` (
	`idTipo` INT NOT NULL AUTO_INCREMENT,
    `nombre` VARCHAR(200) NOT NULL,

	PRIMARY KEY (`idTipo`)
)
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `farmacia_don_bosco`.`productos`
-- -----------------------------------------------------
-- tabla "farmacia_don_bosco.productos" --
DROP TABLE IF EXISTS `farmacia_don_bosco`.`productos` ;
CREATE TABLE IF NOT EXISTS `farmacia_don_bosco`.`productos` (
	`idProductos` INT NOT NULL AUTO_INCREMENT,
	`codigo-ean13` INT(13) NOT NULL,
	`nombre` VARCHAR(200) NOT NULL,
    `idMarca` INT(5) NOT NULL,		-- "farmacia_don_bosco.marcas"
	`idFabricante` INT(5) NOT NULL,		-- "farmacia_don_bosco.fabricantes"
    `idTipo` INT(5) NOT NULL,		-- "farmacia_don_bosco.tipos"
    `precio` FLOAT(6) NOT NULL,
    `caducidad` DATE NOT NULL,
    `stock` INT(7) DEFAULT 0 NOT NULL,

    
	PRIMARY KEY (`idProductos`),
	UNIQUE INDEX `idProductos_UNIQUE` (`idProductos` ASC),
    
    FOREIGN KEY (`idMarca`) REFERENCES `farmacia_don_bosco`.`marcas` (`idMarca`),
    FOREIGN KEY (`idFabricante`) REFERENCES `farmacia_don_bosco`.`fabricante` (`idFabricante`),
	FOREIGN KEY (`idTipo`) REFERENCES `farmacia_don_bosco`.`tipo` (`idTipo`)
)
ENGINE = InnoDB;


-- Insertar en la tabla `marcas`
INSERT INTO `farmacia_don_bosco`.`marcas` (`nombre`) VALUES ('Bayer');

-- Insertar en la tabla `fabricante`
INSERT INTO `farmacia_don_bosco`.`fabricante` (`nombre`) VALUES ('Fabricante X');

-- Insertar en la tabla `tipo`
INSERT INTO `farmacia_don_bosco`.`tipo` (`nombre`) VALUES ('Pastillas');

-- Insertar en la tabla `productos`
INSERT INTO `farmacia_don_bosco`.`productos` (
    `codigo-ean13`, `nombre`, `idMarca`, `idFabricante`, `idTipo`, `precio`, `caducidad`, `stock`
) VALUES
(1234567891111, 'Aspirina 500 mg 20 Comprimidos sp.', 1, 1, 1, 10.50, '2025-12-31', 100)


