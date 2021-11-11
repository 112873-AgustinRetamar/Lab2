use SistemaAcademico
--1- Promedio de las notas parciales de los alumnos del corriente año:
CREATE VIEW aprob_corr_mes
as
	select a.legajo Legajo, a.ape_alumno + ' ' + a.nom_alumno as 'Alumno', avg(nota) Nota
	from examenes e join alumnos a on a.legajo = e.legajo
	where year(fecha) = year(getdate()) and id_tipo = 1
--ESTO LO ESTOY AGREGANDO
	group by a.legajo, a.ape_alumno, a.nom_alumno

--2- Consultar alumnos en un rango de edad determinado:
CREATE PROCEDURE alumnos_edad
	@edad1 int,
	@edad2 int
as
	select legajo 'Legajo', ape_alumno + ' ' + nom_alumno as 'Alumno', DateDiff(DAY,fecha_nac,GETDATE())/365 'Edad' 
	from alumnos a
	where DateDiff(DAY,fecha_nac,GETDATE())/365 between @edad1 and @edad2

--PARA EJECUTARLO
exec alumnos_edad 10,25

--3- Consultar alumnos que estudien Ingeniera Civil:
CREATE VIEW alumnos_civil
as
	select a.legajo Legajo, ape_alumno+ ' ' + nom_alumno as 'Alumno', c.nom_carrera Carrera
	from alumnos a 
	join carrerasxalumnos ca on a.legajo = ca.legajo
	join carreras c on ca.id_carrera = c.id_carrera
	where c.nom_carrera like 'Ingenieria Civil'
--PARA CONSULTAR LA VISTA
select * from alumnos_civil


--4- Consultar alumnos con inasistencias en este año de la materia de química.
--LO Q DIJO LA PROFE. Que es id_tipo = 3? Y nota=0? Como obtienen las inasistencias?
--Evitar repeticiones de registros para que no aparezca 50 veces el mismo alumno que tiene 50 inasistencias.
select a.legajo Legajo, a.nom_alumno + a.ape_alumno as 'Alumno'
from examenes e join alumnos a on a.legajo=e.legajo join materias m on m.id_materia=e.id_materia
where id_tipo = 3 and nota = 0 and year(fecha)=year(getdate()) and m.nom_materia like 'Quimica'
order by Alumno

--5- Consultar lista de alumnos que aprobaron finales en el corriente año de una materia ingresada
alter procedure finales_aprobados
@materia varchar(50)
as
	select a.legajo 'Legajo', a.ape_alumno + ' '+ a.nom_alumno as 'Alumno', m.nom_materia 'Materia'
	from examenes e join alumnos a on a.legajo = e.legajo join materias m on e.id_materia = m.id_materia
	where e.id_tipo = 2 and e.nota >= 6 and m.nom_materia like '@materia'
--PARA EJECUTAR, no me nda el procedimiento pero si la consulta
exec finales_aprobados 'Quimica'
--CORREGIDA, el error estana en e.id_examen = m.id_materia
	select a.legajo 'Legajo', a.ape_alumno + ' '+ a.nom_alumno as 'Alumno', m.nom_materia 'Materia'
	from examenes e join alumnos a on a.legajo = e.legajo join materias m on e.id_materia = m.id_materia
	where e.id_tipo = 2 and e.nota >= 6 and m.nom_materia like 'Quimica'


--6- Emitir un listado de los alumnos que se hayan matriculado este año 
--incluyendo solo a aquellos cuyo legajo oscile entre 110000 y 115000.
select legajo 'Legajo', nom_alumno + ape_alumno as 'Alumno'
from alumnos
where legajo in(
	select m.legajo 
	from alumnos a join matriculas m 
	on a.legajo=m.legajo
	where year(fecha)=year(getdate()))
and legajo between 110000 and 115000

--7- Consultar las materias a las que está inscrito un alumno
--LO Q DIJO LA PROFE. Muestra todos los alumnos y todas las materias a la que están inscriptos
--no muestra ''un alumno''
select	a.legajo as 'Legajo', nom_alumno+' '+ape_alumno as 'Nombre', mat.nom_materia as 'Materia'
from alumnos a, matriculas m, matriculasXmaterias mm, materias mat
where a.legajo=m.legajo and m.id_matricula=mm.id_matricula and mm.id_materia=mat.id_materia
order by 1

select	a.legajo as 'Legajo', a.nom_alumno+' '+a.ape_alumno as 'Nombre', mate.nom_materia as 'Materia'
from matriculasXmaterias mxm 
join materias mate on mate.id_materia=mxm.id_materia
join matriculas matr on mxm.id_matricula=matr.id_matricula 
join alumnos a on matr.legajo=a.legajo
order by 1

--8- Listado de docentes y alumnos de la utn:

