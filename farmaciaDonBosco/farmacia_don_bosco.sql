-- -----------------------------------------------------
-- Schema farmacia_don_bosco
-- -----------------------------------------------------

DROP SCHEMA IF EXISTS `farmacia_don_bosco` ;
CREATE SCHEMA IF NOT EXISTS `farmacia_don_bosco` DEFAULT CHARACTER SET utf8 ;


-- -----------------------------------------------------
-- Table `farmacia_don_bosco`.`roles`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `farmacia_don_bosco`.`roles`;
CREATE TABLE IF NOT EXISTS `farmacia_don_bosco`.`roles` (
	`idRoles` INT NOT NULL AUTO_INCREMENT,
    `nombre` VARCHAR(100) NOT NULL,

	PRIMARY KEY (`idRoles`)
)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `farmacia_don_bosco`.`usuarios`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `farmacia_don_bosco`.`usuarios`;
CREATE TABLE IF NOT EXISTS `farmacia_don_bosco`.`usuarios` (
	`idUsuarios` INT NOT NULL AUTO_INCREMENT,
    `usuario` VARCHAR(100) NOT NULL UNIQUE,
	`idRol` INT NOT NULL,
	`nombre` VARCHAR(100) NOT NULL,
	`password` VARCHAR(100) NOT NULL,

	PRIMARY KEY (`idUsuarios`),
    
	FOREIGN KEY (`idRol`) REFERENCES `farmacia_don_bosco`.`roles` (`idRoles`)
)
ENGINE = InnoDB;


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

DROP TABLE IF EXISTS `farmacia_don_bosco`.`fabricantes`;
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

-- -----------------------------------------------------
-- Table `farmacia_don_bosco`.`formas_pago`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `farmacia_don_bosco`.`formas_pago`;
CREATE TABLE IF NOT EXISTS `farmacia_don_bosco`.`formas_pago` (
    `idFormaPago` INT NOT NULL AUTO_INCREMENT,
    `nombre` VARCHAR(100) NOT NULL,
    PRIMARY KEY (`idFormaPago`)
)
ENGINE = InnoDB;

-- Insertar en la tabla `formas_pago`
INSERT INTO `farmacia_don_bosco`.`formas_pago` (`nombre`)
VALUES ('Efectivo'), ('Tarjeta');


-- ---------------------------------------------
-- Table `farmacia_don_bosco`.`factura`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `farmacia_don_bosco`.`factura`;
CREATE TABLE IF NOT EXISTS `farmacia_don_bosco`.`factura` (
    `idFactura` INT NOT NULL AUTO_INCREMENT,
    `fecha` DATETIME NOT NULL,
    `cliente` VARCHAR(200) NOT NULL,
	`idFormaPago` INT NOT NULL,
    `descuento` INT DEFAULT 0,
	`subtotal` FLOAT(6,2) NOT NULL,
	`total` FLOAT(6,2) NOT NULL,
    
    PRIMARY KEY (`idFactura`),
	FOREIGN KEY (`idFormaPago`) REFERENCES `formas_pago`(`idFormaPago`)
) ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `farmacia_don_bosco`.`detalle_factura`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `farmacia_don_bosco`.`detalle_factura`;
CREATE TABLE IF NOT EXISTS `farmacia_don_bosco`.`detalle_factura` (
    `idDetalle` INT NOT NULL AUTO_INCREMENT,
    `idFactura` INT NOT NULL,
    `idProducto` INT NOT NULL,
    `cantidad` INT NOT NULL,
    `precio_unitario` FLOAT(6,2) NOT NULL,
    `subtotal` FLOAT(6,2) NOT NULL,

    PRIMARY KEY (`idDetalle`),
    
    FOREIGN KEY (`idFactura`) REFERENCES `factura`(`idFactura`) ON DELETE CASCADE,
    FOREIGN KEY (`idProducto`) REFERENCES `productos`(`idProductos`) ON DELETE CASCADE
) ENGINE = InnoDB;



-- Insertar en la tabla `marcas`
INSERT INTO `farmacia_don_bosco`.`marcas` (`nombre`) VALUES ('Johnson&Johnson'),('Gsk');

-- Insertar en la tabla `fabricante`
INSERT INTO `farmacia_don_bosco`.`fabricante` (`nombre`) VALUES ('Bayer');

-- Insertar en la tabla `tipo`
INSERT INTO `farmacia_don_bosco`.`tipo` (`nombre`) VALUES ('Pastillas');

-- Insertar en la tabla `productos`
INSERT INTO `farmacia_don_bosco`.`productos` (
    `nombre`, `idMarca`, `idFabricante`, `idTipo`, `precio`, `caducidad`, `stock`
) VALUES
('Aspirina 500 mg 20 Comprimidos sp.', 1, 1, 1, 10.50, '2025-12-31', 100);

INSERT INTO `farmacia_don_bosco`.`roles` (`nombre`)
VALUES ('Administrador'),('Cajero');


INSERT INTO `farmacia_don_bosco`.`usuarios` (`usuario`, `idRol`, `nombre`, `password`)
VALUES ('Jorge', 1, 'george', '123');


use farmacia_don_bosco;
select * from productos where idProductos = 1;
