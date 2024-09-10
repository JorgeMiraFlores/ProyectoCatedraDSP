use farmacia_don_bosco;

select * from productos;

select * from usuarios;

select * from tipo;
select * from detalle_factura;
select * from factura;

UPDATE `farmacia_don_bosco`.`usuarios`
SET `idRol` = 2, `nombre` = 'Jorge Mira', `password` = '456'
WHERE `usuario` = 'Jorge';

SELECT 
    usuarios.idUsuarios,
    usuarios.usuario,
	roles.nombre AS nombreRol,
    usuarios.nombre,
    usuarios.password
FROM 
    farmacia_don_bosco.usuarios
JOIN 
    farmacia_don_bosco.roles ON usuarios.idRol = roles.idRoles;


-- Insertar 10 productos en la tabla `productos`
INSERT INTO `farmacia_don_bosco`.`productos` (
    `nombre`, `idMarca`, `idFabricante`, `idTipo`, `precio`, `caducidad`, `stock`
) VALUES
('Paracetamol 500 mg 20 Comprimidos', 1, 1, 1, 8.50, '2024-08-01', 50),
('Ibuprofeno 400 mg 20 Comprimidos', 2, 1, 1, 9.00, '2024-09-15', 75),
('Amoxicilina 500 mg 12 Cápsulas', 1, 1, 1, 15.20, '2025-03-10', 40),
('Loratadina 10 mg 10 Tabletas', 1, 1, 1, 7.80, '2025-05-22', 60),
('Vitamina C 500 mg 100 Tabletas', 2, 1, 1, 12.00, '2026-02-28', 120),
('Omeprazol 20 mg 14 Cápsulas', 1, 1, 1, 11.50, '2024-12-01', 30),
('Cetirizina 10 mg 10 Tabletas', 2, 1, 1, 6.90, '2025-07-15', 85),
('Metformina 850 mg 30 Tabletas', 1, 1, 1, 17.00, '2024-11-01', 45),
('Simvastatina 20 mg 28 Comprimidos', 1, 1, 1, 14.75, '2025-01-20', 50),
('Acetaminofén 500 mg 16 Tabletas', 2, 1, 1, 9.80, '2024-10-05', 65);