select legajo as 'Legajo', nom_alumno+' '+ape_alumno as 'Nombre', 'Alumno' as 'Tipo'
from alumnos
union
select legajo, nom_docente+' '+ape_docente, 'Docente'
from docentes
order by 3


--INSERT EN TABLAS, HICE LOS NECESARIOS PARA LAS CONSULTAS FORMULADAS

--PROVINCIAS
insert into provincias(id_provincia,nom_provincia)values(1, 'Buenos Aires');
insert into provincias(id_provincia,nom_provincia)values(2, 'Catamarca');
insert into provincias(id_provincia,nom_provincia)values(3, 'Chaco');
insert into provincias(id_provincia,nom_provincia)values(4, 'Chubut');
insert into provincias(id_provincia,nom_provincia)values(5, 'Córdoba');
insert into provincias(id_provincia,nom_provincia)values(6, 'Corrientes');
insert into provincias(id_provincia,nom_provincia)values(7, 'Entre Ríos');
insert into provincias(id_provincia,nom_provincia)values(8, 'Formosa');
insert into provincias(id_provincia,nom_provincia)values(9, 'Jujuy');
insert into provincias(id_provincia,nom_provincia)values(10, 'La Pampa');
insert into provincias(id_provincia,nom_provincia)values(11, 'La Rioja');
insert into provincias(id_provincia,nom_provincia)values(12, 'Mendoza');
insert into provincias(id_provincia,nom_provincia)values(13, 'Misiones');
insert into provincias(id_provincia,nom_provincia)values(14, 'Neuquén');
insert into provincias(id_provincia,nom_provincia)values(15, 'Río Negro');
insert into provincias(id_provincia,nom_provincia)values(16, 'Salta');
insert into provincias(id_provincia,nom_provincia)values(17, 'San Juan');
insert into provincias(id_provincia,nom_provincia)values(18, 'San Luis');
insert into provincias(id_provincia,nom_provincia)values(19, 'Santa Cruz');
insert into provincias(id_provincia,nom_provincia)values(20, 'Santa Fe');
insert into provincias(id_provincia,nom_provincia)values(21, 'Santiago del Estero');
insert into provincias(id_provincia,nom_provincia)values(22, 'Tierra del Fuego');
insert into provincias(id_provincia,nom_provincia)values(23, 'Tucumán');

--LOCALIDADES
insert into localidades(id_localidad, nom_localidad, id_provincia) values(1, 'Córdoba', 5);
insert into localidades(id_localidad, nom_localidad, id_provincia) values(2, 'La Plata', 1);
insert into localidades(id_localidad, nom_localidad, id_provincia) values(3, 'Jesus Maria', 5);
insert into localidades(id_localidad, nom_localidad, id_provincia) values(4, 'Villa Maria', 5);
insert into localidades(id_localidad, nom_localidad, id_provincia) values(5, 'Cosquin', 5);
insert into localidades(id_localidad, nom_localidad, id_provincia) values(6, 'Mendoza', 12);
insert into localidades(id_localidad, nom_localidad, id_provincia) values(7, 'San Salvador de Jujuy', 9);
insert into localidades(id_localidad, nom_localidad, id_provincia) values(8, 'La Rioja', 11);
insert into localidades(id_localidad, nom_localidad, id_provincia) values(9, 'Salta', 16);
insert into localidades(id_localidad, nom_localidad, id_provincia) values(10, 'Ushuaia', 23);

--BARRIOS
insert into barrios(id_barrio, nom_barrio, id_localidad) values(1, 'Colonia Urquiza', 2);
insert into barrios(id_barrio, nom_barrio, id_localidad) values(2, 'Alberdi', 1);
insert into barrios(id_barrio, nom_barrio, id_localidad) values(3, 'Alta Cordoba', 1);
insert into barrios(id_barrio, nom_barrio, id_localidad) values(4, 'Arguello', 1);
insert into barrios(id_barrio, nom_barrio, id_localidad) values(5, 'Villa Belgrano', 1);
insert into barrios(id_barrio, nom_barrio, id_localidad) values(6, 'Villa Cabrera', 1);
insert into barrios(id_barrio, nom_barrio, id_localidad) values(7, 'Alto Gorriti', 9);
insert into barrios(id_barrio, nom_barrio, id_localidad) values(8, 'Bajo Gorriti', 9);
insert into barrios(id_barrio, nom_barrio, id_localidad) values(9, 'Villa San Martin', 9);
insert into barrios(id_barrio, nom_barrio, id_localidad) values(10, 'Los Naranjos', 9);

--ALUMNOS
set dateformat dmy
insert into alumnos(legajo, nom_alumno, ape_alumno, telefono,email, id_barrio,fecha_nac) 
values(110999, 'Carla', 'Ñañez', 123123, 'CNanez@gmail.com', 2, '20/02/1994');
insert into alumnos(legajo, nom_alumno, ape_alumno, telefono,email, id_barrio,fecha_nac) 
values(111000, 'Esteban', 'Quito', 565656, 'EQuito@gmail.com', 3, '20/03/2000');
insert into alumnos(legajo, nom_alumno, ape_alumno, telefono,email, id_barrio,fecha_nac) 
values(112000, 'Juan', 'Limon', 454545, 'JLimon@gmail.com', 4, '20/09/2001');
insert into alumnos(legajo, nom_alumno, ape_alumno, telefono,email, id_barrio,fecha_nac) 
values(113000, 'Estela', 'Tela', 787878, 'ETela@gmail.com', 5, '20/01/1995');
insert into alumnos(legajo, nom_alumno, ape_alumno, telefono,email, id_barrio,fecha_nac) 
values(114000, 'Carlos', 'Rodriguez', 323232, 'CRodr@gmail.com', 6, '20/07/1996');
insert into alumnos(legajo, nom_alumno, ape_alumno, telefono,email, id_barrio,fecha_nac) 
values(115000, 'Elsa', 'Lame', 123456, 'Elsa@gmail.com', 2, '20/08/2002');
insert into alumnos(legajo, nom_alumno, ape_alumno, telefono,email, id_barrio,fecha_nac) 
values(116000, 'Rosa', 'Umberti', 654321, 'RUmberti@gmail.com', 3, '20/03/1994');
insert into alumnos(legajo, nom_alumno, ape_alumno, telefono,email, id_barrio,fecha_nac) 
values(117000, 'Pablo', 'Pan', 878787, 'PPan@gmail.com', 4, '20/10/1995');
insert into alumnos(legajo, nom_alumno, ape_alumno, telefono,email, id_barrio,fecha_nac) 
values(109000, 'Valentina', 'Valiente', 909090, 'VValiente@gmail.com', 5, '20/11/1999');
insert into alumnos(legajo, nom_alumno, ape_alumno, telefono,email, id_barrio,fecha_nac) 
values(100000, 'Belen', 'Diaz', 190190, 'BDiaz@gmail.com', 6, '20/12/2000');

--DOCENTES
set dateformat dmy
insert into docentes(legajo, nom_docente, ape_docente, telefono,email, id_barrio,fecha_nac) 
values(100, 'Miguel', 'Duarte', 001100, 'MDuarte@gmail.com', 2, '20/12/1990');
insert into docentes(legajo, nom_docente, ape_docente, telefono,email, id_barrio,fecha_nac) 
values(105, 'Alejandra', 'Aichino', 332233, 'Aichino@gmail.com', 6, '20/12/1985');
insert into docentes(legajo, nom_docente, ape_docente, telefono,email, id_barrio,fecha_nac) 
values(120, 'Camila', 'Marquez', 776677, 'CMarquez@gmail.com', 2, '20/12/1980');
insert into docentes(legajo, nom_docente, ape_docente, telefono,email, id_barrio,fecha_nac) 
values(110, 'Javier', 'Gomez', 334433, 'JGomez@gmail.com', 6, '20/12/1987');
insert into docentes(legajo, nom_docente, ape_docente, telefono,email, id_barrio,fecha_nac) 
values(130, 'Micaela', 'Amaya', 098098, 'MAmaya@gmail.com', 2, '20/12/1989');

--CARRERAS
insert into carreras(id_carrera, nom_carrera) values(1, 'Ingenieria Civil');
insert into carreras(id_carrera, nom_carrera) values(2, 'Ingenieria Eléctrica');
insert into carreras(id_carrera, nom_carrera) values(3, 'Ingenieria Eléctronica');
insert into carreras(id_carrera, nom_carrera) values(4, 'Ingenieria Industrial');
insert into carreras(id_carrera, nom_carrera) values(5, 'Ingenieria Mecánica');
insert into carreras(id_carrera, nom_carrera) values(6, 'Ingenieria Metalúrgica');
insert into carreras(id_carrera, nom_carrera) values(7, 'Ingenieria Química');
insert into carreras(id_carrera, nom_carrera) values(8, 'Ingenieria en Sist de Informcación');
insert into carreras(id_carrera, nom_carrera) values(9, 'Tecn Univ en Progrmación');

--CARRERAS X ALUMNOS
insert into carrerasXalumnos(id_carrera, legajo) values(1, 110999);
insert into carrerasXalumnos(id_carrera, legajo) values(8, 111000);
insert into carrerasXalumnos(id_carrera, legajo) values(1, 112000);
insert into carrerasXalumnos(id_carrera, legajo) values(9, 113000);
insert into carrerasXalumnos(id_carrera, legajo) values(9, 114000);
insert into carrerasXalumnos(id_carrera, legajo) values(9, 115000);
insert into carrerasXalumnos(id_carrera, legajo) values(8, 116000);
insert into carrerasXalumnos(id_carrera, legajo) values(3, 117000);
insert into carrerasXalumnos(id_carrera, legajo) values(2, 109000);
insert into carrerasXalumnos(id_carrera, legajo) values(1, 100000);

--MATERIAS
insert into materias(id_materia, nom_materia, id_carrera) values(1, 'Fisica', 8);
insert into materias(id_materia, nom_materia, id_carrera) values(2, 'Ingles', 9);
insert into materias(id_materia, nom_materia, id_carrera) values(3, 'Quimica', 8);
insert into materias(id_materia, nom_materia, id_carrera) values(4, 'Quimica', 7);
insert into materias(id_materia, nom_materia, id_carrera) values(5, 'Algebra', 8);


--TIPO NOTAS(Asistencia es 0=libre y 1=Regular)
insert into tipoNotas(id_tipo, nom_tipo) values(1, 'Parcial');
insert into tipoNotas(id_tipo, nom_tipo) values(2, 'Final');
insert into tipoNotas(id_tipo, nom_tipo) values(3, 'Asistencia');


--EXAMENES (id_tipo 1, 2 y 3 son parcial, final y asist respectivemente)
--Para la 4ta consulta, hice examenes para la asist de quimica
set dateformat dmy
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(1, 3, '20/10/2021', 0, 3, 110999);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(2, 3, '20/10/2021', 0, 4, 111000);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(3, 3, '20/10/2021', 0, 3, 112000);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(4, 3, '20/10/2021', 1, 4, 113000);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(5, 3, '20/10/2020', 1, 4, 114000);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(6, 3, '20/10/2020', 1, 4, 115000);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(7, 3, '20/10/2021', 1, 4, 116000);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(8, 3, '20/10/2021', 1, 4, 117000);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(9, 3, '20/10/2021', 1, 4, 109000);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(10, 3, '20/10/2021', 0, 3, 100000);

--Para la 1er consulta, hice examenes de tipo parcial
set dateformat dmy
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(11, 1, '20/10/2021', 2, 3, 110999);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(12, 1, '20/10/2021', 9, 4, 111000);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(13, 1, '20/10/2021', 6, 3, 112000);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(14, 1, '20/10/2021', 8, 4, 113000);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(15, 1, '20/10/2020', 2, 4, 114000);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(16, 1, '20/10/2020', 8, 4, 115000);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(17, 1, '20/10/2021', 6, 4, 116000);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(18, 1, '20/10/2021', 7, 4, 117000);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(19, 1, '20/10/2021', 2, 4, 109000);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(20, 1, '20/10/2021', 8, 3, 100000);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(21, 1, '20/10/2021', 9, 4, 116000);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(22, 1, '20/10/2021', 8, 4, 117000);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(23, 1, '20/10/2021', 6, 4, 109000);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(24, 1, '20/10/2021', 2, 3, 100000);

--Para la 5ta consulta, hice examenes del tipo final. Tmbn solo de 'Quimica'
set dateformat dmy
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(25, 2, '20/10/2021', 6, 3, 110999);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(26, 2, '20/10/2021', 7, 4, 111000);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(27, 2, '20/10/2021', 8, 3, 112000);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(28, 2, '20/10/2021', 8, 4, 113000);
insert into examenes(id_examen, id_tipo, fecha, nota, id_materia, legajo) 
	values(29, 2, '20/10/2021', 6, 4, 114000);

--MATRICULAS
insert into matriculas(id_matricula, legajo, fecha) values(1, 110999, '01/04/2021');
insert into matriculas(id_matricula, legajo, fecha) values(2, 111000, '01/04/2021');
insert into matriculas(id_matricula, legajo, fecha) values(3, 112000, '01/04/2021');
insert into matriculas(id_matricula, legajo, fecha) values(4, 113000, '01/04/2021');
insert into matriculas(id_matricula, legajo, fecha) values(5, 114000, '01/04/2021');
insert into matriculas(id_matricula, legajo, fecha) values(6, 115000, '01/04/2021');
insert into matriculas(id_matricula, legajo, fecha) values(7, 116000, '01/04/2021');
insert into matriculas(id_matricula, legajo, fecha) values(8, 117000, '01/04/2021');
insert into matriculas(id_matricula, legajo, fecha) values(9, 109000, '01/04/2021');
insert into matriculas(id_matricula, legajo, fecha) values(10, 100000, '01/04/2021');

--MATRICULAS X MATERIAS No la hice, que es condicion¿
--insert into matriculasXmaterias(id_matricula, id_materia, condicion) values(id, id, '  ');


--delete from carreras
	--where id_carrera<20